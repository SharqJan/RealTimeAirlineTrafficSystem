using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTATS.Core.Entities
{
    public class Flight
    {
        public string number { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string codeshared { get; set; }
    }
}
