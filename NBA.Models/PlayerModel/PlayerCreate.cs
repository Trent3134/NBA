using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class PlayerCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Positions  Positions  { get; set; }
        public int JerseyNumber { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        [Required]
        public string Height { get; set; }
    }
