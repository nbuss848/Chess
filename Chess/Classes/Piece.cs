using Chess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public abstract class Piece
    {
        private string _color;
        private string _image;
        public static int currX = -1;
        public static int currY = -1;
        private int _value;
        private int _x;
        private int _y;
        public enum Direction { Horizontal, Vertical, Diagonal, L };
        private List<int[,]> _moves;

        private string Path = Environment.CurrentDirectory + @"..\..\..\";

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Image Property
        /// </summary>
        public string Image { get => _image; set => _image = value; }
        public int Value { get => _value; set => _value = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        /// <summary>
        /// Default contructor for a piece
        /// </summary>
        /// <param name="color"></param>
        /// <param name="type"></param>
        public Piece(string color, string type)
        {
            _color = color;
            _image = Path + color + type +  ".png";
            _moves = new List<int[,]>();
        }

        public Piece(string color, string type, int X, int Y)
        {
            _color = color;
            _image = Path + color + type + ".png";
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Returns Color of the Piece as a defining characteristic
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _color;
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            else
            {
                Piece thePiece = (Piece)obj;
                if(thePiece is null)
                {
                    return false;
                }
                return this.ToString() == thePiece.ToString();
            }
        }

        public static Queue<Piece> GetPieces(string Color)
        {
            Queue<Piece> pieces = new Queue<Piece>();
            pieces.Enqueue(new Rook(Color));
            pieces.Enqueue(new Rook(Color));
            pieces.Enqueue(new Bishop(Color));
            pieces.Enqueue(new Bishop(Color));
            pieces.Enqueue(new Knight(Color));
            pieces.Enqueue(new Knight(Color));
            pieces.Enqueue(new Queen(Color));
            pieces.Enqueue(new King(Color));
            return pieces;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual List<int[,]> GetMoves(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public List<int[,]> Moves(Direction moveType)
        {
            List<int[,]> moves = new List<int[,]>();
            int[,] move = new int[1, 2];

            switch (moveType)
            {
                case Direction.Horizontal:                    

                    // GO LEFT
                    for (int i = Y - 1; i >= 0; i--)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X;
                        move[0, 1] = i;
                        moves.Add(move);
                    }

                    // GO RIGHT
                    for (int i = Y + 1; i < 8; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X;
                        move[0, 1] = i;
                        moves.Add(move);
                    }

                    break;
                case Direction.Vertical:
                    // GO DOWN
                    for (int i = X + 1; i < 8; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = i;
                        move[0, 1] = Y;
                        moves.Add(move);
                    }

                    // GO UP
                    for (int i = X - 1; i >= 0; i--)
                    {
                        move = new int[1, 2];
                        move[0, 0] = i;
                        move[0, 1] = Y;
                        moves.Add(move);
                    }
                    break;
                case Direction.Diagonal:
                    // Calculate how many times we have to go to the right
                    int RightSpace = 7 - X;
                    int LeftSpace = X;

                    // GO DOWN AND RIGHT
                    for (int i = 1; i <= RightSpace; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X + i;
                        move[0, 1] = Y + i;
                        moves.Add(move);
                    }

                    // GO UP AND Right
                    for (int i = 1; i <= RightSpace; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X + i;
                        move[0, 1] = Y - i;
                        moves.Add(move);
                    }

                    // GO DOWN AND LEFT
                    for (int i = 1; i <= LeftSpace; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X - i;
                        move[0, 1] = Y + i;
                        moves.Add(move);
                    }

                    // GO UP AND LEFT
                    for (int i = 1; i <= LeftSpace; i++)
                    {
                        move = new int[1, 2];
                        move[0, 0] = X - i;
                        move[0, 1] = Y - i;
                        moves.Add(move);
                    }
                    break;
                default: // no default
                    break;
            }

            return moves;
        }

        private bool Something(object v, int i)
        {
            bool lastMove = false;

            int[,] move = new int[1, 2];

            if (v is Piece)
            {
                Piece pieceOnBoard = v as Piece;

                if (this.Equals(v))
                {
                    //continue;
                }
                else if (this.Color != pieceOnBoard.Color)
                {                    
                    move = new int[1, 2];
                    move[0, 0] = X + i;
                    move[0, 1] = Y + i;
                    _moves.Add(move);
                    lastMove = true;
                }
                else
                {

                }
            }
            return lastMove;
        }


        public List<int[,]> Moves(Direction moveType, Board board)
        {
            object[,] GameBoard = board.GetBoard();

            _moves = new List<int[,]>();
            int[,] move = new int[1, 2];

            switch (moveType)
            {
                case Direction.Horizontal:

                    // GO LEFT
                    for (int i = Y - 1; i >= 0; i--)
                    {
                        if (GameBoard[X, i] is Piece)
                        {
                            break;

                        }

                        move = new int[1, 2];
                        move[0, 0] = X;
                        move[0, 1] = i;
                        _moves.Add(move);
                    }

                    // GO RIGHT
                    for (int i = Y + 1; i < 8; i++)
                    {
                        
                        if (GameBoard[X, i] is Piece) break;
                        move = new int[1, 2];
                        move[0, 0] = X;
                        move[0, 1] = i;
                        _moves.Add(move);
                    }

                    break;
                case Direction.Vertical:
                    // GO DOWN
                    for (int i = X + 1; i < 8; i++)
                    {
                        if (GameBoard[i, Y] is Piece) break;
                        move = new int[1, 2];
                        move[0, 0] = i;
                        move[0, 1] = Y;
                        _moves.Add(move);
                    }

                    // GO UP
                    for (int i = X - 1; i >= 0; i--)
                    {
                        if (GameBoard[i, Y] is Piece) break;
                        move = new int[1, 2];
                        move[0, 0] = i;
                        move[0, 1] = Y;
                        _moves.Add(move);
                    }
                    break;
                case Direction.Diagonal:
                    // Calculate how many times we have to go to the right
                    int RightSpace = 7 - X;
                    int LeftSpace = X;

                    // GO DOWN AND RIGHT
                    for (int i = 1; i <= RightSpace; i++)
                    {
                        if (X + i > 7 || Y + i > 7)
                        { continue; }

                        if (Something(GameBoard[X + i, Y + i], i))
                        {
                            break;
                        }

                        /*if (GameBoard[X + i, Y + i] is Piece)
                        {
                            Piece pieceOnBoard = GameBoard[X + i, Y + i] as Piece;

                            if (this.Equals(GameBoard[X + 1, Y + 1]))
                            {
                                //continue;
                            }
                            else if (this.Color != pieceOnBoard.Color)
                            {
                                //continue;
                                move = new int[1, 2];
                                move[0, 0] = X + i;
                                move[0, 1] = Y + i;
                                moves.Add(move);

                                break;
                            }
                            else
                            {
                                
                            }
                        }*/

                        move = new int[1, 2];
                        move[0, 0] = X + i;
                        move[0, 1] = Y + i;
                        _moves.Add(move);
                    }

                    // GO UP AND Right
                    for (int i = 1; i <= RightSpace; i++)
                    {
                        if (X + i > 7 || Y - i < 0)
                        { continue; }

                        if (GameBoard[X + i, Y - i] is Piece) break;

                        move = new int[1, 2];
                        move[0, 0] = X + i;
                        move[0, 1] = Y - i;
                        _moves.Add(move);
                    }

                    // GO DOWN AND LEFT
                    for (int i = 1; i <= LeftSpace; i++)
                    {
                        if (X - i < 0 || Y + i > 7) continue; 

                        if (GameBoard[X - i, Y + i] is Piece) break;

                        move = new int[1, 2];
                        move[0, 0] = X - i;
                        move[0, 1] = Y + i;
                        _moves.Add(move);
                    }

                    // GO UP AND LEFT
                    for (int i = 1; i <= LeftSpace; i++)
                    {
                        if (X - i < 0 || Y - i < 0) continue;

                        if (GameBoard[X - i, Y - i] is Piece) break;

                        move = new int[1, 2];
                        move[0, 0] = X - i;
                        move[0, 1] = Y - i;
                        _moves.Add(move);
                    }
                    break;
                default: // no default
                    break;
            }

            return _moves;
        }

        public virtual List<int[,]> GetMoves()
        {
            throw new System.NotFiniteNumberException();
        }

        public virtual void Move(int x, int y)
        {            
            //_board[Piece.currX, Piece.currY] = null;
            //_board[x, y] = selectedPiece;
            //x = -1;
            //y = -1;
        }       
    }
}