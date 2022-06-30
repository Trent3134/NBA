using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class StadiumEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StadiumCapacity { get; set; }
        [Required]
        public Locations StadiumLocation { get; set; }
        [Required]
        public string StadiumName { get; set; }
        [ForeignKey(nameof(TeamEntity))]
        public int? TeamEntityId { get; set; }

        public virtual List<TeamEntity> Teams  {get; set;}
    }
