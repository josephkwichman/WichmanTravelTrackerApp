using System.Collections.Generic;
using System.Linq;
using WichmanTravelTrackerApp.Models;

namespace WichmanTravelTrackerApp.Services
{
    public class LocationsService
    {
        private static List<LocationModel> locations = new List<LocationModel>
        {

            new LocationModel
            {
                Id = 1,
                Location = "New York",
                Visited = false
            },

            new LocationModel
            {
                Id = 2,
                Location = "London",
                Visited = false
            },

            new LocationModel
            {
                Id = 3,
                Location = "Los Angeles",
                Visited = true
            }


        };
        public List<LocationModel> GetAllLocations()
        {

            return locations;

        }

        public void AddALocation(LocationModel inputLocation)
        {
            var loc = new LocationModel
            {
                Id = inputLocation.Id,
                Location = inputLocation.Location,
                Visited = inputLocation.Visited
            };

            locations.Add(loc);
        }

        public void ChangeALocationVisitedProperty(int inputId)
        {
            if (inputId > 0 && inputId <= locations.Count())
            {
                var _visitedProp = locations.Where(l => l.Id == inputId).First().Visited;
                locations.Where(l => l.Id == inputId).First().Visited = !_visitedProp;
            }
        }

    }
}
