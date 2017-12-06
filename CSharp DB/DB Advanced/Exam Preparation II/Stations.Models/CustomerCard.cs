
using System.Collections.Generic;

namespace Stations.Models
{
    public class CustomerCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public CardType CardType { get; set; }

        public ICollection<Ticket> BoughtTickets  { get; set; }
    }
}
