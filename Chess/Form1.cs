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
            object [,] board =  GameBoard.GetBoard();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        // We found a piece, let's try to render it
                        Piece currentPiece = (Piece)board[i, j];

                        PictureBox picture = new PictureBox();
                        picture.Load(currentPiece.Image);
                        picture.Location = new System.Drawing.Point(i * 75 + 50, j * 75 + 50);
                        picture.Width = 75;
                        picture.Height = 75;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        
                        this.Controls.Add(picture);
                        
                    }
                }
            }
        }
    }
}
