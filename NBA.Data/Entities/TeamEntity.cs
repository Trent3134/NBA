using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class TeamEntity
    {
        [Key]
        public int Id { get; set; }
        public Locations Location { get; set; }
        public string TeamName { get; set; }
        public string TeamOwner { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public virtual List<PlayersEntity> Players { get; set; }
    }
