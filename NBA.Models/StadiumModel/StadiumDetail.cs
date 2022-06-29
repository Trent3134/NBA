using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class StadiumDetail
    {
        public int Id { get; set; }
        public int StadiumCapacity { get; set; }
        public Locations StadiumLocation { get; set; }
        public string StadiumName { get; set; }
        public virtual List<TeamEntity> Teams {get; set;}
    }
