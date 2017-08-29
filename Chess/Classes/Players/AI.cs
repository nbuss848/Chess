using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Players
{
    class AI
    {
        private Board _board;
        private string _color;

        public AI(Board Board, string Color)
        {
            _board = Board;
            _color = Color;
        }

        public int[,] Move()
        {
            int[,] moves = new int[2, 2];

            var GameBoard = _board.GetBoard();
            // TODO: pick a piece to move; Based on color
            moves = Evaluate(GameBoard, _color);

            return moves;
        }
      
        private int [,] Evaluate(object[,] gameBoard, string color)
        {
            int[,] moveHistory = new int[2, 2];

            foreach (Piece piece in gameBoard.OfType<Piece>())
            {
                if (piece.Color == color)
                {
                    // Todo get valid move and then move the piece
                    List<int[,]> moves = piece.GetMoves();

                    if (moves.Count <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var item in moves)
                        {
                            int[,] cords = item;
                            if (gameBoard[cords[0, 0], cords[0, 1]] is Piece)
                            {
                                // only valid when pieces are not equal
                                Piece destPiece = gameBoard[cords[0, 0], cords[0, 1]] as Piece;

                                if (!piece.Equals(destPiece))
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                int x = cords[0, 0];
                                int y = cords[0, 1];
                                gameBoard[piece.X, piece.Y] = null;
                                gameBoard[x, y] = piece;
                             
                                moveHistory[0, 0] = piece.X;
                                moveHistory[0, 1] = piece.Y;

                                moveHistory[1, 0] = x;
                                moveHistory[1, 1] = y;

                                piece.X = x;
                                piece.Y = y;
                                return moveHistory;
                            }
                        }
                    }
                }
            }
            return moveHistory;
        }
    }
}
