using InterestsCalculator.Models.DBModels;

namespace InterestsCalculator.Repositories
{
    public interface IUserRepository
    {
        Task<Customer> GetUserById(string id);
    }
}