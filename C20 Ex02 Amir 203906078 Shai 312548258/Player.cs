
namespace C20_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        //private readonly ePawnType m_PlayerPawn;
        private string m_PlayerName;
        private string m_PlayerNumber;
        private int[] m_PlayerMove;
        private readonly string m_ComputerName = "CheckersMaster";
        private int m_Score;
        private string m_PlayerPawnType;

        public Player(string i_PlayerName , string i_pawnType)
        {
            this.m_PlayerName = i_PlayerName;
            this.m_PlayerPawnType = i_pawnType;
        }

        public string PawnType
        {
            get
            {
                return m_PlayerPawnType;
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
        public string ComputerName
        {
            get
            {
                return m_ComputerName;
            }
        }
      /*  public enum ePawnType
        {
            O = 0,
            X,
            Unassigned,
        }*/
    }
}
