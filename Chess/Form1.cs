using Chess.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        Board GameBoard = new Board();
        object[,] board;

        public Form1()
        {
            InitializeComponent();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            GameBoard.Setup(GameType.Classic);
            // GameBoard.Print();       
            //DrawBoard();
            Draw();
            
        }

        private void DrawBoard()
        {

        }

        private void Draw()
        {
            board =  GameBoard.GetBoard();

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
                    

                    if (board[i, j] != null)
                    {
                        // We found a piece, let's try to render it
                        Piece currentPiece = (Piece)board[i, j];

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
                        this.Controls.Add(pane);
                        //this.Controls.Add(picture);
                    }
                    else
                    {
                        this.Controls.Add(pane);
                    }
                    
                }
            }
        }

        private void Pane_Click(object sender, EventArgs e)
        {
            int x;
            int y;

            if(sender is Panel)
            {
                Panel box = (Panel)sender;
                x = Convert.ToInt16(box.Name.Split(' ')[0]);
                y = Convert.ToInt16( box.Name.Split(' ')[1]);
                // TODO Move the selected piece to here x,y 
                Piece selectedPiece = (Piece)board[x, y];
                selectedPiece.Move(x, y);
            }
            else if (sender is PictureBox)
            {       
                PictureBox box = (PictureBox)sender;
                x = Convert.ToInt16(box.Name.Split(' ')[0]);
                y = Convert.ToInt16(box.Name.Split(' ')[1]);
            }

            
        }
    }
}
