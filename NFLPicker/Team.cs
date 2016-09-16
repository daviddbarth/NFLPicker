using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicker
{
    public class Team : Entity
    {
        public string City { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }
}
