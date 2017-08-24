using Chess.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Chess
{
    public partial class Main : Form
    {
        Board GameBoard = new Board();

        public Main()
        {
            InitializeComponent();
        }        

        private void Main_Load(object sender, EventArgs e)
        {           
            GameBoard.Setup(GameType.Classic);
            // GameBoard.Print();                
            Draw();
            // only draw cords once
            DrawCords();
        }      

        /// <summary>
        /// Draws the UI for the Chess Board
        /// </summary>
        private void Draw()
        {
            List<Panel> Board = GameBoard.Draw();

            foreach(Panel Pane in Board)
            {
                if(Pane.Controls.Count == 1)
                {
                    // Add the click event to the picture box itself
                    Pane.Controls[0].Click += Pane_Click;
                }
                else
                {
                    // Add the click event to the empty square
                    Pane.Click += Pane_Click;
                }
                
                this.Controls.Add(Pane);
            }            
        }

        private void DrawCords()
        {
            List<Control> controls = GameBoard.DrawCords();
            foreach (Control item in controls)
            {
                this.Controls.Add(item);
            }
        }

        private void Pane_Click(object sender, EventArgs e)
        {
            // TODO Get whos turn it is
            // ask the gamestate to return whos turn it is
            this.Controls.Clear();
            Draw();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            //lbCords.Text = String.Format("X: {0} Y: {1}", e.X, e.Y);
        }

        #region Move Events
        private void FirstMove_Click(object sender, EventArgs e)
        {

        }

        private void CurrentMove_Click(object sender, EventArgs e)
        {

        }

        private void NextAvailableMove_Click(object sender, EventArgs e)
        {

        }

        private void LastAvailableMove_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
