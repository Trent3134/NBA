using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class TeamCreate
    {
        [Required]
        public string TeamName { get; set; }
        
        public string TeamOwner { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public virtual List<PlayersEntity> Players { get; set; }
    }
