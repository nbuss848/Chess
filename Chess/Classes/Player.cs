using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    abstract class Player
    {
        private int _id;
        private string _alias;
        private int _rating;

        public string Alias { get => _alias; set => _alias = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public int Id { get => _id; set => _id = value; }

        // TODO: A player moves pieces on a board and takes turns with another player
        // A player can have a different rating for each gametype
    }
}
