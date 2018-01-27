using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class BoardFactor
    {
        private object[,] _board;

        public BoardFactor()
        {
            _board = new object[8,8];
        }

        //public _board { get; set; }
    }
}
