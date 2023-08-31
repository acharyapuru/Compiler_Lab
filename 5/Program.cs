using System;
using System.Collections.Generic;
using System.IO;

namespace CDC_Lab
{
    class CFGAnalyzer
    {
        static void Main(string[] args)
        {
            List<string> nonTerminals = new List<string>();
            List<string> terminals = new List<string>();
            List<string> productions = new List<string>();
            string startingSymbol = "";

            try
            {
                string[] lines = File.ReadAllLines("cfg.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split("->", StringSplitOptions.TrimEntries);
                    string leftSide = parts[0];
                    string[] rightSideProductions = parts[1].Split('|', StringSplitOptions.TrimEntries);

                    nonTerminals.Add(leftSide);

                    foreach (string production in rightSideProductions)
                    {
                        productions.Add($"{leftSide} -> {production}");
                        foreach (char symbol in production)
                        {
                            if (!Char.IsUpper(symbol) && symbol != ' ' && !terminals.Contains(symbol.ToString()))
                            {
                                terminals.Add(symbol.ToString());
                            }
                        }
                    }

                    if (startingSymbol == "")
                    {
                        startingSymbol = leftSide;
                    }
                }

                Console.WriteLine("Set of non-terminals = {" + string.Join(", ", nonTerminals) + "}");
                Console.WriteLine("Set of terminals = {" + string.Join(", ", terminals) + "}");
                Console.WriteLine("Set of productions = {" + string.Join(", ", productions) + "}");
                Console.WriteLine("Starting symbol = {" + startingSymbol + "}");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file: " + e.Message);
            }
            Utility.StudentInfo("5");
        }
    }
}


