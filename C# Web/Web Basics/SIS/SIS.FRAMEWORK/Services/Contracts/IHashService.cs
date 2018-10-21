namespace SIS.FRAMEWORK.Services.Contracts
{
    public interface IHashService
    {
        string StrongHash(string stringToHash);

        string Hash(string stringToHash);
    }
}