namespace IRunes.Controllers
{
    using IRunes.Services.Contracts;
    using IRunes.Common;
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Methods;
    using SIS.FRAMEWORK.Services.Contracts;
    using IRunes.Models;
    using IRunes.ViewModels;

    public class TracksController : BaseController
    {
        public ITrackService TrackService { get; }

        public TracksController(ITrackService trackService, IUserCookieService userCookieService) : base(userCookieService)
        {
            this.TrackService = trackService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.ViewModel.Data[Common.AlbumPlaceHolderTrackCreateForm] =
                this.Request.QueryData[Common.AlbumIdFromTrackCreateFormThroughRequestQeury];
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TrackCreate model)
        {

            string albumId = this.Request.QueryData[Common.AlbumIdFromTrackCreateFormThroughRequestQeury].ToString();

            var trackId = this.TrackService.CreateTrack(model, albumId);

            var trackDetails = new TrackDetails
            {
                TrackId = trackId,
                AlbumId = albumId
            };

            return this.Details(trackDetails);
        }

        [HttpGet]
        public IActionResult Details(TrackDetails model)
        {
            var track = this.TrackService.Details(model.TrackId);
            SetttingViewDataForTrackDetails(track, model.AlbumId);
            this.SettingViewsBasedOnAccess();
            return this.View();
        }

        private void SetttingViewDataForTrackDetails(Track track, string albumId)
        {
            this.ViewModel.Data[Common.TrackDetailsViewTrackNameHolder] = track.Name;
            this.ViewModel.Data[Common.TrackDetailsViewTrackUrlHolder] = track.Link.Replace("watch?v=", "embed/");
            this.ViewModel.Data[Common.TrackDetailsViewTrackPriceHolder] = track.Price;
            this.ViewModel.Data[Common.TrackDetailsViewAlbumPathHolder] = albumId;

            this.SettingViewsBasedOnAccess();
        }
    }
}