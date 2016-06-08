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

        public Dictionary<string, string> GetInitialization()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (_StreamReader == null)
            {
                Console.WriteLine("Please open a file first");
                return result;
            }

            Console.WriteLine("Init");
            String line;
            while ((line = ReadNextLine()).Length > 0)
            {
                string[] details = ExtractLine(line);

                Console.WriteLine(details[0] + " is type of " + details[1]);

                result.Add(details[0], details[1]);
            }

            return result;
        }

        public Dictionary<string, BaseOperator> DecorateOperators(Dictionary<string, BaseOperator> Operators)
        {
            if (_StreamReader == null)
            {
                Console.WriteLine("Please open a file first");
                return Operators;
            }

            Console.WriteLine("Decorator");
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

        public void StopParsing()
        {
            _StreamReader.Close();
            _StreamReader = null;
        }
    }
}
