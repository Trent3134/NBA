using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class Game
{
    public int Id { get; set; }
    
    public int TeamAId { get; set; }
    public int TeamBId { get; set; }
    //public DateTimeOffset GameTime { get; set; }

}
