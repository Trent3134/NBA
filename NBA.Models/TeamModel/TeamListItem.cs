using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class TeamListItem
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual List<PlayersEntity> Players { get; set; }
    }
