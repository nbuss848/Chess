using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Knight : Piece
    {        
        public Knight(string color) : base(color, "N")
        {
            this.Value = 3;
        }
    }
}
