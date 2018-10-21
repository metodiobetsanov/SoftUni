namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.Common;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using IRunes.ViewModels;

    public class AlbumsController : BaseController
    {
        protected IAlbumService AlbumService { get; }

        public AlbumsController(IUserCookieService userCookieService, IAlbumService albumService)
            : base(userCookieService)
        {
            this.AlbumService = albumService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var albums = this.AlbumService.GetAllAlbums().ToList();
            var albumsAsString = this.AlbumService.GetAlbumsAsString(albums);
            this.ViewModel.Data[Common.AlbumAllPlaceholder] = albumsAsString;
            this.SettingViewsBasedOnAccess();
            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AlbumCreate model)
        {
            this.AlbumService.CreateAlbum(model);
            return this.All();
        }

        [HttpGet]
        public IActionResult Details(AlbumDetails model)
        {
            if (model.Id == null)
            {
                var result = this.AlbumService.CreateAlbumDetails(this.Request
                    .QueryData[Common.AlbumIdFromTrackCreateFormThroughRequestQeury].ToString());

                SetttingViewDataForAlbumDetails(result);
                return this.View();
            }
            var albumDetails = this.AlbumService.GetAlbumDetails(model.Id);

            SetttingViewDataForAlbumDetails(albumDetails);

            return this.View();
        }

        private void SetttingViewDataForAlbumDetails(IDictionary<string, string> data)
        {
            if (data[Common.AlbumDetailsViewTracksHolder] == Common.NoTracksCurrently)
            {
                this.ViewModel.Data[Common.DisplayInAlbumDetails] = "none";

                this.ViewModel.Data[Common.DisplayAnyTracks] = "none";
            }
            else
            {
                this.ViewModel.Data[Common.DisplayInAlbumDetails] = "inline";

                this.ViewModel.Data[Common.DisplayAnyTracks] = "inline";
            }

            foreach (var d in data)
            {
                this.ViewModel.Data[d.Key] = d.Value;
            }
            this.SettingViewsBasedOnAccess();
        }
    }
}