using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Xml;
namespace FizzBuzz
{
    class Program
    {
        //default rules if no arguments
        static Dictionary<int, string> defaultRules = new Dictionary<int, string>{
                {3, "Fizz"},
                {5, "Buzz"},
                {7, "Bang"},
                {11, "Bong"},
                {13, "Fezz"},
                {17, ""}
            };

        //user's chosen rules
        static Dictionary<int, string> userRules = new Dictionary<int, string>();

        static void GetRulesFromUsers(string[] args)
        {
            if (args.Length == 0)
            {
                userRules = new Dictionary<int, string>(defaultRules);
                return;
            }


            foreach (string arg in args)
            {
                int num;
                int.TryParse(arg, out num);

                if (!defaultRules.ContainsKey(num))
                {
                    Console.WriteLine("Invalid rule. Default rules will be use. " + arg);
                    userRules = defaultRules;
                    return;
                }
                
                userRules[num] = defaultRules[num];
            }
        }

        static List<string> SpecialHandlingForFezz(List<string> words)
        {
            if (words.Contains(userRules[3]))
            {
                words.Remove(userRules[13]);
                int fizzIndex = words.IndexOf(userRules[3]);
                words.Insert(fizzIndex + 1, userRules[13]);
            }

            return words;
        }

        static void PrintFizzBuzz(int maxNumber) {
            IEnumerable<String> numbers = Enumerable.Range(1, maxNumber).Select(num => {
                List<string> words = new();

                if (userRules.ContainsKey(13) && num%13 ==0) words.Add(userRules[13]);

                foreach (var rule in userRules)
                {
                    if (rule.Key != 13 && rule.Key != 17 && num % rule.Key == 0) words.Add(rule.Value);
                }

                if (userRules.ContainsKey(13) && words.Contains(userRules[13])) {
                    words = SpecialHandlingForFezz(words);
                }

                if (words.Count == 0) words.Add(num.ToString());

                if (userRules.ContainsKey(17) && num%17 == 0) words.Reverse();

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
            GetRulesFromUsers(args);

            int maxNumber;
            do {
                maxNumber = GetMaxNumberFromUsers();
                if (maxNumber < 0) Console.WriteLine("Invalid number, please enter again.");

            } while (maxNumber <= 0);

            PrintFizzBuzz(maxNumber);

            // Console.WriteLine(string.Join(" ",Enumerable.Range(1,100).Select(n=>n%15==0 ? "FizzBuzz" : n%21==0 ? "FizzBang" : n%35==0 ? "BuzzBang" : n%3==0 ? "Fizz" : n%5==0 ? "Buzz" : n%7==0 ? "Bang" : n.ToString())));
        }
    }
}
