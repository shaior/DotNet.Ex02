namespace C20_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pawn
    {
        private static readonly string r_PawnO = ((char)ePawns.O).ToString();
        private static readonly string r_PawnX = ((char)ePawns.X).ToString();
        private static readonly string r_KingO = ((char)ePawns.KingO).ToString();
        private static readonly string r_KingX = ((char)ePawns.KingX).ToString();
        private string m_PlayerPawnType;

        public Pawn(string i_PlayerPawn)
        {
            this.m_PlayerPawnType = i_PlayerPawn;
        }

        public string PawnType
        {
            get
            {
                return m_PlayerPawnType;
            }
        }

        public static string PawnX
        {
            get
            {
                return r_PawnX;
            }
        }

        public static string PawnO
        {
            get
            {
                return r_PawnO;
            }
        }

        public static string KingX
        {
            get
            {
                return r_KingX;
            }
        }

        public static string KingO
        {
            get
            {
                return r_KingO;
            }
        }

        /// <summary>
        /// Checks king oppotuirnity
        /// </summary>
        /// <param name="i_Board"></param>
        /// <param name="i_Player"></param>
        /// <returns> bool true if yes or false if not.</returns>
        public static bool CheckKingOpportunity(GameBoard i_Board, Player i_Player)
        {
            int size6LastRow = ((int)GameBoard.eBoardSize.SixBySix) - 1;
            int size8LastRow = ((int)GameBoard.eBoardSize.EightByEight) - 1;
            int size10LastRow = ((int)GameBoard.eBoardSize.TenByTen) - 1;
            int firstRow = 0;
            bool BecomeKing = false;
            int playerDestinationRowIndex = i_Player.PlayerMove[2];
            if (i_Player.PawnType == Pawn.r_PawnO)
            {
                if ((playerDestinationRowIndex == size6LastRow && 
                    i_Board.BoardSize == (int)GameBoard.eBoardSize.SixBySix)
                    || (playerDestinationRowIndex == size8LastRow &&
                    i_Board.BoardSize == (int)GameBoard.eBoardSize.EightByEight)
                    || (playerDestinationRowIndex == size10LastRow &&
                    i_Board.BoardSize == (int)GameBoard.eBoardSize.TenByTen))
                {
                    BecomeKing = true;
                }
            }
            else if (i_Player.PawnType == Pawn.r_PawnX && playerDestinationRowIndex == firstRow)
            {
                BecomeKing = true;
            }

            return BecomeKing;
        }

        public enum ePawns
        {
            KingX = 'K',
            KingO = 'U',
            X = 'X',
            O = 'O',
        }
    }
}