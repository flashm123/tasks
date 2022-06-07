using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            ConsoleKey key;

            do
            {
                Console.WriteLine("Please input numbers separated by space:");

                List<int> numbersArr = new List<int>();

                var input = Console.ReadLine();
                try
                {
                    var numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.Parse(n))
                        .ToList<int>();

                    // Check that numners count is even: only tickets with even numbers can be happy
                    if (numbers.Count % 2 != 0)
                    {
                        throw new Exception("Input numers sequence must be even");
                    }

                    Console.WriteLine(new Ticket(numbers).IsHappyTicket);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please input numbers separated by space:");
                }
                Console.WriteLine("Continue? Y/N");
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.N);
        }
        public static bool IsHappyTicket(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] != numbers[numbers.Count - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }

    internal struct Ticket
    {
        public List<int> numbers;

        public Ticket(List<int> numbers)
        {
            this.numbers = new List<int>();
            this.numbers = numbers;
        }

        /// <summary>
        /// Check if ticket is happy: left and right parts are reversed
        /// </summary>
        public bool IsHappyTicket
        {
            get 
            {
                for (int i = 0; i < numbers.Count / 2; i++)
                {
                    if (numbers[i] != numbers[numbers.Count - i - 1])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
