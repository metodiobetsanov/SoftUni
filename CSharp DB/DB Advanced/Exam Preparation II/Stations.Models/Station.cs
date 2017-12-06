using System.Collections.Generic;

namespace Stations.Models
{
    public class Station
    {
        public Station()
        {
            this.TripsTo = new List<Trip>();
            this.TripsFrom = new List<Trip>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public ICollection<Trip> TripsTo { get; set; }
        public ICollection<Trip> TripsFrom { get; set; }
    }
}
