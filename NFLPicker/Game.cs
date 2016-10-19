using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicker
{
    public class Game
    {
        public DateTime StartTime { get; set; }
        public Team HomeTeam { get; set; }
        public Team VisitingTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitingTeamScore { get; set; }
    }
}
