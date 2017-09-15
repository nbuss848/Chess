using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Bishop : Piece
    {
        public Bishop(string color) : base(color, "B")
        {
            this.Value = 3;
        }

        public Bishop(string color, int X, int Y) : base(color, "B", X, Y)
        {
            this.Value = 3;
        }

        public override List<int[,]> GetMoves()
        {
            List<int[,]> moves = new List<int[,]>();
            foreach (var item in base.Moves(Direction.Diagonal))
            {
                moves.Add(item);
            }
            return moves;
        }
    }
}
