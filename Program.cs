using System;
namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            for(int i=1; i<=100; i++) {
                string word = "";
                if (i%3 == 0) word = "Fizz"; 
                else word = i.ToString();

                result = String.Join(" ", result, word);
            }
            Console.WriteLine(result);
        }
    }
}
