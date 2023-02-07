using System;

namespace HotOrCold
{

    public class HOC
    {
        public static void Main(string[] args)
        {
            var ran = new Random(21);
            int target = ran.Next(21);
            Console.WriteLine("Target: " + target);
            Console.WriteLine("GUESS: ");
            string input = Console.ReadLine();
            int num = int.Parse(input);

            while (num != target)
            {
                if (num > target)
                {
                    Console.WriteLine("Too High. Guess Again:");
                }
                else
                {
                    Console.WriteLine("Too Low. Guess Again:");
                }
                input = Console.ReadLine();
                num = int.Parse(input);
            }
            Console.WriteLine("YAY! You did it :)");


        }
    }

}