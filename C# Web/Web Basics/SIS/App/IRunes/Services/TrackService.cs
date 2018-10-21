namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Models;
    using IRunes.Services.Contracts;
    using IRunes.ViewModels;
    using System.Linq;
    using System.Net;

    public class TrackService : ITrackService
    {
        public IRunesDbContext Context { get; set; }

        public TrackService()
        {
            this.Context = new IRunesDbContext();
        }

        public string CreateTrack(TrackCreate model, string albumId)
        {
            model.Link = WebUtility.UrlDecode(model.Link);
            string albumIdhiddenInTheHtml = albumId;

            bool trackExists = this.Context.Tracks.Any(x => x.Name == model.Name);

            Track track = new Track() {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price,
            };

            if (!trackExists)
            {
                this.Context.Tracks.Add(track);
                this.Context.SaveChanges();
            }

            var trackAlbum = new TracksAlbums
            {
                AlbumId = this.Context.Albums.Find(albumIdhiddenInTheHtml).Id,
                TrackId = this.Context.Tracks.First(x => x.Name == track.Name).Id
            };
            bool trackAlbumExist =
                this.Context.TracksAlbums.Any(x => x.AlbumId == trackAlbum.AlbumId && x.TrackId == trackAlbum.TrackId);

            if (!trackAlbumExist)
            {
                this.Context.Add(trackAlbum);
                this.Context.SaveChangesAsync();
            }

            return track.Id;
        }

        public Track Details(string trackId)
        {
            var track = this.Context.Tracks.FirstOrDefault(t => t.Id == trackId);

            return track;
        }
    }
}