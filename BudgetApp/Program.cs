/*
Create a console application that will help you track your expenses, and thus survive in this economy! Your app should be able to do the following

Prompt the user to enter the initial budget
Prompt the user to enter expenses with amount and description
Display the all expenses and the remaining amount
 */
using System;
using System.Collections.Generic;

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
            Console.WriteLine("Input initial budget (MUST BE INT):");
            int budgetInitial = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter expense: Amount and Description");
            string input = Console.ReadLine()!;
            string temp = string.Empty;
            int amount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    temp += input[i];
                }
            }
            amount = int.Parse(temp); //must be decimal 
            string description = string.Concat(input.Where(char.IsLetter));
            Console.WriteLine(description + " " + amount); //testing purpose


            //diplay list
            foreach (Item item in budget)
            {
                Console.WriteLine(item.Description());
            }

        }

        //Method to calculate remaining amount
        private decimal CalculateRemain(List<Item> budgetList, int budget)
        {
            decimal total = 0;
            foreach (Item item in budgetList)
            {
                total += item.getCost();
            }
            return budget - total;
        }
    }


    public record Item
    {
        private string description { get; set; }
        private decimal cost { get; set; }

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



