using IRunes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.ViewModels
{
    public class DetailsAlbumViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<Track> Tracks { get; set; }

    }
}
