using InterestsCalculator.Models.DBModels;

namespace InterestsCalculator.Providers
{
    public interface IDBProvider
    {
        Task<CustomDBContext> GetDBContext();
    }
}