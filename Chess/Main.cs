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
    public partial class Main : Form
    {
        Board GameBoard = new Board();

        public Main()
        {
            InitializeComponent();
        }        

        private void Main_Load(object sender, EventArgs e)
        {           
            GameBoard.Setup(GameType.Random);
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
            List<Panel> Board = GameBoard.Render();

            foreach(Panel Pane in Board)
            {
                if(Pane.Controls.Count == 1)
                {
                    // Add the click even to the picture box itself
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
            this.Controls.Clear();
            Draw();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }
    }
}
