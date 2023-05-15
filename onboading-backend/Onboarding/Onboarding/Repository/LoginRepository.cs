using Microsoft.EntityFrameworkCore;
using Onboarding.Interfaces.Repository;

namespace Onboarding.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<bool> AuthLogin(string username, string password)
        {
            await using var db = new DataContext();
            var loginMatch = await(from l in db.Login
                                   where l.Email == username && l.Password == password
                                   select l).FirstOrDefaultAsync();
            return (loginMatch != null);
        }
    }
}
