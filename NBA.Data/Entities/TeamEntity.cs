using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class TeamEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Locations Locations { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string TeamOwner { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        public virtual List<PlayersEntity> Players { get; set; }
    }
