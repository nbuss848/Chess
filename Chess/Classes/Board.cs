﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Classes
{
    class Board
    {
        private object[,] _board;

        public Board()
        {
            _board = new object[8, 8];
        }

        /// <summary>
        /// Gets the state of the entire board
        /// </summary>
        /// <returns></returns>
        public object[,] GetBoard()
        {
            return _board;
        }

        public void SetBoard(object[,] value)
        {
            _board = value;
        }

        public void SetSquare(int x, int y, object value)
        {
            _board[x, y] = value;
        }

        public List<Panel> Render()
        {
            List<Panel> Board = new List<Panel>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Panel pane = new Panel();
                    if (i % 2 == 0)
                    {
                        pane.Location = new System.Drawing.Point(i * 75 + 50, j * 75 + 50);
                        pane.Size = new System.Drawing.Size(75, 75);
                        pane.BackColor = j % 2 == 0 ? Color.Green : Color.White;
                        pane.Name = i + " " + j;
                        pane.Click += Pane_Click;
                    }
                    else
                    {
                        pane.Location = new System.Drawing.Point(i * 75 + 50, j * 75 + 50);
                        pane.Size = new System.Drawing.Size(75, 75);
                        pane.BackColor = j % 2 == 0 ? Color.White : Color.Green;
                        pane.Name = i + " " + j;
                        pane.Click += Pane_Click;
                    }

                    if (_board[i, j] != null)
                    {
                        // We found a piece, let's try to render it
                        Piece currentPiece = (Piece)GetSquare(i, j);

                        PictureBox picture = new PictureBox();
                        picture.Load(currentPiece.Image);
                        // picture.Location = new System.Drawing.Point(i * 75 + 50, j * 75 + 50);
                        picture.Width = 75;
                        picture.Height = 75;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.BackColor = Color.Transparent;
                        picture.Click += Pane_Click;
                        picture.Name = i + " " + j;

                        pane.Controls.Add(picture);
                    }
                    else
                    {
                        //this.Controls.Add(pane);
                    }

                    Board.Add(pane);
                }
            }

            return Board;
        }

        /// <summary>
        /// Gets the square of the board
        /// </summary>
        /// <param name="x">Xcord</param>
        /// <param name="y">Ycord</param>
        /// <returns>A piece or a null</returns>
        public object GetSquare(int x, int y)
        {
            return _board[x, y];
        }

        /// <summary>
        /// Sets up the gameboard with the desired game type
        /// </summary>
        /// <param name="Game"></param>
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
            else if (GameType.Random == Game)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[j, 1] = new Pawn("W");
                    _board[j, 6] = new Pawn("B");
                }


            }

        }

        /// <summary>
        /// Prints the state of the board to the console window
        /// </summary>
        internal void Print()
        {
            for (int i = 0; i < 8; i++)
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

        private void Pane_Click(object sender, EventArgs e)
        {
            int x;
            int y;

            if (sender is Panel)
            {
                Panel box = (Panel)sender;
                x = Convert.ToInt16(box.Name.Split(' ')[0]);
                y = Convert.ToInt16(box.Name.Split(' ')[1]);
                // TODO: Move the selected piece to here x, y 
                Piece selectedPiece = (Piece)GetSquare(Piece.currX, Piece.currY);

                SetSquare(Piece.currX, Piece.currY, null);
                SetSquare(x, y, selectedPiece);                

                // TODO: Redraw the pieces and squares that were affected
                //this.Controls.Clear();
                //Draw();
            }
            else if (sender is PictureBox)
            {
                PictureBox box = (PictureBox)sender;
                x = Convert.ToInt16(box.Name.Split(' ')[0]);
                y = Convert.ToInt16(box.Name.Split(' ')[1]);

                Piece selectedPiece = (Piece)GetSquare(x, y);               

                /* if(Piece.currX != x && Piece.currY != y)
                 {
                     // TODO: Take the piece
                     // Clear the place the user just clicked and move the original X and Y
                     board[x, y] = null;
                     board[Piece.currX, Piece.currY] = selectedPiece;
                     this.Controls.Clear();
                     Draw();
                 }*/
                // Set the last place the piece or square was clicked
                Piece.currX = x;
                Piece.currY = y;
            }
        }
    }
}

