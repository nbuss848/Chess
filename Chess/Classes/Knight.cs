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

        public Knight(string color, int X, int Y) : base(color, "N", X, Y)
        {
            this.Value = 3;
        }

        public override List<int[,]> GetMoves()
        {
            List<int[,]> moves = new List<int[,]>()
            {
                new int[,] { {X + 1, Y + 2 } },
                new int[,] { {X + 2, Y + 1 } },
                new int[,] { {X + 1, Y - 2 } },
                new int[,] { {X + 2, Y - 1 } },

                new int[,] { {X - 2, Y + 1 } },
                new int[,] { {X - 1, Y + 2 } },
                new int[,] { {X - 2, Y - 1 } },
                new int[,] { {X - 1, Y - 2 } }
            };

            List<int[,]> tempHold = new List<int[,]>();

            foreach (var item in moves)
            {
                if(item[0,0] > 7 || item[0,1] > 7 || item[0,0] < 0 || item[0,1] < 0)
                {
                   // moves.Remove(item);
                }
                else
                {
                    tempHold.Add(item);
                }
            }

            return tempHold;
        }
    }
}
