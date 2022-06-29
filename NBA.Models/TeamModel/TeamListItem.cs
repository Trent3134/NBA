using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class TeamListItem
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public Locations Location { get; set; }
    }