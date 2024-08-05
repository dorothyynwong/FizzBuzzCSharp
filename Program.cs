using System;
namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = String.Join(" ", Enumerable.Range(1, 100));
            Console.WriteLine(result);
        }
    }
}
