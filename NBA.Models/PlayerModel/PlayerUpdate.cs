using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class PlayerUpdate
    {
        //public int Id { get; set; }
        [Required]
         public string Name { get; set; }
        [Required]
        public string Positions { get; set; }
        [Required]
        public int JerseyNumber { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
    }
