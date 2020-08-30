
namespace C20_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private readonly ePawnType m_PlayerPawn;
        private string m_PlayerName;
        private string m_PlayerNumber;
        private int[] m_PlayerMove;
        private readonly string m_ComputerName = "CheckersMaster";
        private int m_Score;

        public Player(string i_PlayerName , int i_pawnType)
        {
            this.m_PlayerName = i_PlayerName;
            this.m_PlayerPawn = (ePawnType)i_pawnType;
        }
        public string PlayerNumber
        {
            get
            {
                return m_PlayerNumber;
            }
            set
            {
                m_PlayerNumber = value;
            }

        }
        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
            set
            {
                m_PlayerName = value;
            }
        }
        public int[] PlayerMove
        {
            get
            {
                return m_PlayerMove;
            }
            set
            {
                m_PlayerMove = value;
            }
        }

        public string ComputerName
        {
            get
            {
                return m_ComputerName;
            }
        }

        enum ePawnType
        {
            O = 0,
            X,
            Unassigned,
        }

        /*
                public static void PrintBoard(int i_BoardSize, string i_PlayerName) // remove
                {
                    string pawnType = k_PawnO;
                    PrintLettersOnTop(i_BoardSize);
                    char startLetterPrinting = 'a';
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

                        printRowsSeparator(i_BoardSize);
                        PrintLetterOnSide(i_BoardSize, ref startLetterPrinting);
                        for (int j = 0; j < i_BoardSize; j++)
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
                    printRowsSeparator(i_BoardSize);
                    Console.WriteLine(string.Format("{0}'s turn:", i_PlayerName)); //TODO: check if it is ok here.. 
                }
            }*/
    }
}
