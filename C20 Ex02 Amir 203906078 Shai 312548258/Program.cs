using System.Collections.Generic;
using System.Linq;

namespace C20_Ex02
{
    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
        /// <summary>
        /// gets board size from user.
        /// </summary>
        /// <returns> int size of board.</returns>
        public static int GetBoardSizeFromUser()
        {
            string boardSizeFromUser = string.Empty;
            int integerBoardSize = 0;
            Console.WriteLine("Choose board size: ");
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

        /// <summary>
        /// check how many players.
        /// </summary>
        /// <returns> int 1 if vs a friend, 0 if vs computer.</returns>
        public static int CheckHowManyPlayers()
        {
            bool checkAgainHowManyPlayers = true;
            string resultGamePartner = string.Empty;
            while (checkAgainHowManyPlayers)
            {
                string vsFriendOrVsComputer = string.Format(
                    "Are you going to play against a friend, or against the computer?" + Environment.NewLine +
                    "Against a friend - type 1" + Environment.NewLine +
                    "Against 'CheckersMaster' (Computer) - type 0" + Environment.NewLine);
                Console.WriteLine(vsFriendOrVsComputer);

                resultGamePartner = Console.ReadLine();
                int i_numberOfParticipants;
                bool successConvertingToInt = int.TryParse(resultGamePartner, out i_numberOfParticipants);
                if (successConvertingToInt)
                {
                    if (i_numberOfParticipants == 1 || i_numberOfParticipants == 0)
                    {
                        checkAgainHowManyPlayers = false;
                        break;
                    }
                    else
                    {
                        string valueError =
                            string.Format("Wrong value was inserted, please try again!" + Environment.NewLine);
                        Console.WriteLine(valueError);
                        continue;
                    }
                }
                else
                {
                    string valueError = string.Format("Please enter 0 or 1 only, try again!" + Environment.NewLine);
                    Console.WriteLine(valueError);
                    continue;
                }
            }

            return int.Parse(resultGamePartner);
        }

        /// <summary>
        /// getting player name.
        /// </summary>
        /// <returns>string player name</returns>
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

        public static string GetComputerMoves2(GameBoard i_Board)
        {
            GameBoard.getBoardEmptyCells(i_Board);
            string computerMove = string.Empty;
            Random rnd = new Random();

            
            
            bool keepCheckForComputerMove = true;
            while (keepCheckForComputerMove)
            {
                int firstLetter = rnd.Next(0, i_Board.BoardSize - 1);
                int secondLetter = rnd.Next(0, i_Board.BoardSize - 1);
                int thirdLetter = rnd.Next(0, i_Board.BoardSize - 1);
                int fourthLetter = rnd.Next(0, i_Board.BoardSize - 1);
                if (i_Board.BoardEmptyCells[thirdLetter, fourthLetter] == 1
                    && i_Board.BoardEmptyCells[firstLetter,secondLetter] == 0
                    && Math.Abs(firstLetter - thirdLetter) == 1 && Math.Abs(secondLetter - fourthLetter) == 1 )
                {
                    computerMove = string.Format("{0}{1}>{2}{3}", (char)(firstLetter + 65), (char)(secondLetter + 97), (char)(thirdLetter + 65), (char)(fourthLetter + 97));
                    keepCheckForComputerMove = false;
                }
                else
                {
                    Console.WriteLine("check again");
                    continue;
                    
                }
            }

            return computerMove;
        }

        /// <summary>
        /// generate computer moves.
        /// </summary>
        /// <param name="i_BoardSize"> size of board.</param>
        /// <returns>string computer moves.</returns>
        public static string GetComputerMoves(int i_BoardSize)
        {
            char i_stoppingLetter;
            if (i_BoardSize == (int)GameBoard.eBoardSize.SixBySix)
            {
                i_stoppingLetter = 'F';
            }
            else if (i_BoardSize == (int)GameBoard.eBoardSize.EightByEight)
            {
                i_stoppingLetter = 'H';
            }
            else
            {
                i_stoppingLetter = 'J';
            }
            
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

        /// <summary>
        /// swap the array indexes.
        /// </summary>
        /// <param name="i_Array"> gets array to swap.</param>
        public static void swapArrayIndexes(ref int[] i_Array)
        {
            int firstIndexHolder = i_Array[1];
            i_Array[1] = i_Array[0];
            i_Array[0] = firstIndexHolder;
            int secondIndexHolder = i_Array[3];
            i_Array[3] = i_Array[2];
            i_Array[2] = secondIndexHolder;
        }

        /// <summary>
        /// convert the player input to indexes.
        /// </summary>
        /// <param name="i_PlayerInput"> the input of the player.</param>
        /// <returns>int array of indexes.</returns>
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

        /// <summary>
        /// check input by regex.
        /// </summary>
        /// <param name="userInputRegex"> relevant regex.</param>
        /// <returns>gets and check the user input by regex.</returns>
        public static string CheckInputByRegex(Regex userInputRegex)
        {
            string i_PlayerInput = string.Empty;
            bool isInputOk = false;
            while (!isInputOk)
            {
                Console.Write("Make Your Move (format: Gf>He) (or press Q to quit the game): ");
                i_PlayerInput = Console.ReadLine();
                if (userInputRegex.IsMatch(i_PlayerInput))
                {
                    isInputOk = true;
                    break;
                }
                else if (i_PlayerInput.ToUpper() == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("input is not ok, try again!");
                    continue;
                }
            }

            return i_PlayerInput;
        }

        /// <summary>
        /// gets player move.
        /// </summary>
        /// <param name="i_BoardSize">size of board.</param>
        /// <returns>string player move.</returns>
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

        /// <summary>
        /// Checks player move.
        /// </summary>
        /// <param name="i_PlayerMove"> array of player moves.</param>
        /// <param name="i_Board">board.</param>
        /// <param name="i_Player">player.</param>
        /// <returns> true if player move is ok.</returns>
        public static bool CheckPlayerMove(GameBoard i_Board, Player i_Player)
        {
            bool isMoveOk = false;
            bool forwardMoveIndicator = i_Player.PlayerMove[1] == i_Player.PlayerMove[3];
            bool sideMoveIndicator = i_Player.PlayerMove[0] == i_Player.PlayerMove[2];
            int diagonalMove = i_Player.PlayerMove[0] - i_Player.PlayerMove[2];
            int diagonalAndSideMove = Math.Abs(i_Player.PlayerMove[1] - i_Player.PlayerMove[3]);
            bool isKing = CheckIfCurrentPawnIsKing(i_Player.PlayerMove, i_Board);
            if (isKing)
            {
                i_Player.IsKing = true;
            }
            bool isMovingOtherPlayerPawn = (i_Board.Board[i_Player.PlayerMove[0], i_Player.PlayerMove[1]]).Trim() != i_Player.PawnType;
            bool isDestinationSlotEmpty = i_Board.Board[i_Player.PlayerMove[2], i_Player.PlayerMove[3]] == GameBoard.k_EmptySlot;
            if (!isMoveOk)
            {
                if (isMovingOtherPlayerPawn)
                {
                    if (i_Board.Board[i_Player.PlayerMove[0], i_Player.PlayerMove[1]].Trim() == Pawn.KingO &&
                        i_Player.PawnType == Pawn.PawnO && diagonalAndSideMove == 1 && isDestinationSlotEmpty) 
                    {
                        isMoveOk = true;
                    }
                    else if (i_Board.Board[i_Player.PlayerMove[0], i_Player.PlayerMove[1]].Trim() == Pawn.KingX &&
                             i_Player.PawnType == Pawn.PawnX && diagonalAndSideMove == 1 && isDestinationSlotEmpty)
                    {
                        isMoveOk = true;
                    }
                    else
                    {
                        if (i_Player.PlayerName == Player.r_ComputerName)
                        {
                            isMoveOk = false;
                        }
                        else
                        {
                            isMoveOk = false;
                            Console.WriteLine("You can't move the opponent's pawn, try again!" + Environment.NewLine);
                        }
                        
                    }
                }
                bool isAbleToCapture = CheckCapturePossibility(i_Board, i_Player);
                if (i_Board.Board[i_Player.PlayerMove[0], i_Player.PlayerMove[1]] == GameBoard.k_EmptySlot)
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("You can't make an empty move, try again!" + Environment.NewLine);
                    }
                    
                }
                else if (forwardMoveIndicator)
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("You can't make forward or backward moves, try again! " + Environment.NewLine);
                    }
                    
                }
                else if (sideMoveIndicator)
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("You can't make side moves, try again! " + Environment.NewLine);
                    }
                    
                }
                else if (!isDestinationSlotEmpty)
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("This slot is taken, try again! " + Environment.NewLine);
                    }
                   
                }
                else if (diagonalAndSideMove > 1 && diagonalMove != 2 && !isMovingOtherPlayerPawn && !isAbleToCapture)
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("Move is illegal!, try again! " + Environment.NewLine);
                    }
                    
                }
                else if ((isKing && diagonalMove == 1) && diagonalAndSideMove == 1 
                         || (isKing && diagonalMove == -1) && diagonalAndSideMove == 1 
                           || isAbleToCapture && diagonalAndSideMove == 1)
                {
                    isMoveOk = true;
                }
                else if ((diagonalMove == 1 && i_Player.PawnType == Pawn.PawnX) && !isMovingOtherPlayerPawn ||
                         (diagonalMove == -1 && i_Player.PawnType == Pawn.PawnO) && !isMovingOtherPlayerPawn || isAbleToCapture && !isMovingOtherPlayerPawn)
                {
                    isMoveOk = true;
                }
                else
                {
                    if (i_Player.PlayerName == Player.r_ComputerName)
                    {
                        isMoveOk = false;
                    }
                    else
                    {
                        isMoveOk = false;
                        Console.WriteLine("Move is illegal!, try again! " + Environment.NewLine);
                    }
                    
                }
            }

            return isMoveOk;
        }

    

        /// <summary>
        /// checks the computer moves.
        /// </summary>
        /// <param name="i_PlayerMove">array of moves.</param>
        /// <param name="i_Board">board.</param>
        /// <param name="i_Player">player.</param>
        /// <returns>bool if moves are ok.</returns>
        //public static bool CheckComputerMove(int[] i_PlayerMove, GameBoard i_Board, Player i_Player)
        //{
        //    bool isMoveOk = false;
            
        //    bool forwardMoveIndicator = i_PlayerMove[1] == i_PlayerMove[3];
        //    bool sideMoveIndicator = i_PlayerMove[0] == i_PlayerMove[2];
        //    int diagonalMove = Math.Abs(i_PlayerMove[0] - i_PlayerMove[2]);
           
        //    int diagonalAndSideMove = Math.Abs(i_PlayerMove[1] - i_PlayerMove[3]);
        //    string emptySlot = "   ";
        //    bool isDestinationSlotEmpty = i_Board.Board[i_PlayerMove[2], i_PlayerMove[3]] == emptySlot;
        //    bool isMovingOtherPlayerPawn = (i_Board.Board[i_PlayerMove[0], i_PlayerMove[1]]).Trim() != i_Player.PawnType;
        //    if (!isMoveOk)
        //    {
        //        if (isMovingOtherPlayerPawn)
        //        {
        //            isMoveOk = false;
        //        }
        //        else
        //        {
        //            bool isAbleToCapture = CheckCapturePossibility(i_Board, i_Player);

        //            // TODO check how to implement random eating.

        //            if (i_Board.Board[i_PlayerMove[0], i_PlayerMove[1]] == emptySlot)
        //            {
        //                isMoveOk = false;
        //            }
        //            else if (forwardMoveIndicator)
        //            {
        //                isMoveOk = false;
        //            }
        //            else if (sideMoveIndicator)
        //            {
        //                isMoveOk = false;
        //            }
        //            else if (!isDestinationSlotEmpty)
        //            {
        //                isMoveOk = false;
        //            }
        //            else if (diagonalAndSideMove == 2 && diagonalMove != 2 && !isMovingOtherPlayerPawn && !isAbleToCapture)
        //            {
        //                isMoveOk = false;
        //            }
        //            else if (diagonalMove == 1 && diagonalAndSideMove == 1 || isAbleToCapture && diagonalAndSideMove == 2 && diagonalMove == 2 && isDestinationSlotEmpty)
        //            {
                        
        //                isMoveOk = true;
        //            }
        //        }
        //    }

        //    return isMoveOk;
        //}

        /// <summary>
        /// check if pawn is king.
        /// </summary>
        /// <param name="i_playerMove"> array of player moves.</param>
        /// <param name="i_Board">board.</param>
        /// <returns>bool if current pawn is king.</returns>
        public static bool CheckIfCurrentPawnIsKing(int[] i_playerMove, GameBoard i_Board)
        {
            bool isKing = false;
            string startingIndexPawnType = i_Board.Board[i_playerMove[0], i_playerMove[1]];
            if (startingIndexPawnType.Trim() == Pawn.KingX || startingIndexPawnType.Trim() == Pawn.KingO)
            {
                isKing = true;
            }

            return isKing;
        }

        /// <summary>
        /// checks the capture possiblity.
        /// </summary>
        /// <param name="i_PlayerMove">array of moves.</param>
        /// <param name="i_Board">board.</param>
        /// <param name="i_Player">layer.</param>
        /// <returns>bool true if capture is true. </returns>
        public static bool CheckCapturePossibility(GameBoard i_Board, Player i_Player)
        {
            string pawnO = Pawn.PawnO;
            string pawnX = Pawn.PawnX;
            bool checkIfAbleToCapture = false;
            int firstIndexOfDiagonal = 0;
            int secondIndexOfDiagonal = 0;
            bool leftDirectionForward = (i_Player.PlayerMove[0] - i_Player.PlayerMove[2] == 2) && (i_Player.PlayerMove[1] - i_Player.PlayerMove[3] == 2);
            bool rightDirectionForward = (i_Player.PlayerMove[0] - i_Player.PlayerMove[2] == 2) && (i_Player.PlayerMove[3] - i_Player.PlayerMove[1] == 2);
            bool leftDirectionDown = (i_Player.PlayerMove[2] - i_Player.PlayerMove[0] == 2) && (i_Player.PlayerMove[1] - i_Player.PlayerMove[3] == 2);
            bool rightDirectionDown = (i_Player.PlayerMove[2] - i_Player.PlayerMove[0] == 2) && (i_Player.PlayerMove[3] - i_Player.PlayerMove[1] == 2);
            //bool eatingRight = i_PlayerMove[1] < i_PlayerMove[3] == true;
            //bool eatingLeft = i_PlayerMove[1] > i_PlayerMove[3] == true;

            if (i_Player.PawnType == pawnX && leftDirectionForward)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] - 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] - 1);
            }
            else if(i_Player.PawnType == pawnX && leftDirectionDown && i_Player.IsKing == true)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] + 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] - 1);
            }
            else if (i_Player.PawnType == pawnX && rightDirectionForward)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] - 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] + 1);
            }
            else if (i_Player.PawnType == pawnX && rightDirectionDown && i_Player.IsKing == true)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] + 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] + 1);
            }

            // k_pawnO
            else if (i_Player.PawnType == pawnO && leftDirectionForward && i_Player.IsKing == true)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] - 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] - 1);
            }
            else if (i_Player.PawnType == pawnO && leftDirectionDown)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] + 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] - 1);
            }
            else if (i_Player.PawnType == pawnO && rightDirectionForward && i_Player.IsKing == true)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] - 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] + 1);
            }
            else if (i_Player.PawnType == pawnO && rightDirectionDown)
            {
                firstIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[0] + 1);
                secondIndexOfDiagonal = Math.Abs(i_Player.PlayerMove[1] + 1);
            }

            if (i_Board.Board[i_Player.PlayerMove[2], i_Player.PlayerMove[3]] ==
                i_Board.Board[firstIndexOfDiagonal, secondIndexOfDiagonal])
            {
                checkIfAbleToCapture = false;
            }
            else if (i_Board.Board[firstIndexOfDiagonal, secondIndexOfDiagonal] != GameBoard.k_EmptySlot &&
                     (i_Board.Board[firstIndexOfDiagonal, secondIndexOfDiagonal]).Trim() != i_Player.PawnType)
            {
                if (i_Board.Board[i_Player.PlayerMove[2], i_Player.PlayerMove[3]] == GameBoard.k_EmptySlot)
                {
                    Console.WriteLine("Able to capture!");
                    i_Player.CapturedPawn = (i_Board.Board[firstIndexOfDiagonal, secondIndexOfDiagonal]).Trim();
                    UpdatePlayerScore(i_Player);
                    i_Board.Board[firstIndexOfDiagonal, secondIndexOfDiagonal] = GameBoard.k_EmptySlot;
                    checkIfAbleToCapture = true;
                }
            }

            return checkIfAbleToCapture;
        }

        public static void UpdatePlayerScore(Player i_Player)
        {
            if (i_Player.CapturedPawn == Pawn.KingO || i_Player.CapturedPawn == Pawn.KingX)
            {
                i_Player.PlayerScore += 4;
            }
            else
            {
                i_Player.PlayerScore += 1;
            }
        }

        /// <summary>
        /// make moves.
        /// </summary>
        /// <param name="i_MovesToMake">moves to make array </param>
        /// <param name="i_Board1">ref to board.</param>
        public static void MakeMoves(int[] i_MovesToMake, ref GameBoard i_Board1)
        {
            i_Board1.Board[i_MovesToMake[2], i_MovesToMake[3]] = i_Board1.Board[i_MovesToMake[0], i_MovesToMake[1]];
            i_Board1.Board[i_MovesToMake[0], i_MovesToMake[1]] = GameBoard.k_EmptySlot;
        }

        /// <summary>
        /// show game results.
        /// </summary>
        /// <param name="i_Player1">player.</param>
        /// <param name="i_Opponent">opponenet.</param>
        public static void ShowGameResults(Player i_Player1, Player i_Opponent)
        {
            Console.WriteLine(string.Format("{0}'s score: {1} ", i_Player1.PlayerName, i_Player1.PlayerScore));
            Console.WriteLine(string.Format("{0}'s score: {1} ", i_Opponent.PlayerName, i_Opponent.PlayerScore));
            if (i_Player1.PlayerScore > i_Opponent.PlayerScore)
            {
                Console.WriteLine(string.Format("{0} is the winner!", i_Player1.PlayerName));
            }
            else if (i_Player1.PlayerScore < i_Opponent.PlayerScore)
            {
                Console.WriteLine(string.Format("{0} is the winner!", i_Opponent.PlayerName));
            }

            // even
            else
            {
                Console.WriteLine(string.Format("There is a tie!"));
            }
        }

        /// <summary>
        /// choose opponent.
        /// </summary>
        /// <param name="pawnX"> opponent will always be X.</param>
        /// <returns>player object.</returns>
        public static Player ChooseOpponent(string pawnX)
        {
            Player opponent;
            if (CheckHowManyPlayers() == 1)
            {
                Console.WriteLine("Player 2: ");
                opponent = new Player(GetPlayerName(), pawnX);
            }
            else
            {
                opponent = new Player(Player.r_ComputerName, pawnX);
            }

            return opponent;
        }


        /// <summary>
        /// play turn.
        /// </summary>
        /// <param name="i_Player">player to play.</param>
        /// <param name="i_Board">board.</param>
        /// <returns>bool.</returns>
        public static bool PlayTurn(Player i_Player, GameBoard i_Board)
        {
            bool playerTurn = true;
            string playerMoves;
            bool continueGame = true;
            Console.WriteLine(string.Format("{0}'s turn ({1}): ", i_Player.PlayerName, i_Player.PawnType));
            while (playerTurn)
            {
                bool isMoveOk = true;
                if (i_Player.PlayerName == Player.r_ComputerName)
                {
                    //Console.WriteLine("CheckersMaster is Thinking...");
                    playerMoves = GetComputerMoves(i_Board.BoardSize);
                    //playerMoves = GetComputerMoves2(i_Board);
                    i_Player.PlayerMove = ConvertInputLettersToIndexes(playerMoves);
                    //isMoveOk = CheckComputerMove(i_Player.PlayerMove, i_Board, i_Player);
                    isMoveOk = CheckPlayerMove(i_Board, i_Player);
                    // tODO VErify that if the computer is able to eat it must
                }
                else
                {
                    playerMoves = GetPlayerMoves(i_Board.BoardSize);
                    if (playerMoves.ToUpper() == "Q")
                    {
                        continueGame = false;
                        break;
                    }
                    i_Player.PlayerMove = ConvertInputLettersToIndexes(playerMoves);
                    isMoveOk = CheckPlayerMove(i_Board, i_Player);
                }

                if (!isMoveOk)
                {
                    continue;
                }
                else
                {
                    //Ex02.ConsoleUtils.Screen.Clear();
                    MakeMoves(i_Player.PlayerMove, ref i_Board);

                    //TODO check if able to eat again and then do again

                    bool isPossibleToBecomeKing = Pawn.CheckKingOpportunity(i_Board, i_Player);
                    if (isPossibleToBecomeKing)
                    {
                        MakeKing(ref i_Board,i_Player);
                    }

                    GameBoard.PrintBoard(i_Board.BoardSize, i_Board.Board);
                    Console.WriteLine(string.Format("{0}'s move was: {1}", i_Player.PlayerName, playerMoves));
                    playerTurn = false;
                }
            }

            return continueGame;
        }

        /// <summary>
        /// makes king.
        /// </summary>
        /// <param name="io_Board">board.</param>
        /// <param name="i_Player">player.</param>
        public static void MakeKing(ref GameBoard io_Board, Player i_Player)
        {
            string kingXPawn = string.Format(" {0} ", Pawn.KingX);
            string kingOPawn = string.Format(" {0} ", Pawn.KingO);
            string playerPawnType = i_Player.PawnType;
            if (playerPawnType == Pawn.PawnO)
            {
                io_Board.Board[i_Player.PlayerMove[2], i_Player.PlayerMove[3]] = kingOPawn;
                i_Player.KingsCount++;
            }
            else if (playerPawnType == Pawn.PawnX)
            {
                io_Board.Board[i_Player.PlayerMove[2], i_Player.PlayerMove[3]] = kingXPawn;
                i_Player.KingsCount++;
            }
        }

        /// <summary>
        /// checks if user quit the game.
        /// </summary>
        /// <param name="i_continueGame">continue?</param>
        /// <param name="i_Player1">player.</param>
        /// <param name="i_Player2">player.</param>
        /// <returns>true if quit game.</returns>
        public static bool CheckIfUserQuitGame(bool i_continueGame, Player i_Player1, Player i_Player2)
        {
            bool quitGame = false;
            if (!i_continueGame)
            {
                ShowGameResults(i_Player1, i_Player2);
                quitGame = true;
            }

            return quitGame;
        }

        public static void CheckForWinner(GameBoard i_Board , Player i_Player , Player i_Opponent)
        {
            int numberOfPawnX = 0;
            int numberOfPawnO = 0;
            

            for (int i = 0; i < i_Board.BoardSize; i++)
            {
                for (int j = 0; j < i_Board.BoardSize; j++)
                {
                    if (i_Board.Board[i, j].Trim() == Pawn.PawnO)
                    {
                        numberOfPawnO += 1;
                    }
                    else if (i_Board.Board[i, j].Trim() == Pawn.PawnX)
                    {
                        numberOfPawnX += 1;
                    }
                }

                if (numberOfPawnO == 0)
                {
                    int opponentWinScore = i_Opponent.PlayerScore - i_Player.PlayerScore;
                    Console.WriteLine(string.Format("{0} is the winner", i_Opponent.PlayerName));
                    Console.WriteLine(string.Format("{0} score is {1}"),i_Opponent.PlayerName,opponentWinScore);
                }
                else if (numberOfPawnX == 0)
                {
                    int playerWinScore = i_Player.PlayerScore - i_Opponent.PlayerScore; 
                    Console.WriteLine(string.Format("{0} is the winner", i_Player.PlayerName));
                    Console.WriteLine(string.Format("{0} score is {1}"), i_Player.PlayerName, playerWinScore);
                }
            }
        }

        /// <summary>
        /// try game.
        /// </summary>
        public static void tryGame()
        {
            Console.WriteLine("Welcome to Checkers game!");
            // string playerMoves = string.Empty;
            string pawnO = Pawn.PawnO;
            string pawnX = Pawn.PawnX;
            bool continueGame = true;
            while (continueGame)
            {
                Player player1 = new Player(GetPlayerName(), pawnO);
                GameBoard board1 = new GameBoard(GetBoardSizeFromUser());
                //board1.BoardEmptyCells = new int[board1.BoardSize, board1.BoardSize];
                GameBoard.InitializeBoard(board1.BoardSize, board1.Board);
                Player opponent = ChooseOpponent(pawnX);
                GameBoard.PrintBoard(board1.BoardSize, board1.Board);
                bool playing = true;
                bool player1Turn = true;
                while (playing)
                {
                    if (player1Turn)
                    {
                        continueGame = PlayTurn(player1, board1);
                        
                        player1Turn = false;
                        if (CheckIfUserQuitGame(continueGame,player1,opponent))
                        {
                            break;
                        }
                    }
                    else
                    {
                        continueGame = PlayTurn(opponent, board1);
                        
                        player1Turn = true;
                        if (CheckIfUserQuitGame(continueGame, player1, opponent))
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            tryGame();
        }
    }
}
