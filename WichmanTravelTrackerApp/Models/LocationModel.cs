using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WichmanTravelTrackerApp.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public bool Visited { get; set; }
    }
}
