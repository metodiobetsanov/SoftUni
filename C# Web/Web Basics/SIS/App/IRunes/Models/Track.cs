namespace IRunes.Models
{
    using System.Collections.Generic;

    public class Track : BaseEntity<string>
    {
        public Track()
        {
            this.Albums = new HashSet<TracksAlbums>();
        }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<TracksAlbums> Albums { get; set; }
    }
}