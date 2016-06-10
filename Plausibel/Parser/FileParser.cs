using Plausibel.Operator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plausibel.Parser
{
    public class FileParser : IParser
    {
        private StreamReader _StreamReader;

        public void SetCircuitName(string Name)
        {
            _StreamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\circuits\\" + Name + ".txt");
        }

        /// <summary>
        /// Return a list with the definition of all operators
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetInitialization()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (_StreamReader == null)
            {
                // StreamReader not opened yet
                Console.WriteLine("Please open a file first");
                return result;
            }
            
            // read file line by line until the first empty line occurs
            String line;
            while ((line = ReadNextLine()).Length > 0)
            {
                string[] details = ExtractLine(line);

                Console.WriteLine(details[0] + " is type of " + details[1]);

                result.Add(details[0], details[1]);
            }

            return result;
        }

        /// <summary>
        /// Set the operators as a circuit
        /// </summary>
        /// <param name="Operators"></param>
        /// <returns></returns>
        public Dictionary<string, BaseOperator> DecorateOperators(Dictionary<string, BaseOperator> Operators)
        {
            if (_StreamReader == null)
            {
                Console.WriteLine("Please open a file first");
                return Operators;
            }
            
            String line;
            while ((line = ReadNextLine()).Length > 0)
            {
                string[] details = ExtractLine(line);
                string[] Receivers = details[1].Split(new char[] { ',' });
                BaseOperator Provider = Operators[details[0]];
                foreach (String Receiver in Receivers)
                {
                    Provider.SetNextOperator(Operators[Receiver]);
                }
            }

            return Operators;
        }

        /// <summary>
        /// Read the next line (skip lines starting with a hastag
        /// </summary>
        /// <returns></returns>
        private string ReadNextLine()
        {
            String line;

            while ((line = _StreamReader.ReadLine()) != null)
            {
                if (line.Length == 0)
                {
                    return "";
                }

                if (line.Substring(0, 1).ToString() == "#")
                {
                    // comment, continue
                    continue;
                }

                return line;
            }

            return "";
        }

        /// <summary>
        /// Extract the details of a line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string[] ExtractLine(String line)
        {
            var charsToRemove = new string[] { " ", "\t", "\u0009", "_", ";" };
            foreach (var c in charsToRemove)
            {
                line = line.Replace(c, string.Empty);
            }

            string[] Result = line.Split(':');

            return new string[]
            {
                Result[0], Result[1]
            };
        }

        /// <summary>
        /// Quit parsing, close the connection to the file
        /// </summary>
        public void StopParsing()
        {
            _StreamReader.Close();
            _StreamReader = null;
        }
    }
}
