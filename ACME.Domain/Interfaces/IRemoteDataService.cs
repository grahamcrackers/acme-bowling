namespace ACME.Domain
{
    public interface IRemoteDataService
    {
        GameData Retrieve(string code);
    }
}