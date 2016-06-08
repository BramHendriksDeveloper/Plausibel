using System;
using System.Collections.Generic;
using Plausibel.Operator;
using Plausibel.Parser;
using Plausibel.Cirquit;

namespace Plausibel
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                OperatorFactory x = new OperatorFactory();

                FileParser p = new FileParser();
                CirquitCreator cCreator = new CirquitCreator(p);

                string circuitInput = "";
                Cirquit.Cirquit c = null;
                do
                {
                    System.Console.Write("Write the name of the circuit: ");
                    circuitInput = System.Console.ReadLine();
                    try
                    {
                        c = cCreator.GetCirquit(circuitInput);
                        System.Console.WriteLine("Chosen circuit: " + circuitInput);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Circuit does not exist in <Desktop>/circuits");
                    }
                } while (c == null);

                if(c.validate() == true)
                {
                    Dictionary<string, bool> allInput = new Dictionary<string, bool>();

                    foreach (InputOperator io in c.GetInputOperators())
                    {
                        string input;
                        do
                        {
                            System.Console.Write("Value of " + io.GetName() + ": ");
                            input = System.Console.ReadKey().KeyChar.ToString();
                            System.Console.WriteLine();
                        } while (input != "0" && input != "1");

                        allInput.Add(io.GetName(), input == "1");
                    }

                    Dictionary<string, bool> output = c.Emulate(allInput);

                    foreach (KeyValuePair<string, bool> v in output)
                    {
                        System.Console.WriteLine("Value of " + v.Key + " became: " + (v.Value ? "1" : "0"));
                    }

                    System.Console.WriteLine("Press any key to continue ... ");

                    System.Console.ReadKey();
                }
                else
                {
                    System.Console.WriteLine("Circuit was not valid.");
                }
            } while (true);

        }
    }
}
