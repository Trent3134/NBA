using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class TeamDetail
    {
        public int Id { get; set; }
        public Locations Location { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual List<PlayerListItem> Players { get; set; }
    }
