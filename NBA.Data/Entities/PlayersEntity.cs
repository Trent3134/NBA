using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class PlayersEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Positions Positions { get; set; }
        public int JerseyNumber { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
    }
