namespace IRunes.Services.Contracts
{
    using IRunes.Models;
    using IRunes.ViewModels;

    public interface ITrackService
    {
        string CreateTrack(TrackCreate model, string id);

        Track Details(string trackId);
    }
}