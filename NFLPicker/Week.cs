﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicker
{
    public class Week : Entity
    {
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
