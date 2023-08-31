using System;
using System.Collections.Generic;



namespace CDC_Lab
{

    class NonTerminal
    {
        public string Name { get; set; }
        public List<string> Rules { get; set; }

        public NonTerminal(string name)
        {
            Name = name;
            Rules = new List<string>();
        }

        public void AddRule(string rule)
        {
            Rules.Add(rule);
        }

        public void SetRules(List<string> rules)
        {
            Rules = rules;
        }

        public void PrintRule()
        {
            Console.Write(Name + " -> ");
            for (int i = 0; i < Rules.Count; i++)
            {
                Console.Write(Rules[i]);
                if (i != Rules.Count - 1)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    class Grammar
    {
        private List<NonTerminal> NonTerminals { get; set; }

        public Grammar()
        {
            NonTerminals = new List<NonTerminal>();
        }

        public void AddRule(string rule)
        {
            bool nt = false;
            string parse = "";

            for (int i = 0; i < rule.Length; i++)
            {
                char c = rule[i];
                if (c == ' ')
                {
                    if (!nt)
                    {
                        NonTerminal newNonTerminal = new NonTerminal(parse);
                        NonTerminals.Add(newNonTerminal);
                        nt = true;
                        parse = "";
                    }
                    else if (parse != "")
                    {
                        NonTerminals[NonTerminals.Count - 1].AddRule(parse);
                        parse = "";
                    }
                }
                else if (c != '|' && c != '-' && c != '>')
                {
                    parse += c;
                }
            }
            if (parse != "")
            {
                NonTerminals[NonTerminals.Count - 1].AddRule(parse);
            }
        }

        public void InputGrammar1()
        {
            AddRule("S -> Sab | ab | a | b");

        }
        public void InputGrammar2()
        {
            AddRule("A -> A0 | A1 | 0");
        }



        public void SolveImmediateLR(NonTerminal A)
        {
            string name = A.Name;
            string newName = name + "'";

            List<string> alphas = new List<string>();
            List<string> betas = new List<string>();
            List<string> rules = new List<string>(A.Rules);
            List<string> newRulesA = new List<string>();
            List<string> newRulesA1 = new List<string>();

            foreach (string rule in rules)
            {
                if (rule.Substring(0, Math.Min(name.Length, rule.Length)) == name)
                {
                    alphas.Add(rule.Substring(name.Length));
                }
                else
                {
                    betas.Add(rule);
                }
            }

            if (alphas.Count == 0)
            {
                return;
            }

            if (betas.Count == 0)
            {
                newRulesA.Add(newName);
            }

            foreach (string beta in betas)
            {
                newRulesA.Add(beta + newName);
            }

            foreach (string alpha in alphas)
            {
                newRulesA1.Add(alpha + newName);
            }

            A.SetRules(newRulesA);
            newRulesA1.Add("\u03B5");

            NonTerminal newNonTerminal = new NonTerminal(newName);
            newNonTerminal.SetRules(newRulesA1);
            NonTerminals.Add(newNonTerminal);
        }

        public void ApplyAlgorithm()
        {
            int size = NonTerminals.Count;
            for (int i = 0; i < size; i++)
            {

                SolveImmediateLR(NonTerminals[i]);
            }
        }

        public void PrintRules()
        {
            foreach (NonTerminal nonTerminal in NonTerminals)
            {
                nonTerminal.PrintRule();
            }

        }
        public void ResetGrammar()
        {
            NonTerminals.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Grammar grammar = new Grammar();
            grammar.InputGrammar1();
            Console.WriteLine("The grammar 1 is : ");
            grammar.PrintRules();
            Console.WriteLine("\nGrammar 1 after removing left recursion : ");
            grammar.ApplyAlgorithm();
            grammar.PrintRules();
            grammar.ResetGrammar();

            grammar.InputGrammar2();
            Console.WriteLine("\nThe grammar 2 is : ");
            grammar.PrintRules();
            Console.WriteLine("\nGrammar 2 after removing left recursion : ");
            grammar.ApplyAlgorithm();
            grammar.PrintRules();
            Utility.StudentInfo("3");
        }
    }


}
