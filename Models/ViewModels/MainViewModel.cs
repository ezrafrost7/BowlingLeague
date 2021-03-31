using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class MainViewModel
    {
        //to pass the list of bowlers needed
        public List<Bowlers> Bowlers { get; set; }
        //used for filtering by team name
        public string TeamName { get; set; }
        //paging info
        public PageNumberingInfo pageNumberingInfo { get; set; }
    }
}
