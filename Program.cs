using System;
using System.Text;
namespace FizzBuzz
{
    class Program
    {

        static void Main(string[] args)
        {
            // string result = "";
            // for(int i=1; i<=100; i++) {
            //     string word = "";
            //     if (i%3 == 0) word += "Fizz"; 
            //     if  (i%5 == 0) word += "Buzz";
            //     if (i%3 !=0 && i%5 !=0) word = i.ToString();

            //     result += word + " ";
            // }
            // Console.WriteLine(result.TrimEnd());

            IEnumerable<String> numbers = Enumerable.Range(1, 100).Select(num => {
                   if (num%3 ==0 && num%5 ==0) return "FizzBuzz";
                   if (num%3 == 0) return "Fizz"; 
                   if (num%5 == 0) return "Buzz";
                   return num.ToString();
            });

            string result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }
}
