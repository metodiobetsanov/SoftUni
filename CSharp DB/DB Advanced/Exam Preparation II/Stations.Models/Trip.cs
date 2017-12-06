using System;

namespace Stations.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }

        public TripStatus Status { get; set; }

        public DateTime TimeDifference { get; set; }

    }
}
