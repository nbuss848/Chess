using Chess.Classes;
using Chess.Classes.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class Main : Form
    {
        Board GameBoard = new Board();
        private List<Panel> paneHistory =  new List<Panel>();
        private AI artificalIntel;

        public Main()
        {
            InitializeComponent();
        }

        private void Visualize(List<int[,]> moves)
        {
            foreach (int[,] i in moves)
            {
                int x = i[0, 0];
                int y = i[0, 1];
                var pane = from box in this.Controls.OfType<Panel>()
                           where box.Name == String.Format("{0} {1}", x, y)
                           select box;

                foreach (var box in pane)
                {
                    Panel p = box;
                    p.BackColor = System.Drawing.Color.LightSkyBlue;
                    p.Refresh();
                }
            }
        }

        private void Test()
        {
            object[,] board = GameBoard.GetBoard();
            Bishop queen = new Bishop("W", 2, 2);
            board[2, 2] = queen;

            Pawn pawn = new Pawn("B", 2, 2);
            board[4, 4] = pawn;

            pawn = new Pawn("B", 1, 1);
            board[1, 1] = pawn;


            // List<int[,]> moves = //queen.GetMoves(); queen.Moves(Piece.Direction.Diagonal, GameBoard);
            List<int[,]> moves = queen.Moves(Piece.Direction.Diagonal, GameBoard);
            Draw();
            DrawCords();

            // Visualize Moves
            Visualize(moves);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Test();
            return;

            GameBoard.Setup(GameType.Classic);
            // GameBoard.Print();                
            Draw();
            // only draw cords once
            DrawCords();

            artificalIntel = new AI(GameBoard, "W"); 
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
            Control pane = (Control)sender;
            string id = pane.Name;
            string[] cords = id.Split(' ');
            int x = Convert.ToInt32(cords[0]);
            int y = Convert.ToInt32(cords[1]);

            foreach (Panel thePane in this.Controls.OfType < Panel>())
            {              
                    if (thePane.Name == id)
                    {
                        Panel temp = (Panel)thePane;
                        paneHistory.Add(temp);

                        break;
                    }               
            }            

            if(paneHistory.Count == 2) // % 2
            {
                UpdateBoard(x, y);
            }
            else if(paneHistory.Count == 1)
            {
                // This means there is no piece here so clear history, alternatively we could remove it from the history instead
                if(paneHistory[0].Controls.Count == 0)
                {
                    paneHistory.Clear();
                }
            }
        }

        /// <summary>
        /// Update the squares we need to refresh
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdateBoard(int x, int y)
        {
            Panel thePane = paneHistory[0];
            thePane.Controls.Clear();
            thePane.Refresh();

            paneHistory[1].Controls.Clear();
            // add updated square according to the board
            paneHistory[1].Controls.Add(GameBoard.GetSquareControl(x, y));
            paneHistory[1].Controls[0].Click += Pane_Click;

            paneHistory[1].Refresh();

            paneHistory.Clear();
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

        private void btMoveAI_Click(object sender, EventArgs e)
        {
            int[,] result = artificalIntel.Move();
            paneHistory.Clear();
            // var query = this.Controls.OfType<Panel>().Where(x => x.Name == String.Format("{0} {1}", result[0, 0], result[0, 1])).Select(x => x).Distinct();
            paneHistory.Add(FindPanel(result[0, 0], result[0, 1]));
            paneHistory.Add(FindPanel(result[1, 0], result[1, 1]));

            UpdateBoard(result[1, 0], result[1, 1]);
            paneHistory.Clear();

            //GameBoard.GetSquareControl(result[0, 0], result[0, 1]);
            //GameBoard.GetSquareControl(result[1, 0], result[1, 1]);
            // refresh the board somehow
            // GameBoard.GetSquareControl()
        }

        private Panel FindPanel(int x, int y)
        {
            Panel pane = new Panel();

            foreach (var item in this.Controls.OfType<Panel>())
            {
                if (item.Name == String.Format("{0} {1}", x, y))
                {
                    pane = item;
                    break;
                }
            }

            return pane;
        }
    }
}
