using System;
using System.Collections.Generic;

namespace CDC_Lab
{
    class SymbolTable
    {
        private class Variable
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
            public int Address { get; set; }
        }

        private List<Variable> variables = new List<Variable>();
        private int currentAddress = 100;

        public void AddVariable(string name, string type, string value)
        {
            Variable variable = new Variable
            {
                Name = name,
                Type = type,
                Value = value,
                Address = currentAddress
            };

            variables.Add(variable);
            currentAddress += 100;
        }

   

        public void PrintSymbolTable()
        {
            Console.WriteLine("Variable Name\tType\tValue\tAddress");
            foreach (var variable in variables)
            {
                Console.WriteLine($"{variable.Name}\t\t{variable.Type}\t{variable.Value}\t{variable.Address}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SymbolTable symbolTable = new SymbolTable();

            symbolTable.AddVariable("a", "int", "2");
            symbolTable.AddVariable("b", "float", "3.5");

            symbolTable.PrintSymbolTable();
            Utility.StudentInfo("4");
        }
    }

}

