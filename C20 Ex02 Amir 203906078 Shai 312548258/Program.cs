using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C20_Ex02
{
    class Program
    {

        public static string GetUserName()
        {
            Console.WriteLine("Welcome to The Checkers Game!");
            string userName = string.Empty;
            bool checkUserName = true;

            while (checkUserName)
            {
                Console.WriteLine("Please Enter your Name (without spaces): ");
                userName = Console.ReadLine();

                if (userName.Length > 20)
                {
                    Console.WriteLine("The name provided is longer than 20 characters. Try again");
                    continue;
                }
                else if (userName.Contains(" "))
                {
                    Console.WriteLine("Please provide a string without spaces. Try again.");
                    continue;
                }
                else
                {
                    checkUserName = false;
                }
            }

            return userName;
        }

        public static int GetBoardSizeFromUser()
        {
            string boardSizeFromUser = string.Empty;
            int integerBoardSize = 0;
            Console.WriteLine("Choose your game board size.");
            Console.WriteLine("You can type 6 for (6x6), 8 for (8x8) or 10 for (10x10): ");
            bool boardSizeInputCheck = true;

            while (boardSizeInputCheck)
            {
                boardSizeFromUser = Console.ReadLine();
                bool isBoardSizeInteger = int.TryParse(boardSizeFromUser, out integerBoardSize);
                if (integerBoardSize != 6 && integerBoardSize != 8 && integerBoardSize != 10)
                {
                    Console.WriteLine("Wrong size. Please choose 6, 8 or 10.");
                    continue;
                }

                boardSizeInputCheck = false;
            }

            return integerBoardSize;
        }

        public static void Main()
        {
           
            string name = GetUserName();
            int boardSize = GetBoardSizeFromUser();
            GameBoard b = new GameBoard(boardSize);

            GameBoard.PrintBoard(boardSize);
            Console.WriteLine(boardSize);


        }
    }
}
