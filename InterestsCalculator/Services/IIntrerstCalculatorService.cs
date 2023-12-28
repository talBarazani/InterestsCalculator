using InterestsCalculator.Models.ApiModels;

namespace InterestsCalculator.Services
{
    public interface IIntrerstCalculatorService
    {
        Task<GetLoanOfferRes> CalculateLoan(GetLoanOfferReq req);
    }
}