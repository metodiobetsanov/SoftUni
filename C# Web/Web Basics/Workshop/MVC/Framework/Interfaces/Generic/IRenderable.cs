namespace Framework.Interfaces
{
    public interface IRenderable<T> : IRenderable
    {
        T Model { get; set; }
    }
}