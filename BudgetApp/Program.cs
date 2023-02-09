/*
Create a console application that will help you track your expenses, and thus survive in this economy! Your app should be able to do the following

Prompt the user to enter the initial budget
Prompt the user to enter expenses with amount and description
Display the all expenses and the remaining amount
 */
using System;
using System.Collections.Generic;

/*
    - Need to check if input is number 
    - check if number is not negative
    - check if expense input is still valid 
    - check if user wants to continue input is actually valid
 
 */
namespace BudgetApp
{
    public class BudgetCalculator
    {

        // decimal budgetMoney;
        public static void Main(string[] args)
        {
            Console.WriteLine("BUDGET APP");
            //create list of items
            List<Item> budget = new List<Item>();
            //User input
            //add try and catch if user inputs another thing 
            Console.WriteLine("Input initial budget (MUST BE NUMBER):");
            int budgetInitial = int.Parse(Console.ReadLine()!);

            promptUser(budget);

            //diplay list
            foreach (Item item in budget)
            {
                Console.WriteLine(item.Description());
            }

            decimal remaining = calculateRemaining(budget, budgetInitial);
            if (remaining < 0)
            {
                Console.WriteLine("You are way over budget! Money left:" + remaining);
            }
            else
            {
                Console.WriteLine("You have enough money. Money left:" + remaining);
            }


        }

        //Method to calculate remaining amount
        private static decimal calculateRemaining(List<Item> budgetList, decimal budget)
        {
            decimal total = 0;
            foreach (Item item in budgetList)
            {
                total += item.getCost();
            }
            return budget - total;
        }

        private static void promptUser(List<Item> list)
        {
            bool end = false;
            while (end == false)
            {
                Console.WriteLine("Enter expense: Amount and Description");
                string input = Console.ReadLine()!;
                addToList(list, input);
                Console.WriteLine("Would you like to add another expense? (Y/N)");
                string ans = Console.ReadLine()!;
                if (ans == "Y" || ans == "y")
                {
                    end = false;
                }
                else if (ans == "N" || ans == "n")
                {
                    end = true;
                }
            }

        }

        private static List<Item> addToList(List<Item> list, string input)
        {
            string temp = string.Empty;
            int amountTemp = 0; decimal amount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    temp += input[i];
                }
            }
            if (temp.Length > 0)
            {
                amountTemp = int.Parse(temp); //must be decimal 
                amount = amountTemp;
            }

            string description = string.Concat(input.Where(char.IsLetter));
            list.Add(new Item(description, amount));
            return list;
        }
    }


    public record Item
    {
        private string description { get; set; }
        private decimal cost { get; set; }

        public Item(string des, decimal cost)
        {
            this.description = des;
            this.cost = cost;
        }

        public string Description()
        {
            return "Cost: " + cost + "  Description: " + description;
        }
        public decimal getCost()
        {
            return cost;
        }

    }

}



