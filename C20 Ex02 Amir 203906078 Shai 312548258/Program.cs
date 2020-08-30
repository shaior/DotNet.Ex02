//using C20_Ex02_Amir_203906078_Shai_312548258;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Fare;
using Ex02.ConsoleUtils;

namespace C20_Ex02
{
    class Program
    {
        public static int GetBoardSizeFromUser()
        {
            string boardSizeFromUser = string.Empty;
            int integerBoardSize = 0;
            Console.WriteLine("Choose your game i_Board size.");
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

        public static string ComputerMoves(char i_stoppingLetter)
        {

            string computerMove = string.Empty;
            Random rnd = new Random();
            
            char firstLetter = (char)rnd.Next('A', i_stoppingLetter);
            char secondLetter = (char)rnd.Next('A', i_stoppingLetter);
            char thirdLetter = (char)rnd.Next('A', i_stoppingLetter);
            char FourthLetter = (char)rnd.Next('A', i_stoppingLetter);
            computerMove = computerMove + firstLetter.ToString().ToUpper()
                            + secondLetter.ToString().ToLower() + '>'
                            + thirdLetter.ToString().ToUpper()
                            + FourthLetter.ToString().ToLower();

            return computerMove;
        }
        public static void swapArrayIndexes(ref int[] i_Array)
        {
            int firstIndexHolder = i_Array[1];
            i_Array[1] = i_Array[0];
            i_Array[0] = firstIndexHolder;
            int secondIndexHolder = i_Array[3];
            i_Array[3] = i_Array[2];
            i_Array[2] = secondIndexHolder;
        }
        public static int[] ConvertInputLettersToIndexes(string i_PlayerInput)
        {
            int numberOfIndexes = 4;
            int j = 0;
            int[] convertedIndexes = new int[numberOfIndexes];
            foreach (var letter in i_PlayerInput)
            {
                if (letter == '>')
                {
                    continue;
                }
                else
                {
                    convertedIndexes[j] = char.ToUpper(letter) - 65;
                    j++;
                }
            }
            swapArrayIndexes(ref convertedIndexes);
            return convertedIndexes;
        }
        public static string CheckInputByRegex(Regex userInputRegex)
        {
            string i_PlayerInput = string.Empty;
            bool isInputOk = false;
            while (!isInputOk)
            {
                Console.WriteLine("Make Your Move (format: Gf>He): ");
                i_PlayerInput = Console.ReadLine();
                if (userInputRegex.IsMatch(i_PlayerInput))
                {
                    //Console.WriteLine("input is ok");
                    isInputOk = true;
                    break;
                }
                else
                {
                    Console.WriteLine("input is not ok, try again!");
                    continue;
                }
                // TODO: NEED TO ADD QUIT GAME STATEMENT(IF USER PRESS "Q")
            }
            return i_PlayerInput;
        }
        public static string GetPlayerMoves(int i_BoardSize)
        {
            string playerMove = string.Empty;
            if (i_BoardSize == (int)GameBoard.eBoardSize.SixBySix)
            {
                Regex userInputRegex = new Regex(@"^[A-F][a-f]>[A-F][a-f]");
                playerMove = CheckInputByRegex(userInputRegex);
            }
            else if (i_BoardSize == (int)GameBoard.eBoardSize.EightByEight)
            {
                Regex userInputRegex = new Regex(@"^[A-H][a-h]>[A-H][a-h]");
                playerMove = CheckInputByRegex(userInputRegex);
            }
            else
            {
                Regex userInputRegex = new Regex(@"^[A-Y][a-y]>[A-Y[a-y]");
                playerMove = CheckInputByRegex(userInputRegex);
            }
            return playerMove;
        }
        
        public static bool CheckPlayerMove(int[] i_PlayerMove, GameBoard i_Board)
        {
            bool isMoveEmpty = false;
            bool forwardMoveIndicator = i_PlayerMove[1] == i_PlayerMove[3];
            bool sideMoveIndicator = i_PlayerMove[0] == i_PlayerMove[2];
            int diagonalMove = Math.Abs(i_PlayerMove[0] - i_PlayerMove[2]);
            string emptySlot = "   ";
            if (!isMoveEmpty)
            {

                if (i_Board.Board[i_PlayerMove[0], i_PlayerMove[1]] == emptySlot)
                {
                    isMoveEmpty = false;
                    Console.WriteLine("You can't make an empty move, try again!" + Environment.NewLine);
                }
                else if (forwardMoveIndicator)
                {
                    isMoveEmpty = false;
                    Console.WriteLine("You can't make forward moves, try again! " + Environment.NewLine);
                }
                else if (sideMoveIndicator)
                {
                    isMoveEmpty = false;
                    Console.WriteLine("You can't make side moves, try again! " + Environment.NewLine);
                }
                else if(i_Board.Board[i_PlayerMove[2], i_PlayerMove[3]] != emptySlot)
                {
                    isMoveEmpty = false;
                    Console.WriteLine("This slot is taken, try again! " + Environment.NewLine);
                }
                else if (diagonalMove == 1)
                {
                    isMoveEmpty = true;
                }
            }
            return isMoveEmpty;

        }

        /// <summary>
        /// checks if there is opponent pawn that can be captured.
        /// </summary>
        /// <param name="i_PlayerMove"></param>
        /// <param name="i_Board"></param>
        public static void CheckCapturePossibility(int[] i_PlayerMove,GameBoard i_Board)
        {
            
        }

        //public static void NewGame()
        //{
        //    Console.WriteLine("Welcome to The Checkers Game!");
        //    string p1PlayerName = GetPlayerName();
        //    Player p1 = new Player(p1PlayerName);
        //    int boardSize = GetBoardSizeFromUser();
        //    int withOrWithOutPartner = CheckHowManyPlayers();
        //    if (withOrWithOutPartner == 1)
        //    {
        //        Console.WriteLine("Player 2:");
        //        string p2PlayerName = GetPlayerName();
        //        Player p2 = new Player(p2PlayerName);
        //    }
        //    GameBoard b = new GameBoard(boardSize);

        //    //every print i_Board we will need to switch between the players names e.g Shai turn:
        //    //GameBoard.PrintBoard(boardSize, p1PlayerName);
        //}
        public static void MakeMoves(int[] movesToMake, ref GameBoard board1)
        {
            board1.Board[movesToMake[2], movesToMake[3]] = board1.Board[movesToMake[0], movesToMake[1]];
            board1.Board[movesToMake[0], movesToMake[1]] = "   ";
        }

        public static void tryGame()
        {
            
            while (true)
            {
                int pawnO = 0;
                int pawnX = 1;
                GameBoard board1 = new GameBoard(GetBoardSizeFromUser());
                GameBoard.InitializeBoard(board1.BoardSize, board1.Board);
                GameBoard.PrintBoard(board1.BoardSize, board1.Board);
                
                Player p1 = new Player(GetPlayerName(),pawnO);
                string opponent;
                Player p2 = null;
                Player computerPlayer = null;
                if (CheckHowManyPlayers() == 1)
                {
                    Console.WriteLine("Player 2: ");
                    p2 = new Player(GetPlayerName(),pawnX);
                    opponent = "Player2";
                }
                else
                {
                    
                    computerPlayer = new Player(computerPlayer.ComputerName, pawnX);
                    opponent = "Computer";
                }

                bool playing = true;
                while (playing)
                {

                    bool player1Turn = true;
                    bool isMoveOk = true;
                    if (player1Turn)
                    {
                        p1.PlayerMove = ConvertInputLettersToIndexes(GetPlayerMoves(board1.BoardSize));
                        isMoveOk = CheckPlayerMove(p1.PlayerMove, board1);
                        if (!isMoveOk)
                        {
                            continue;
                        }

                        MakeMoves(p1.PlayerMove, ref board1);
                        GameBoard.PrintBoard(board1.BoardSize, board1.Board);
                        player1Turn = false;
                        
                    }
                    if (opponent == "Player2")
                    {
                        p2.PlayerMove = ConvertInputLettersToIndexes(GetPlayerMoves(board1.BoardSize));
                        isMoveOk = CheckPlayerMove(p2.PlayerMove, board1);
                        if (!isMoveOk)
                        {
                            continue;
                        }
                        MakeMoves(p2.PlayerMove, ref board1);
                        GameBoard.PrintBoard(board1.BoardSize, board1.Board);
                        player1Turn = true;
                    }
                    else
                    {
                        // TODO: NEED TO ADD COMPUTER RANDOM MOVES
                       // computerPlayer.PlayerMove = ConvertInputLettersToIndexes()
                    }

                }

               


            }
        }

        public static void Main()
        {
            //NewGame();
            string name = GetPlayerName();
            int size = GetBoardSizeFromUser();
            GameBoard board1 = new GameBoard(size);
            GameBoard.InitializeBoard(size, board1.Board);
            // board1.Board[3, 0] = board1.Board[5, 0];
            
            //GameBoard.PrintBoard(size,name, board1.Board);  // need to remove the name and find other solution
            //Ex02.ConsoleUtils.Screen.Clear();
            //Player p1 = new Player(name);

            bool isMoveOk = false;
            //int[] movesToMake = { };
            while (!isMoveOk)
            {
                string playerMove = GetPlayerMoves(size);
                //p1.PlayerMove = ConvertInputLettersToIndexes(playerMove);
                //isMoveOk = CheckPlayerMove(p1.PlayerMove, board1);
            }

            //MakeMoves(p1.PlayerMove, ref board1);
            //GameBoard.PrintBoard(size, name, board1.Board);
            string randomMove = ComputerMoves('H');
            Console.WriteLine(randomMove);

        }
    }
}
