using System;
using System.Linq;

namespace Mastermind
{
    public static class answer{
        public static int[] numbers = new int[4];
    }
    class Program
    {
        public static int attempts = 0; 
        public static bool winFlag = false;       

        static void Main(string[] args)
        {
            if(attempts == 0) {
                playGame();
            }            
            while(attempts == 10 || winFlag == true) {
                if(attempts == 10) {
                    Console.WriteLine("You lose! Play again? (Y/N)");
                } else {
                    Console.WriteLine("You won! Play again? (Y/N)");
                }
                
                var userResponse = Console.ReadLine();
                if (userResponse == "Y" || userResponse == "y") { 
                    playGame();                 
                }
                else if (userResponse == "N" || userResponse == "n")
                {
                    break;
                }
                else{
                    Console.WriteLine("Invalid Selection!");
                }
            }                        
        }

        public static void beginNewGame()
        {
            winFlag = false;
            attempts = 0;            
            answer.numbers[0] = new Random().Next(1,6);
            answer.numbers[1] = new Random().Next(1,6);
            answer.numbers[2] = new Random().Next(1,6);
            answer.numbers[3] = new Random().Next(1,6);
        }

        public static void playGame()
        {
            displayBanner();
            beginNewGame();
                while(attempts < 10 && winFlag == false) {                
                string guess = Console.ReadLine();
                if(guess == "stop") {
                    break;
                }               
                if(Int32.TryParse(guess, out int intGuess) && intGuess < 9999 && intGuess > 999) {
                    bool invalidNumFlag = false;
                    int[] guessArray = new int[4];
                    for(int i = 0; i < 4; i++)
                    {
                        int digit = (int)Char.GetNumericValue(guess[i]);
                        guessArray[i] = digit;
                        if (digit == 0 || digit > 6) {
                            invalidNumFlag = true;
                        }
                    }
                    if(invalidNumFlag) {
                        Console.WriteLine("Each digit should be between 1 and 6.");
                    } else {
                        attempts++;                              
                        if (guessArray.SequenceEqual(answer.numbers)) {                            
                            winFlag = true;
                        }
                        string[] markings = new string[4];
                        for(int i = 0; i < 4; i++) {
                            if(guessArray[i] == answer.numbers[i]) {
                                markings[i] = "+";
                            } else if(answer.numbers.Contains(guessArray[i])) {
                                markings[i] = "-";
                            } 
                        }    
                        displayBanner();                                    
                        Console.WriteLine("Your guess: " + guessArray[0] + markings[0] + " " + guessArray[1] + markings[1] + " " +  guessArray[2] + markings[2] + " " +  guessArray[3] + markings[3] + " Guesses remaining: " + (10-attempts));
                        Console.WriteLine();
                    }                                                            
                } else {
                    Console.WriteLine("Please enter 4 digit numbers only.");
                }
            }
        }
        public static void displayBanner()
        {
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║             M A S T E R M I N D            ║");
                Console.WriteLine("║                                            ║");
                Console.WriteLine("║             type \"stop\" to quit            ║");
                Console.WriteLine("║     - = correct number, wrong position     ║");
                Console.WriteLine("║    + = correct number, correct position    ║");
                Console.WriteLine("║       a blank is an incorrect number       ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.WriteLine("Guess the four digit number. Each digit is between 1 and 6");
        }
    }
}
