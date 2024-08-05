using System;
using System.Data;
using System.Text;
using System.Xml;
namespace FizzBuzz
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<int, string> rules = new Dictionary<int, string>{
                {3, "Fizz"},
                {5, "Buzz"},
                {7, "Bang"},
                {11, "Bong"},
                {13, "Fezz"},
                // {15, "FizzBuzz"},
                // {21, "FizzBang"},
                // {35, "BuzzBang"}
            };


            IEnumerable<String> numbers = Enumerable.Range(1, 100).Select(num => {
                List<string> word = new List<string>();

                if (num%13 ==0) word.Add(rules[13]);

                foreach (var rule in rules)
                {
                    if (rule.Key != 13 && num % rule.Key == 0) word.Add(rule.Value);
                }

                if (word.Contains(rules[13]) && word.Contains(rules[3])) {
                    word.Remove(rules[13]);
                    int fizzIndex = word.IndexOf(rules[3]);
                    word.Insert(fizzIndex + 1, rules[13]);
                }

                if (word.Count == 0) word.Add(num.ToString());
                return string.Join("",word);
            });

            string result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }
}
