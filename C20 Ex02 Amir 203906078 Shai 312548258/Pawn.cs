using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex02_Amir_203906078_Shai_312548258
{
    class Pawn
    {
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

    }
}
