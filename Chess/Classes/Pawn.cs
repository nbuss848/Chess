using System.Collections.Generic;

namespace Chess.Classes
{
    public class Pawn : Piece
    {       
        private bool _moved = false;
        private int _x;
        private int _y;
        //private List
        public Pawn(string color ) : base( color, "P" )
        {
            Value = 1;
        }

        public Pawn(string color, int X, int Y) : base(color,"P")
        {
            Value = 1;
            this.X = X;
            this.Y = Y;
        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public override List<int[,]> GetMoves()
        {
            // Pawn can move forward only and capture diagonally
            List<int[,]> moves = new List<int[,]>();
            int[,] cord = new int[2,2];

            if (_moved == true)
            {
                // TODO can move one or two spaces depending on color;
                if (Color == "W")
                {
                    cord[0, 0] = _x;
                    cord[0, 1] = _y + 1;
                    moves.Add(cord);          
                }
                else if (Color == "B")
                {
                    cord[0, 0] = _x;
                    cord[0, 1] = _y - 1;

                    moves.Add(cord);      
                }
            }
            else
            {
                if (Color == "W")
                {                    
                    cord[0, 0] = _x;
                    cord[0, 1] = _y + 1;
                    moves.Add(cord);

                    cord[0, 0] = _x;
                    cord[0, 1] = _y + 2;     
                    moves.Add(cord);
                }
                else if (Color == "B")
                {
                    cord[0, 0] = _x;
                    cord[0, 1] = _y - 1;
                    moves.Add(cord);

                    cord[0, 0] = _x;
                    cord[0, 1] = _y - 2;
                    moves.Add(cord);
                }
            }
            _moved = true;

            return moves;
        }

        public bool ValidMove(int xDestination, int yDestination)
        {
            bool valid = false;
            List<int[,]> moves = GetMoves();
            foreach (int[,] item in moves)
            {
                if(item[0,0] == xDestination && item[0,1] == yDestination)
                {
                    valid = true;
                    break;
                }
            }

            return valid;
        }       

        public override string ToString()
        {
            return base.ToString();
        }
    }
}