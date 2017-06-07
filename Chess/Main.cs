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
            GameBoard.Setup(GameType.Classic);
            // GameBoard.Print();       
            //DrawBoard();
            Draw();            
        }      

        /// <summary>
        /// Draws the UI for the Chess Board
        /// </summary>
        private void Draw()
        {
            List<Panel> Board = GameBoard.Render();
            foreach(Panel Pane in Board)
            {
                Pane.Click += Pane_Click;
                this.Controls.Add(Pane);
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
