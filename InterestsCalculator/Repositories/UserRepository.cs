using InterestsCalculator.Models.DBModels;
using InterestsCalculator.Providers;

namespace InterestsCalculator.Repositories;

public class UserRepository(IDBProvider provider) : IUserRepository
{
    public async Task<Customer> GetUserById(string id)
    {
        var context = await provider.GetDBContext();
        var user = context.Customers.FirstOrDefault(u => u.id == id);
        if (user == null)
        {
            throw new Exception("Id does not exist");
        }
        else return user;
    }

}
