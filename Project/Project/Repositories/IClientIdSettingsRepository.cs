namespace Project.Repositories
{
    public interface IClientIdSettingsRepository
    {
        string GetClientId();
        void SaveClientId(string clientId);
    }
}