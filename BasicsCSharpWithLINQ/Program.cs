using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsCSharpWithLINQ
{
    class Program
    {

        static void Main(string[] args)
        {
            ShowHeaderApplication();

            Console.WriteLine("\nDeve inserir uma list de valores númericos separados por ',':");
            string listOfNumbers = ConsoleRead();

            Console.WriteLine("Selecione uma opção:");

            ShowMenuApplication();

            string optionSelected = ConsoleRead();

            bool menuOptionResult = true;

            while (menuOptionResult)
            {
                switch (optionSelected)
                {
                    case "1":
                        FilterByOdd(listOfNumbers);
                        break;
                    case "2":
                        FilterByEven(listOfNumbers);
                        break;
                    case "3":
                        FirstThreeValues(listOfNumbers);
                        break;
                    case "4":
                        ListMaxValue(listOfNumbers);
                        break;
                    case "5":
                        InvertList(listOfNumbers);
                        break;
                    case "6":
                        OrderByAscendent(listOfNumbers);
                        break;
                    case "7":
                        menuOptionResult = false;
                        break;
                    default:
                        break;
                }

                if (!optionSelected.Equals("7"))
                {
                    Console.WriteLine("\nSelecione uma nova opção:");
                    optionSelected = ConsoleRead();
                } 

            }

        }

        private static void OrderByAscendent(string listOfNumbers)
        {
            string[] listSplited = listOfNumbers.Split(',');
            var result = listSplited.OrderByDescending(p => p).Reverse();
            Console.WriteLine("Resultado: {0}", String.Join(",", result));
        }

        private static void InvertList(string listOfNumbers)
        {
            var listSplited = listOfNumbers.Split(',');
            Console.WriteLine("Resultado: {0}", String.Join(",", listSplited.Reverse()));
        }

        private static void ListMaxValue(string listOfNumbers)
        {
            string[] listSplited = listOfNumbers.Split(',');
            int[] listSplitedIntegers = Array.ConvertAll(listSplited, s => int.Parse(s));
            var maxValue = listSplitedIntegers.Max();
            Console.WriteLine("Resultado: {0}", maxValue);
        }

        private static void FirstThreeValues(string listOfNumbers)
        {
            string[] listSplited = listOfNumbers.Split(',');
            var result = listSplited.Take(3);
            Console.WriteLine("Resultado: {0}", String.Join(",", result));
        }

        private static string ConsoleRead()
        {
            Console.Write(">");
            return Console.ReadLine();
        }

        private static void ShowHeaderApplication()
        {
            Console.WriteLine("IT Sector - Sistemas de Informação, SA");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Conceitos Básicos C# - LINQ (OFF)");
        }

        private static void ShowMenuApplication()
        {
            Console.WriteLine("1. Filtrar os números pares");
            Console.WriteLine("2. Filtrar os números impares");
            Console.WriteLine("3. Obter os três primeiros valores");
            Console.WriteLine("4. Maior valor da lista");
            Console.WriteLine("5. Inverter");
            Console.WriteLine("6. Ordenar de forma ascendente");
            Console.WriteLine("7. Sair");

        }

        private static void FilterByOdd(string listOfNumbers)
        {
            string result = "";
            string[] numbersSplited = listOfNumbers.Split(',');
            for (int i = 0; i < numbersSplited.Length; i++)
            {
                if (int.Parse(numbersSplited[i]) % 2 == 0)
                {
                    result += numbersSplited[i];
                    if (i != numbersSplited.Length - 1)
                    {
                        result += ",";
                    }
                }
            }
            Console.WriteLine("Resultado: {0}", result);
        }

        private static void FilterByEven(string listOfNumbers)
        {
            string[] listSplited = listOfNumbers.Split(',');

            var evenNumbers = listSplited.Where(ch => int.Parse(ch) % 2 != 0);

            Console.WriteLine("Resultado: {0}", String.Join(",", evenNumbers));
        }
    }
}
