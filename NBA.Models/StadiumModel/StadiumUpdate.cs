using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class StadiumUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StadiumCapacity { get; set; }
        [Required]
        public string StadiumLocation { get; set; }
        [Required]
        public string StadiumName { get; set; }
    }
