using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Queen : Piece
    {
        public Queen(string color) : base(color, "Q")
        {
            this.Value = 9;
        }
    }
}
