using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public abstract class Piece
    {
        private string _color;
        private string _image;
        private string _type;
        public static int currX;
        public static int currY;

        private string Path = Environment.CurrentDirectory + @"..\..\..\";

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Image { get => _image; set => _image = value; }
        public string Type { get => _type; set => _type = value; }

     
        public Piece(string color, string type)
        {
            _color = color;
            _image = Path + color + type +  ".png";
        }

        public override string ToString()
        {
            return _color + _type;
        }

        public virtual void Move(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}