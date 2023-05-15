namespace Onboarding.Interfaces.Repository
{
    public interface ILoginRepository
    {
        Task<bool> AuthLogin(string username, string password);
    }
}
