using System;
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
        /// Gets the state of the entire board. Might be useful to the UI class        
        /// </summary>
        /// <returns></returns>
        public object[,] GetBoard()
        {
            return _board;
        }

        public string Move(int preX, int preY, int destX, int destY)
        {
            if(_board[preX,preY] == null)
            {
                // return null;
                throw new NotImplementedException();
            }

            Piece selectedPiece = (Piece)_board[preX, preY];

            _board[preX, preY] = null;
            _board[destX, destY] = selectedPiece;

            return selectedPiece.Color;
        }

        /// <summary>
        /// Set the entire board to something. For example you might want to use this for the FEN or PNGS
        /// </summary>
        /// <param name="value"></param>
        public void SetBoard(object[,] value)
        {
            _board = value;
        }

        internal List<Control> DrawCords()
        {
            char []xRank = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            int offset = 82;
            int width = 75;

            List<Control> Labels = new List<Control>();
            for (int i = 0; i < 8; i++)
            {
                int x = 25;
                int y = i * width + offset;

                Label label = BuildLabel(x, y, (i + 1).ToString());
                Labels.Add(label);

                // TODO: think about the best way to describe x and y here
                // We flip x and y here so that we draw the xRank across the top of the UI                              
                label = BuildLabel(y, x, xRank[i].ToString());
                Labels.Add(label);
            }

            return Labels;
        }

        /// <summary>
        /// Build the a label to display the chess board cordinates to the user.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label BuildLabel(int x, int y, string text)
        {
            Label label = new Label();
            Point fontSize = new Point(16);
            label.Location = new Point(x, y);
            label.Text = text;
            label.Width = 50;

            return label;
        }

        public void SetSquare(int x, int y, object value)
        {
            _board[x, y] = value;
        }

        public List<Panel> Draw()
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
                        Piece currentPiece = (Piece)_board[i, j];

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
                    _board[j, 1] = new Pawn("W", j, 1);
                    _board[j, 6] = new Pawn("B", j, 1);
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
                    _board[j, 1] = new Pawn("W", j, 1);
                    _board[j, 6] = new Pawn("B", j, 6);
                }

                int[] ranks = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

                Queue<Piece> WhitesPieces = Piece.GetPieces("W");
                Queue<Piece> BlackPieces = Piece.GetPieces("B");

                Shuffle(ref ranks);

                foreach(int i in ranks)
                {
                    _board[i, 0] = WhitesPieces.Dequeue();
                    _board[i, 7] = BlackPieces.Dequeue();
                }
            }

        }

        /// <summary>
        /// Sorts an array randomly
        /// </summary>
        /// <param name="ranks"></param>
        private void Shuffle(ref int [] ranks)
        {
            Random rnd = new Random();
            ranks = ranks.OrderBy(x => rnd.Next()).ToArray();
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
                // only if valid move
                Piece selectedPiece = (Piece)_board[Piece.currX, Piece.currY];
                

                if(selectedPiece == null)
                {
                    return;
                }

                Move(Piece.currX, Piece.currY, x, y);

                x = -1;
                y = -1;
            }
            else if (sender is PictureBox)
            {
                PictureBox box = (PictureBox)sender;
                x = Convert.ToInt16(box.Name.Split(' ')[0]);
                y = Convert.ToInt16(box.Name.Split(' ')[1]);

                Piece selectedPiece = (Piece)_board[x, y];               

                 if(Piece.currX != x || Piece.currY != y)
                 {
                    // TODO: Take the piece                 
                    // TODO: See if the next selected piece is a different color ===
                    if (Piece.currX >= 0 && Piece.currY >= 0 && selectedPiece != null)
                    {
                        Piece Captureable = (Piece)_board[Piece.currX, Piece.currY];

                        if (!selectedPiece.Equals(Captureable))
                        {
                            if (Captureable == null)
                            {

                            }
                            else
                            {
                                _board[Piece.currX, Piece.currY] = null;
                                _board[x, y] = Captureable;
                                x = -1;
                                y = -1;
                            }

                            // TODO: Redraw the screen after the piece is captured
                        }
                    }

                 }

                // Set the last place the piece or square was clicked
                Piece.currX = x;
                Piece.currY = y;
            }
        }
    }
}

