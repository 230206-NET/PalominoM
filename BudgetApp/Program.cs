/*
Create a console application that will help you track your expenses, and thus survive in this economy! Your app should be able to do the following

Prompt the user to enter the initial budget
Prompt the user to enter expenses with amount and description
Display the all expenses and the remaining amount
 */
using System;
using System.Collections.Generic;

//Title of app
Console.WriteLine("BUDGET APP");

//User input
int budgetInitial = int.Parse(Console.WriteLine("Input initial budget")!);
Console.WriteLine("Enter expense: Amount and Description");
string input = Console.ReadLine();
string temp;
int amount = 0;
for (int i = 0; i < input.Length; i++) {
    if (Char.IsDigit(input[i])) {
        temp += input[i];
        input[i] = " ";
    }    
}

Console.WriteLine(temp);
amount = int.Parse(temp);


//Method to calculate remaining amount
private decimal CalculateRemain() {
    return 0; 
}

public record Item { 
    private string description { get; set; }
    private int cost { get; set; }

    public string Description() {
        return "Cost: " + cost + "  Description: " + description;
    }

}


