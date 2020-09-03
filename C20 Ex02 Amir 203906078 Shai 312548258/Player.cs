namespace C20_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        public static readonly string r_ComputerName = "ChckersMaster";
        private string m_PlayerName;
        private string m_PlayerNumber;
        private int[] m_PlayerMove;
        private int m_PlayerScore = 0;
        private string m_PawnType;
        private string m_CapturedPawn;
        private bool m_IsAbleToCapture = false;
        private int m_KingsCount = 0;
        private bool m_IsKing = false;


        public Player(string i_PlayerName , string i_pawnType)
        {
            this.m_PlayerName = i_PlayerName;
            this.m_PawnType = i_pawnType;
        }

        
        public int PlayerScore
        {
            get
            {
                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore = value;
            }
        }

        public string PawnType
        {
            get
            {
                return m_PawnType;
            }
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
        public string CapturedPawn
        {
            get
            {
                return m_CapturedPawn;
            }

            set
            {
                m_CapturedPawn = value;
            }
        }
        public bool IsAbleToCapture
        {
            get
            {
                return m_IsAbleToCapture;
            }

            set
            {
                m_IsAbleToCapture = value;
            }
        }
        public int KingsCount
        {
            get
            {
                return m_KingsCount;
            }

            set
            {
                m_KingsCount = value;
            }
        }
        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }

            set
            {
                m_IsKing = value;
            }
        }
    }
 
}

