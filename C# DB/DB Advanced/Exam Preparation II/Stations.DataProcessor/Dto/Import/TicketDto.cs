
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Stations.DataProcessor.Dto.Import;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Ticket")]
    public class TicketDto
    {
        [Required]
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [Required]
        [XmlAttribute("seat")]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        public string Seat { get; set; }

        [Required]
        public Ticket.TripDto Trip { get; set; }

        public Ticket.CardDto Card { get; set; }
        
    }
}
