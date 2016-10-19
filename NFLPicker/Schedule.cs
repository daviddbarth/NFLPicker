using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NFLPicker
{
    public class Schedule : Entity
    {
        [Required(), RegularExpression("^[A-Za-z0-9 ,-]{1,20}$", ErrorMessage = "Invalid week name")]
        public string SeasonName { get; set; }
        public List<Week> Weeks { get; set; }
    }
}
