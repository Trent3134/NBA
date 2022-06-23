using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class TeamListItem
    {
<<<<<<< HEAD
    
    }
=======
        public int Id { get; set; }
        public string Location { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual List<PlayersEntity> Players { get; set; }
    }
>>>>>>> 18d3bb991cd0d6c2f25af943a2b2e29408b8e68a
