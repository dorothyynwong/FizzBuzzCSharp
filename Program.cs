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
                {15, "FizzBuzz"}
            };

            IEnumerable<String> numbers = Enumerable.Range(1, 100).Select(num => {
                string word = "";
                   foreach(var rule in rules) {
                    if (num % rule.Key == 0) word = rule.Value;
                   }

                   if(string.IsNullOrEmpty(word)) word = num.ToString();
                   return word;
            });

            string result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }
}
