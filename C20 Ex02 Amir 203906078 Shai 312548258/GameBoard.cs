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
        public const string k_SoldierO = " O ";
        public const string k_SoldierX = " X ";

        public GameBoard(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
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

        /// <summary>
        /// This method prints the game board
        /// </summary>
        /// <param name="i_BoardSize">the board size represented by one digit</param>
        public static void PrintBoard(int i_BoardSize)
        {
            string[,] arr = new string[i_BoardSize,i_BoardSize];

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            string soldierType = k_SoldierO;

            for (int i = 0; i < rowLength; i++)
            {
                if (i == (rowLength / 2) + 1)
                {
                    soldierType = k_SoldierX;
                }
                else if(i == (rowLength / 2) - 1 || i == (rowLength / 2))
                {
                    soldierType = "   ";
                }

                printRowsSeparator(rowLength);
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("|"));
                    if ((i % 2) == 0)
                    {
                        if ((j % 2) != 0)
                        {
                            Console.Write(string.Format("{0}", soldierType));
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
                            Console.Write(string.Format("{0}", soldierType));
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
        }

        /// <summary>
        /// This method prints the rows separators.
        /// </summary>
        /// <param name="i_numberOfRows"> number of rows</param>
        private static void printRowsSeparator(int i_numberOfRows)
        {
            if (i_numberOfRows == 6)
            {
                Console.WriteLine("=========================");
            }
            else if (i_numberOfRows == 8)
            {
                Console.WriteLine("=================================");
            }
            else if (i_numberOfRows == 10)
            {
                Console.WriteLine("=========================================");
            }



        }
    }
}
