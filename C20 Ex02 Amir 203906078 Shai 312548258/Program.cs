//using C20_Ex02_Amir_203906078_Shai_312548258;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace C20_Ex02
{
    class Program
    {
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

        public static int CheckHowManyPlayers()
        {
            bool checkAgainHowManyPlayers = true;
            string resultGamePartner = string.Empty;
            while (checkAgainHowManyPlayers)
            {
                string vsFriendOrVsComputer = string.Format("Are you going to play against a friend, or against the computer?" + Environment.NewLine +
               "against a friend - type 1" + Environment.NewLine +
               "against the computer - type 0" + Environment.NewLine);
                Console.WriteLine(vsFriendOrVsComputer);
                resultGamePartner = Console.ReadLine();
                if (int.Parse(resultGamePartner) == 1 || int.Parse(resultGamePartner) == 0)
                {
                    checkAgainHowManyPlayers = false;
                    break;
                }
                else
                {
                    string valueError = string.Format("Wrong value was inserted, please try again!" + Environment.NewLine);
                    Console.WriteLine(valueError);
                    continue;
                }
            }
            return int.Parse(resultGamePartner);
        }

        public static string GetPlayerName()
        {
            string userName = string.Empty;
            bool checkUserName = true;

            while (checkUserName)
            {
                Console.WriteLine("Please Enter player's Name (without spaces): ");
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

        public static void GetPlayerPicks(out string io_PlayerMove,int i_BoardSize)
        {   
            bool checkInput = true;
            io_PlayerMove = string.Empty;
            while (checkInput)
            {
                Console.WriteLine("Make Your Move: ");
                io_PlayerMove = Console.ReadLine();
                foreach (var letter in io_PlayerMove)
                {
                    if (char.IsDigit(letter))
                    {
                        Console.WriteLine("This input is not valid. Try Again");
                        continue;
                    }
                }

                if (io_PlayerMove.Length > 5)
                {
                    Console.WriteLine("This input is not valid. Try Again");
                    continue;
                }

                checkInput = false;
            }
        }
        

        

        public static void NewGame()
        {
            Console.WriteLine("Welcome to The Checkers Game!");
            string p1PlayerName = GetPlayerName();
            Player p1 = new Player(p1PlayerName);
            int boardSize = GetBoardSizeFromUser();
            int withOrWithOutPartner = CheckHowManyPlayers();
            if (withOrWithOutPartner == 1)
            {
                Console.WriteLine("Player 2:");
                string p2PlayerName = GetPlayerName();
                Player p2 = new Player(p2PlayerName);
            }
            GameBoard b = new GameBoard(boardSize);

            //every print board we will need to switch between the players names e.g Shai turn:
            GameBoard.PrintBoard(boardSize, p1PlayerName);
        }

        public static void Main()
        {
            //NewGame();
            string name = GetPlayerName();
            int size = GetBoardSizeFromUser();
            GameBoard board = new GameBoard(size);
            GameBoard.PrintBoard(size,name);  // need to remove the name and find other solution
            GameBoard.InitializeBoard(size,board.Board);

            Player p1 = new Player(name);
            string playerMove;

            GetPlayerPicks(out playerMove, size);
            p1.PlayerMove = playerMove;


        }
    }
}
