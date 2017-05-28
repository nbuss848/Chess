namespace Chess.Classes
{
    public class Pawn : Piece
    {
        private bool moved = false;
        private int _x;

        public Pawn(string color ) : base( color, "P" )
        {
           
        }

        public int X { get => _x; set => _x = value; }

        public override void Move()
        {
            // Pawn can move forward only and capture diagonally
            if(moved == true)
            {
                // TODO can move one or two spaces depending on color;
                

            }
            moved = true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}