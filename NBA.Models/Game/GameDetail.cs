using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class GameDetail
{
    public int GameId { get; set; }
    public int TeamAId { get; set; }
    public TeamDetail TeamAInfo { get; set; }
    
    public int TeamBId { get; set; }
    public TeamDetail TeamBInfo { get; set; }
    //public virtual List<PlayerListItem> Players { get; set; }
    //public DateTimeOffset GameDate { get; set; }
}
