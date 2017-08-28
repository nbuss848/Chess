using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Classes
{
    /// <summary>
    /// A representation of the rook piece
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Default contructor for a rook
        /// </summary>
        /// <param name="color">The color of the rook</param>
        public Rook(string color):base(color, "R")
        {
            this.Value = 5;
        }

        public Rook(string color, int X, int Y) : base(color, "R",X,Y)
        {
            this.Value = 5;
        }

        public override List<int[,]> GetMoves()
        {
            List<int[,]> moves = new List<int[,]>();

            foreach (var item in base.Moves(Direction.Vertical))
            {
                moves.Add(item);
            }

            foreach (var item in base.Moves(Direction.Horizontal))
            {
                moves.Add(item);
            }

            return moves;
        }
    }
}