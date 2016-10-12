using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicker
{
    public class Team : Entity
    {
        [Required(), RegularExpression("^[A-Za-z]{1,20}$", ErrorMessage = "Invalid city name")]
        public string City { get; set; }
        [Required(), RegularExpression("^[A-Za-z]{1,20}$", ErrorMessage = "Invalid team name")]
        public string Name { get; set; }
        [Required(), RegularExpression(@"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/", ErrorMessage = "Invalid LogoURL name")]
        public string LogoUrl { get; set; }
    }
}
