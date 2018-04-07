namespace BashSoft.Interfaces
{
    public interface IContentComparer
    {
        void CompareContent(string userOutputPath, string expectedOutputPath);
    }
}