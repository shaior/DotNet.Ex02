
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
        private string m_PlayerLastPawnState;
        

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

        public string PlayerPawnState
        {
            get
            {
                return m_PlayerLastPawnState;
            }
            set
            {
                m_PlayerLastPawnState = value;
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
