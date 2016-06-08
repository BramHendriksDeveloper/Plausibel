using System;
using System.Collections.Generic;
using System.IO;
using Plausibel.Operator;

namespace Plausibel
{
    public class Parser
    {
        private StreamReader _StreamReader;
        private OperatorFactory _Factory;

        public Cirquit GetCirquit(string fileName)
        {
            try
            {
                _StreamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\circuits\\" + fileName + ".txt");
            }
            catch(Exception e)
            {
                throw e;
            }
            _Factory = new OperatorFactory();

            Dictionary<String, BaseOperator> Operators = ParseInitialization();
            ParseDecorator(Operators);
            Console.WriteLine("done");
            _StreamReader.Close();

            _StreamReader = null;

            return new Cirquit(Operators);
        }

        private Dictionary<String, BaseOperator> ParseInitialization()
        {
            Dictionary<String, BaseOperator> result = new Dictionary<string, BaseOperator>();

            Console.WriteLine("Init");
            String line;
            while((line = ReadNextLine()).Length > 0)
            {
                string[] details = ExtractLine(line);

                Console.WriteLine(details[0] + " is type of " + details[1]);

                result.Add(details[0], _Factory.GetOperatorByName(details[1], details[0]))  ;
            }

            return result;
        }

        private void ParseDecorator(Dictionary<String, BaseOperator> Operators)
        {
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
        }

        private string ReadNextLine()
        {
            String line;

            while ((line = _StreamReader.ReadLine()) != null)
            {   
                if(line.Length == 0)
                {
                    return "";
                }

                if(line.Substring(0, 1).ToString() == "#")
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
    }
}
