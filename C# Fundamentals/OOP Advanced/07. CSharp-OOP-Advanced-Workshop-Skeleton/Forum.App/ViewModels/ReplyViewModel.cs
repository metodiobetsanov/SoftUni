namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public string Author { get; }

        public ReplyViewModel(string author, string content)
            : base(content)
        {
            this.Author = author;
        }
    }
}