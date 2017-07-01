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
    }
}