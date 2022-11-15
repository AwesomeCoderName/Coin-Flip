using System;
class Program
{
    public static void Main(string[] args)
    {
        Program game = new Program();
        game.Menu();
    }
    private string[] confirm = { "yes", "y", "ye", "yeah" };
    private string[] deny = { "no", "n", "nah" };
    private static int moolah = 1000;
    private int bet;
    private string[] answers = new string[2];

    public void Menu()
    {
        Console.WriteLine("Welcome! Are you ready to get your gambling freak on?!");
        Console.WriteLine("Y/N:");

        string? userInput1 = Console.ReadLine();
        foreach (string ans in confirm)
        {
            if (userInput1!.ToUpper() == ans.ToUpper())
            {
                Console.WriteLine("Let's GOOOOOO!");
                // set a value to true
                play();
            }
            
        }
        Console.WriteLine("Aww, maybe next time...");
    }
    public void play() { betting(); flipCoin();  judgement(); }

    public void betting()
    {
        Console.WriteLine("How much are you betting?");
        Console.WriteLine("Current Amount: " + moolah);
        string? betAmnt = Console.ReadLine();
        bool isString = int.TryParse(betAmnt, out int numbericBetAmnt);
        bet = numbericBetAmnt; // will be later used for rewards purposes
        if (isString) // if isString is true
        {
            if (moolah < numbericBetAmnt)
            {
                if (moolah == 0)
                {
                    Console.WriteLine("You have 0 moolah. \nAnswer this riddle and I'll give you $500");
                    Console.WriteLine("Joe's father has three sons: Peter Nick and (blank). \nWho is the other son? ");
                    string? userGuess = Console.ReadLine();
                    if (userGuess == "Joe" || userGuess == "joe")
                    {
                        moolah += 500;
                        play();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, bub \nLet's start over new. :D "); // Should automatically end the game
                        moolah += 1000; // restarts the players amount
                        Menu();
                    }
                }
                else
                {
                    Console.WriteLine("Re-bet a different amount dumb ass");
                    betting();
                }
            }
            else // player does have enough betting money
            {
                moolah -= numbericBetAmnt;
            }
        }
        else // the input is not a integer
        {
            Console.WriteLine("Your input is not an integer. \nTry Again");
            betting();
        }
    }

    public void flipCoin()
    { // "flips" a coin and edits private string[] answers to {heads, h} or {tails, t}
        Random num = new Random();
        int coin = num.Next(50);
        if (coin < 25)
        {
            answers[0] = "tails";
            answers[1] = "t";
        }
        else
        {
            answers[0] = "heads";
            answers[1] = "h";
        }
        Console.Clear();
    }

    public void judgement()
    { // determines if the players guess were correct or not according to flipCoin()
        Console.WriteLine("Heads or Tails?:");
        string? userInput2 = Console.ReadLine();
        
        if (userInput2!.ToUpper() == answers[0].ToUpper() )
        { // if the player guessed correct this occurs
          Console.WriteLine("Winner Winner Chicken Dinner!");
          moolah += bet * 2;
          Console.WriteLine("Current Amount: " + moolah);
          replay();
        }
        else if (userInput2.ToUpper() == answers[1].ToUpper() ) {
          Console.WriteLine("Winner Winner Chicken Dinner!");
          moolah += bet * 2;
          Console.WriteLine("Current Amount: " + moolah);
          replay();
        }
        else
        { // if player was incorrect
            if (userInput2.ToUpper() != "HEADS" && userInput2.ToUpper() != "H" && userInput2.ToUpper() != "TAILS" && userInput2.ToUpper() != "T")
            {
                Console.WriteLine(userInput2 + ", really... \nAre you that much of a dumbass?");
                Console.WriteLine("Penalty for entering inrelevant guesses is a deduction of twice the amounted betted ");
                moolah -= bet;
                play();
            }
            else
            {
                Console.WriteLine("Ugh, What a loser...");
                Console.WriteLine("Current Amount: " + moolah);
                replay();
            }
        }
    }

    public void replay()
    { // Asks the player if they would like to play again
        Console.WriteLine("Would you like to play again?! \n Y/N:");
        string? userInput3 = Console.ReadLine();
        foreach (string ans in confirm)
        {
            if (userInput3 == ans)
            {
                Console.WriteLine("Yay!");
                play();
            }
        }
        Console.WriteLine("See ya, dork!");
    }

}
