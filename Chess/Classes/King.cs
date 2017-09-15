using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    /// <summary>
    /// A Representation of a King on a chess game
    /// </summary>
    class King : Piece
    {
        public King(string color) : base(color, "K")
        {
            this.Value = Int32.MaxValue;
        }

        public King(string color, int X, int Y) : base(color, "K", X , Y)
        {
            this.Value = Int32.MaxValue;
        }

        public override List<int[,]> GetMoves()
        {
            List<int[,]> moves = new List<int[,]>();
            int[,] move = new int[1, 2];
            move[0, 0] = X + 1;
            move[0, 1] = Y + 1;
            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X - 1;
            move[0, 1] = Y - 1;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X + 1;
            move[0, 1] = Y - 1;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X - 1;
            move[0, 1] = Y + 1;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X;
            move[0, 1] = Y - 1;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X - 1;
            move[0, 1] = Y;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X;
            move[0, 1] = Y + 1;

            moves.Add(move);

            move = new int[1, 2];
            move[0, 0] = X + 1;
            move[0, 1] = Y;

            moves.Add(move);

            return moves;
        }
    }
}
