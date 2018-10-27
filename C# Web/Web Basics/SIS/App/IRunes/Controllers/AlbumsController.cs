namespace IRunes.Controllers
{
    using IRunes.Models;
    using IRunes.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Action;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : BaseController
    {
        public AlbumsController(IUserCookieService userCookieService)
            : base(userCookieService)
        {
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            this.Check();
            IEnumerable<AllAlbumsViewModel> allAlbumsViewModel = this.Context
                                                            .Albums
                                                            .Select(a =>
                                                                new AllAlbumsViewModel
                                                                {
                                                                    Id = a.Id,
                                                                    Name = a.Name
                                                                })
                                                            .ToList();

            this.Model.Data["AllAlbumsViewModel"] = allAlbumsViewModel;

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            this.Check();
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateAlbumViewModel model)
        {
            if (this.Context.Albums.Any(x => x.Name == model.Name))
            {
                return this.Create();
            }

            Album album = new Album()
            {
                Name = model.Name,
                Cover = model.Cover
            };

            this.Context.Albums.Add(album);
            this.Context.SaveChangesAsync();

            return this.RedirectToAction("/albums/all");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details()
        {
            var id = this.Request.QueryData["id"].ToString();

            var album = this.Context
                .Albums
                .Include(i => i.Tracks)
                .FirstOrDefault(a => a.Id == id);

            DetailsAlbumViewModel detailsAlbumViewModel = new DetailsAlbumViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Cover = album.Cover,
                Price = album.Price,
                Tracks = album.Tracks.Select(at => at.Track).ToList()
            };

            this.Model.Data["DetailsAlbumViewModel"] = detailsAlbumViewModel;

            return this.View();
        }
    }
}