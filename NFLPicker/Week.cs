using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicker
{
    public class Week : Entity
    {
        [Required(), RegularExpression("^[A-Za-z0-9 ,]{1,20}$", ErrorMessage = "Invalid week name")]
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
