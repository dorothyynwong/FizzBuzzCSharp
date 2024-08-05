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
                if (i%3 == 0) word += "Fizz"; 
                if  (i%5 == 0) word += "Buzz";
                if (i%3 !=0 && i%5 !=0) word = i.ToString();

                result += word + " ";
            }
            Console.WriteLine(result.TrimEnd());
        }
    }
}
