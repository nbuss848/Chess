﻿using Chess.Classes;
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
        public static int currX = -1;
        public static int currY = -1;
        private int _value;        

        private string Path = Environment.CurrentDirectory + @"..\..\..\";

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Image Property
        /// </summary>
        public string Image { get => _image; set => _image = value; }
        public int Value { get => _value; set => _value = value; }

        /// <summary>
        /// Default contructor for a piece
        /// </summary>
        /// <param name="color"></param>
        /// <param name="type"></param>
        public Piece(string color, string type)
        {
            _color = color;
            _image = Path + color + type +  ".png";
        }

        /// <summary>
        /// Returns Color of the Piece as a defining characteristic
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _color;
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            else
            {
                Piece thePiece = (Piece)obj;
                if(thePiece is null)
                {
                    return false;
                }
                return this.ToString() == thePiece.ToString();
            }
        }

        public static Queue<Piece> GetPieces(string Color)
        {
            Queue<Piece> pieces = new Queue<Piece>();
            pieces.Enqueue(new Rook(Color));
            pieces.Enqueue(new Rook(Color));
            pieces.Enqueue(new Bishop(Color));
            pieces.Enqueue(new Bishop(Color));
            pieces.Enqueue(new Knight(Color));
            pieces.Enqueue(new Knight(Color));
            pieces.Enqueue(new Queen(Color));
            pieces.Enqueue(new King(Color));
            return pieces;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual List<int[,]> GetMoves(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<int[,]> GetMoves()
        {
            throw new System.NotFiniteNumberException();
        }

        public virtual void Move(int x, int y)
        {            
            //_board[Piece.currX, Piece.currY] = null;
            //_board[x, y] = selectedPiece;
            //x = -1;
            //y = -1;
        }       
    }
}