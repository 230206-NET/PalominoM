using System;

namespace HotOrCold {

    public class HOC {
        public static void Main(string[] args)
        {
            var ran = new Random();
            int target = ran.Next(21);
            string input = Console.ReadLine();
            int num = int.Parse(input);
            if (num == target) {
                Console.WriteLine("YAY");
            }
            else if (num > target)
            {
                Console.WriteLine("Too High");
            }
            else
            {
                Console.WriteLine("Too Low");
            }
        }
    }
    
}