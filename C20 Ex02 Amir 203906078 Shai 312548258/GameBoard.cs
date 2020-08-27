
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex02
{
    class GameBoard
    {
        private int m_BoardSize = 0;
        private string[,] m_Board;
        public const string k_PawnO = " O ";
        public const string k_PawnX = " X ";

        public GameBoard(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_Board = new string[this.m_BoardSize,this.m_BoardSize];
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }

            set
            {
                m_BoardSize = value;
            }
        }
        public string[,] Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public static void InitializeBoard(int i_BoardSize , string[,] board)
        {
            string pawnType = k_PawnO;
            for (int i = 0; i < i_BoardSize; i++)
            {
                if (i == (i_BoardSize / 2) + 1)
                {
                    pawnType = k_PawnX;
                }
                else if (i == (i_BoardSize / 2) - 1 || i == (i_BoardSize / 2))
                {
                    pawnType = "   ";
                }

                for (int j = 0; j < i_BoardSize; j++)
                {
                    if ((i % 2) == 0)
                    {
                        if ((j % 2) != 0)
                        {
                            board[i, j] = pawnType;
                        }
                        else
                        {
                            board[i, j] = string.Empty;
                        }
                    }
                    else
                    {
                        if ((j % 2) == 0)
                        {
                            board[i, j] = pawnType;
                        }
                        else
                        {
                            board[i, j] = string.Empty;
                        }
                    }
                }

            }
        }

        public static void PrintLettersOnTop(int i_BoardSize)
        {
            char stopLetterPrinting;
            if (i_BoardSize == 6)
            {
                stopLetterPrinting = 'F';
            }
            else if (i_BoardSize == 8)
            {
                stopLetterPrinting = 'H';
            }
            else
            {
                stopLetterPrinting = 'J';
            }

            for (char letter = 'A'; letter <= stopLetterPrinting; letter++)
            {
                Console.Write(string.Format("   {0}",letter));
            }

            Console.Write(Environment.NewLine);
        }

        public static void PrintLetterOnSide(int i_BoardSize,ref char startLetterPrinting)
        {
            char stopLetterPrinting;
            if (i_BoardSize == 6)
            {
                stopLetterPrinting = 'f';
            }
            else if (i_BoardSize == 8)
            {
                stopLetterPrinting = 'h';
            }
            else
            {
                stopLetterPrinting = 'j';
            }

            if (startLetterPrinting <= stopLetterPrinting)
            {
                Console.Write(string.Format("{0}",startLetterPrinting));
                startLetterPrinting++;
            }
        }

        /// <summary>
        /// This method prints the game board.
        /// </summary>
        /// <param name="i_BoardSize">the board size represented by one digit</param>
        public static void PrintBoard(int i_BoardSize,string i_PlayerName)
        {
            string[,] arr = new string[i_BoardSize,i_BoardSize]; //not needed
            int rowLength = arr.GetLength(0); // not needed
            int colLength = arr.GetLength(1); //not needed
            string pawnType = k_PawnO;
            PrintLettersOnTop(i_BoardSize);
            char startLetterPrinting = 'a';
            for (int i = 0; i < rowLength; i++)
            {
                if (i == (rowLength / 2) + 1)
                {
                    pawnType = k_PawnX;
                }
                else if(i == (rowLength / 2) - 1 || i == (rowLength / 2))
                {
                    pawnType = "   ";
                }

                printRowsSeparator(rowLength);
                PrintLetterOnSide(i_BoardSize,ref startLetterPrinting);
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("|"));
                    if ((i % 2) == 0)
                    {
                        if ((j % 2) != 0)
                        {
                            Console.Write(string.Format("{0}", pawnType));
                        }
                        else
                        {
                            Console.Write(string.Format("   "));
                        }
                    }
                    else
                    {
                        if ((j % 2) == 0)
                        {
                            Console.Write(string.Format("{0}", pawnType));
                        }
                        else
                        {
                            Console.Write(string.Format("   "));
                        }
                    }
                }

                Console.Write(string.Format("|"));
                Console.Write(Environment.NewLine);
            }
            printRowsSeparator(rowLength);
            Console.WriteLine(string.Format("{0}'s turn:", i_PlayerName)); //TODO: check if it is ok here.. 
        }

        /// <summary>
        /// This method prints the rows separators.
        /// </summary>
        /// <param name="i_numberOfRows"> number of rows</param>
        private static void printRowsSeparator(int i_numberOfRows)
        {
            if (i_numberOfRows == 6)
            {
                Console.WriteLine(" =========================");
            }
            else if (i_numberOfRows == 8)
            {
                Console.WriteLine(" =================================");
            }
            else if (i_numberOfRows == 10)
            {
                Console.WriteLine(" =========================================");
            }
        }


        public enum eBoardSize 
        {
            SixBySix = 6,
            EightByEight = 8,
            TenByTen = 10,
        }
    }
}
