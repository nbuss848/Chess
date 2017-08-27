using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Queen : Piece
    {
        private int _x;
        private int _y;

        public Queen(string color, int X, int Y) : base(color, "Q")
        {
            this.Value = 9;
            _x = X;
            _y = Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <example>
        ///     if queen is in 4,4 this should return
        ///         {5,5}, {6,6}, {7,7}, {3,3}, 
        ///         {2,2}, {1,1}, {0,0}, {5,3},
        ///         {6,2}, {7,1}, {3,5}, {2,6}, 
        ///         {1,7}
        /*
        0       1          2       3        4        5        6        7        
0    {0, 0} | {0, 1} | {0, 2} | {0, 3} | {0, 4} | {0, 5} | {0, 6} | {0, 7} | 
1    {1, 0} | {1, 1} | {1, 2} | {1, 3} | {1, 4} | {1, 5} | {1, 6} | {1, 7} | 
2    {2, 0} | {1, 2} | {2, 2} | {2, 3} | {2, 4} | {2, 5} | {2, 6} | {2, 7} | 
3    {3, 0} | {3, 1} | {3, 2} | {3, 3} | {3, 4} | {3, 5} | {3, 6} | {3, 7} |    
4    {4, 0} | {4, 1} | {4, 2} | {4, 3} | {4, 4} | {4, 5} | {4, 6} | {4, 7} |   
5    {5, 0} | {5, 1} | {5, 2} | {5, 3} | {5, 4} | {5, 5} | {5, 6} | {5, 7} |     
6    {6, 0} | {6, 1} | {6, 2} | {6, 3} | {6, 4} | {6, 5} | {6, 6} | {6, 7} |    
7    {7, 0} | {7, 1} | {7, 2} | {7, 3} | {7, 4} | {7, 5} | {7, 6} | {7, 7} |      
         */
        /// </example>
        public override List<int[,]> GetMoves()
        {
            List<int[,]> moves = new List<int[,]>();
            int[,] move = new int[1, 2];
            // Propagate upwards
            // start at x y and work upwards

            // GO LEFT
            for (int i = _y - 1; i >= 0; i--)
            {
                move = new int[1, 2];
                move[0, 0] = _x;
                move[0, 1] = i;
                moves.Add(move);
            }

            // GO RIGHT
            for (int i = _y + 1; i< 8; i++)
            {
                move = new int[1, 2];
                move[0, 0] = _x;
                move[0, 1] = i;
                moves.Add(move);
            }

            // GO DOWN
            for (int i = _x + 1; i < 8; i++)
            {
                move = new int[1, 2];
                move[0, 0] = i;
                move[0, 1] = _y;
                moves.Add(move);
            }

            // GO UP
            for (int i = _x - 1; i >= 0; i--)
            {
                move = new int[1, 2];
                move[0, 0] = i;
                move[0, 1] = _y;
                moves.Add(move);
            }

            // Calculate how many times we have to go to the right
            int RightSpace = 7 - _x;
            int LeftSpace = _x;

            // GO DOWN AND RIGHT
            for (int i = 1; i <= RightSpace; i++)
            {
                move = new int[1, 2];
                move[0, 0] = _x + i;
                move[0, 1] = _y + i;
                moves.Add(move);
            }

            // GO UP AND Right
            for (int i = 1; i <= RightSpace; i++)
            {
                move = new int[1, 2];
                move[0, 0] = _x + i;
                move[0, 1] = _y - i;
                moves.Add(move);
            }

            // GO DOWN AND LEFT
            for (int i = 1; i <= LeftSpace; i++)
            {
                move = new int[1, 2];
                move[0, 0] = _x - i;
                move[0, 1] = _y + i;
                moves.Add(move);
            }

            // GO UP AND LEFT
            for (int i = 1; i <= LeftSpace; i++)
            {
                move = new int[1, 2];
                move[0, 0] = _x - i;
                move[0, 1] = _y - i;
                moves.Add(move);
            }

            return moves;
        }       
    }
}
