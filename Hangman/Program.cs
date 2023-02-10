
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string temp;
        hangman h = new hangman();
        while (h.getNumGuess() <= 6)
        {
            h.displayCurrentGuesses();
            if (h.wonGame() == true)
            {
                Console.WriteLine("YAY YOU WON!");
                break;
            }
            Console.WriteLine("Make a guess");
            temp = Console.ReadLine();
            if (temp.Length != 1)
                Console.WriteLine("Please enter a single character");
            else
                h.makeGuess(temp[0]);
        }
    }
}

public class hangman
{
    private List<string> wordbank = new List<string> { "code", "loyalty", "practice", "potato" };
    private string chosenWord;
    private int count;
    private List<char> guesses = new List<char>();
    private int numGuess = 0;

    public hangman()
    {
        Random rand = new Random();
        this.chosenWord = wordbank[rand.Next(wordbank.Count())];
        count = chosenWord.Distinct().Count();
    }

    public void makeGuess(char s)
    {
        if (guesses.Contains(s)) return;
        guesses.Add(s);
        string temp = chosenWord.ToLower();
        if (temp.Contains(s))
        {
            Console.WriteLine("Correct!");
            this.count--;
        }
        else
        {
            numGuess++;
            Console.WriteLine("Incorrect");
        }

    }

    public bool wonGame()
    {
        if (this.count == 0)
        {
            return true;
        }
        return false;
    }

    public void displayCurrentGuesses()
    {
        foreach (var c in chosenWord)
            Console.Write(guesses.Contains(c) ? c : '_');
        Console.Write('\n');

    }

    public int getNumGuess()
    {
        return numGuess;
    }

}