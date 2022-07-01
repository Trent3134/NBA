using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class TeamEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Locations Location { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string TeamOwner { get; set; }
        public Mascot Mascot { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        public virtual List<PlayersEntity> Players { get; set; }
        public virtual List<Game> Games { get; set; }

        [ForeignKey(nameof(StadiumEntity))]
        public int? StadiumEntityId { get; set; }
        
    }
