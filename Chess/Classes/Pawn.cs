namespace Chess.Classes
{
    public class Pawn : Piece
    {       
        private bool moved = false;
     
        public Pawn(string color ) : base( color, "P" )
        {
           
        }

        public override void Move(int x, int y)
        {
            // Pawn can move forward only and capture diagonally


            /*  if(moved == true)
              {
                  // TODO can move one or two spaces depending on color;
                  if(Color == "W")
                  {
                      return [x + 1, y];
                  }
                  else if( Color == "B")
                  {
                      return [x - 1, y];
                  }
              }
              moved = true;

              return [x, y];*/
            base.Move(x, y);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}