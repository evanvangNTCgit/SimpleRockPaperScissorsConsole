using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRockPaperScissorsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            int userWins = 0;
            int consoleWins = 0;

            do
            {
                /* 0 = loss
                 * 1 = draw
                 * 2 = win
                 */
                int gameplay = RockPaperScissors();

                if(gameplay == 0) 
                {
                    consoleWins++;
                }
                else 
                {
                    userWins++;
                }
                
                if (userWins >= 5) 
                {
                    Console.WriteLine("YOU WON!");
                    Console.WriteLine($"User wins: {userWins}");
                    Console.WriteLine($"Console wins: {consoleWins}");
                }
                else if (consoleWins >= 5) 
                {
                    Console.WriteLine("The console won");
                    Console.WriteLine($"User wins: {userWins}");
                    Console.WriteLine($"Console wins: {consoleWins}");
                }

            } while (userWins < 5 || consoleWins < 5);
        }

        public static int RockPaperScissors()
        {
            string[] playerChoices = { "ROCK", "PAPER", "SCISSORS"};

            Console.WriteLine("Rock Paper or Scissors?");

            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();

            if (playerChoices.Any(userInput.Contains))
            {
                userInput = userInput.ToUpper();
            }
            else
            {
                Console.WriteLine("Sorry you mistyped/chose an invalid option. Please try again.");
                RockPaperScissors();
            }

            Random cpuChoice = new Random();
            string consoleChoice = playerChoices[cpuChoice.Next(0,2)];



            return playerWinCheck(userInput, consoleChoice);
        }

        public static int playerWinCheck(string playerInput, string cpuInput) 
        {
            int playerChoice = AssignIntToChoice(playerInput);
            int cpuChoice = AssignIntToChoice(cpuInput);

            /*
             * Rock = 0
             * Paper = 1
             * Scissor = 2
             * */
            if ((playerChoice == 0 && cpuChoice == 1) || (playerChoice == 1 && cpuChoice == 2) || (playerChoice == 2 && cpuChoice == 0)) 
            {
                return 0;
            }
            else if ((playerChoice == cpuChoice))
            {
                return 1;
            }
            else if ((playerChoice == 0 && cpuChoice == 2) || (playerChoice == 1 && cpuChoice == 0) || (playerChoice == 2 && cpuChoice == 1)) 
            {
                return 2;
            }
            else
            {
                throw new Exception("INVALID INPUT FOR EITHER CPU OR PLAYER");
            }
        }

        // Implementing this method because I did not feel like typing out strings for all the invidual scenarios haha.
        public static int AssignIntToChoice(string input) 
        {
            if (input == "ROCK") 
            {
                return 1;
            }
            else if (input == "PAPER") 
            {
                return 2;
            }
            else if (input == "SCISSORS")
            {
                return 3;
            }
            else 
            {
                throw new Exception("INVALID OPTION");
            }
        }
    }
}
