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

        public void Move()
        {
            var GameBoard = _board.GetBoard();
            // TODO: pick a piece to move; Based on color
            Evaluate(GameBoard, _color);
        }

        private void Evaluate(object[,] gameBoard, string color)
        {
            foreach(Piece piece in gameBoard.OfType<Piece>())
            {
                if(piece.Color == color)
                {
                    if (piece.GetType().Name == "Pawn")
                    {
                        // Todo get valid move and then move the piece
                        Pawn pawn = (Pawn)piece;
                        List<int[,]> moves = pawn.GetMoves();


                        if (moves.Count <= 0)
                        {
                            continue;
                        }
                        {
                            int[,] cords = moves[0];
                            if(gameBoard[cords[0, 0], cords[0, 1]] is Piece)
                            {
                                // only valid when pieces are not equal
                                continue;
                            }
                            else
                            {
                                int x = cords[0, 0];
                                int y = cords[0, 1];
                                gameBoard[pawn.X, pawn.Y] = null;
                                gameBoard[x, y] = piece;
                                pawn.X = x;
                                pawn.Y = y;
                            }
                        }

                        break; // only move one piece
                    }
                }
            }
        }
    }
}
