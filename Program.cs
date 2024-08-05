using System;
using System.Data;
using System.Text;
using System.Xml;
namespace FizzBuzz
{
    class Program
    {
        static Dictionary<int, string> rules = new Dictionary<int, string>{
                {3, "Fizz"},
                {5, "Buzz"},
                {7, "Bang"},
                {11, "Bong"},
                {13, "Fezz"},
            };

        static List<string> SpecialHandlingForFezz(List<string> words)
        {
            if (words.Contains(rules[3]))
            {
                words.Remove(rules[13]);
                int fizzIndex = words.IndexOf(rules[3]);
                words.Insert(fizzIndex + 1, rules[13]);
            }

            return words;
        }

        static void PrintFizzBuzz(int maxNumber) {
            IEnumerable<String> numbers = Enumerable.Range(1, maxNumber).Select(num => {
                List<string> words = new();

                if (num%13 ==0) words.Add(rules[13]);

                foreach (var rule in rules)
                {
                    if (rule.Key != 13 && num % rule.Key == 0) words.Add(rule.Value);
                }

                if (words.Contains(rules[13])) {
                    words = SpecialHandlingForFezz(words);
                }

                if (words.Count == 0) words.Add(num.ToString());

                if (num%17 == 0) words.Reverse();

                return string.Join("",words);
            });

            string result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
        
        static int GetMaxNumberFromUsers() {
            Console.Write("Please input the maximum number: ");
            string? strInput = Console.ReadLine();
            if (int.TryParse(strInput, out int maxNumber))
                return maxNumber;
            else return 0;
        }

        static void Main(string[] args)
        {
            // int maxNumber;
            // do {
            //     maxNumber = GetMaxNumberFromUsers();
            //     if (maxNumber < 0) Console.WriteLine("Invalid number, please enter again.");

            // } while (maxNumber <= 0);
            // PrintFizzBuzz(maxNumber);

            Console.WriteLine(string.Join(" ",Enumerable.Range(1,100).Select(n=>n%15==0 ? "FizzBuzz" : n%21==0 ? "FizzBang" : n%35==0 ? "BuzzBang" : n%3==0 ? "Fizz" : n%5==0 ? "Buzz" : n%7==0 ? "Bang" : n.ToString())));
        }
    }
}
