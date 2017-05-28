using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Classes
{
    class Board
    {
        public Board()
        {
            _board = new object[8, 8];
        }

        private object[,] _board;

        public object[,] GetBoard()
        {
            return _board;
        }

        public void SetBoard(object[, ] value)
        {
            _board = value;
        }

        public void SetSquare(int x, int y, char value)
        {
            _board[x, y] = value;
        }

        internal void Setup(GameType Game)
        {
            if (GameType.Classic == Game)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[j, 1] = new Pawn("W");
                    _board[j, 6] = new Pawn("B");
                }

                // Build Rooks
                _board[0, 0] = new Rook("W");
                _board[0, 7] = new Rook("B");
                _board[7, 7] = new Rook("B");
                _board[7, 0] = new Rook("W");

                // Build Knights
                _board[1, 0] = new Knight("W");
                _board[6, 0] = new Knight("W");
                _board[1, 7] = new Knight("B");
                _board[6, 7] = new Knight("B");

                // Build Bishops
                _board[2, 0] = new Bishop("W");
                _board[5, 0] = new Bishop("W");
                _board[2, 7] = new Bishop("B");
                _board[5, 7] = new Bishop("B");

                // Build Kings
                _board[4, 0] = new King("W");
                _board[4, 7] = new King("B");

                // Build Queens
                _board[3, 0] = new Queen("W");
                _board[3, 7] = new Queen("B");
            }

        }

        internal void Print()
        {
            for(int i=0; i<8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_board[i, j] != null)
                    {
                        Console.Write(_board[i, j].ToString());
                                        
                    }                    
                }
                Console.WriteLine();
            }
        }
    }
}
