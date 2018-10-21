namespace IRunes.Services.Contracts
{
    using IRunes.Models;
    using IRunes.ViewModels;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        IEnumerable<Album> GetAllAlbums();

        IDictionary<string, string> GetAlbumDetails(string id);

        IDictionary<string, string> CreateAlbumDetails(string id);

        void CreateAlbum(AlbumCreate model);

        string GetAlbumsAsString(List<Album> albums);
    }
}