using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class StadiumCreate
    {
        [Required]
        public int StadiumCapacity { get; set; }
        [Required]
        public Locations StadiumLocation { get; set; }
        [Required]
        public string StadiumName { get; set; }
        
    }
