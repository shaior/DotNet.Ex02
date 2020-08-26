using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex02_Amir_203906078_Shai_312548258
{
    public class Player
    {
        
        private string m_PlayerName;
        private string m_PlayerNumber;

        
        public Player(string i_PlayerName)
        {
            this.m_PlayerName = i_PlayerName;
        }
        public string PlayerNumber {
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

    }
}
