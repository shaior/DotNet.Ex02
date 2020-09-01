
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
        private string m_ComputerName;
        private int m_PlayerScore = 0;

        public Player(string i_PlayerName , string i_pawnType)
        {
            this.m_PlayerName = i_PlayerName;
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
     /*   public string ComputerName
        {
            get
            {
                return m_ComputerName;
            }

        }*/

      /*  public enum ePawnType
        {
            O = 0,
            X,
            Unassigned,
        }*/
    }
}
