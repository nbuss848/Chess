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

            for (int i = 0; i < _x; i++)
            {
                for (int j = _y; j > 0; j--)
                {

                }
            }

            move[0, 0] = _x + 1;
            move[0, 1] = _y + 1;

            moves.Add(move);

            move[0, 0] = _x + 2;
            move[0, 1] = _y + 2;

            moves.Add(move);

            return moves;
        }
    }
}
