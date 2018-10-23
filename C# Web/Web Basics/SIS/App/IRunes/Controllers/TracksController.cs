

namespace IRunes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using IRunes.Models;
    using IRunes.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Action;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;

    public class TracksController : BaseController
    {
        public TracksController(IUserCookieService userCookieService)
            : base(userCookieService)
        {
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            this.Check();
            this.Model.Data["AlbumId"] = this.Request.QueryData["albumId"];
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateTrackViewModel model)
        {
            
            string albumId = this.Request.QueryData["albumId"].ToString();

            if(this.Context.Tracks.Any(x => x.Name == model.Name))
            {
                return this.RedirectToAction($"/tracks/create?albumId={albumId}");
            }

            Track track = new Track()
            {
                Name = model.Name,
                Link = model.Link,
                Price = model.Price,
            };

            this.Context.Tracks.Add(track);
            this.Context.SaveChangesAsync();

            var trackId = this.Context.Tracks.First(x => x.Name == track.Name).Id;

            var trackAlbum = new TracksAlbums
            {
                AlbumId = albumId,
                TrackId = trackId
            };




                this.Context.Add(trackAlbum);
                this.Context.SaveChangesAsync();
   

            return this.RedirectToAction($"/tracks/details?albumId={albumId}&trackId={trackId}");
        }
    }
}
