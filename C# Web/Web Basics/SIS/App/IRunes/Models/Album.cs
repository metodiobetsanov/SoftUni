namespace IRunes.Models
{
    using System.Collections.Generic;

    public class Album : BaseEntity<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<TracksAlbums>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<TracksAlbums> Tracks { get; set; }
    }
}