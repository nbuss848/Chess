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

        private void Form1_Load(object sender, EventArgs e)
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
                this.Controls.Add(Pane);
            }                                                       
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }
    }
}
