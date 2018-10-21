namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Common;
    using IRunes.Models;
    using IRunes.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using IRunes.ViewModels;

    public class AlbumService : IAlbumService
    {
        protected IRunesDbContext Context { get; set; }

        public AlbumService()
        {
            this.Context = new IRunesDbContext();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            var albums = this.Context.Albums.Include(x => x.Tracks).ToArray();

            return albums;
        }

        public IDictionary<string, string> GetAlbumDetails(string id)
        {
            var album = this.Context.Albums.Include(x => x.Tracks).ThenInclude(x => x.Track).FirstOrDefault(x => x.Id == id);
            var albumDetails = CreateAlbumDetails(album);

            return albumDetails;
        }

        private string ExtractAlbumTrackList(Album album)
        {
            if (!album.Tracks.Any()) return Common.NoTracksCurrently;

            string trackInfo = "<ol>";
            foreach (var track in album.Tracks)
            {
                trackInfo += ("<li><a href=" + $"/tracks/details?albumId={album.Id}" +
                            $"&trackId={track.Track.Id}>" + $"{track.Track.Name}" + "</a></li>");
            }

            trackInfo += "</ol>";

            return trackInfo;
        }

        private IDictionary<string, string> CreateAlbumDetails(Album album)
        {
            decimal price = album?.Price ?? 0.00m;
            string albumName = album.Name;
            string albumCover = album.Cover;
            var albumTracks = ExtractAlbumTrackList(album);

            var albumInfo = new Dictionary<string, string>
            {
                {
                    Common.AlbumDetailsViewCoverHolder,albumCover
                },
                {
                    Common.AlbumDetailsViewPriceHolder,price.ToString("f2")
                },
                {
                    Common.AlbumDetailsViewNameHolder,albumName
                },
                {
                    Common.AlbumDetailsViewTracksHolder,albumTracks
                },
                {
                    Common.AlbumPlaceHolderTrackCreateForm,album.Id
                }
            };

            return albumInfo;
        }

        public void CreateAlbum(AlbumCreate model)
        {
            model.AlbumCover = WebUtility.UrlDecode(model.AlbumCover);

            var albumExists = this.Context.Albums.Any(x => x.Name == model.AlbumName);

            Album album = new Album() {
                Name = model.AlbumName,
                Cover = model.AlbumCover
            };

            this.Context.Albums.Add(album);
            this.Context.SaveChanges();
        }

        public string GetAlbumsAsString(List<Album> albums)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                string htmlTemplate = $"<a href=" + "/albums/details" + $"?id={album.Id}>{album.Name}</a><br/>";

                sb.AppendLine(htmlTemplate);
                sb.Append(Environment.NewLine);
            }

            if (!albums.Any())
            {
                string htmlTemplate = $"<a href=" + "/" + ">" + $"{Common.NoAlbumConstant}" + "</a><br/>";
                sb.AppendLine(htmlTemplate);
            }
            return sb.ToString();
        }

        public IDictionary<string, string> CreateAlbumDetails(string id)
        {
            var album = this.Context.Albums.Find(id);
            decimal price = album?.Price ?? 0.00m;
            string albumName = album.Name;
            string albumCover = album.Cover;
            string albumTracks = ExtractAlbumTrackList(album);

            var albumInfo = new Dictionary<string, string>
            {
                {
                    Common.AlbumDetailsViewCoverHolder,albumCover
                },
                {
                    Common.AlbumDetailsViewPriceHolder,price.ToString("f2")
                },
                {
                    Common.AlbumDetailsViewNameHolder,albumName
                },
                {
                    Common.AlbumDetailsViewTracksHolder,albumTracks
                },
                {
                    Common.AlbumPlaceHolderTrackCreateForm,album.Id
                }
            };

            return albumInfo;
        }
    }
}