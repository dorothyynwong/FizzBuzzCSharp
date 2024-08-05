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

        static void Main(string[] args)
        {


            IEnumerable<String> numbers = Enumerable.Range(1, 300).Select(num => {
                List<string> words = new List<string>();

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
    }
}
