using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTATS.Core.Entities;

    public sealed class DataItem
    {
        public string flight_date { get; set; }
        public string flight_status { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public Airline airline { get; set; }
        public Flight flight { get; set; }
        public string aircraft { get; set; }
        public string live { get; set; }
}

