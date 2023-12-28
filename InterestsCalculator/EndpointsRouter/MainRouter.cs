using InterestsCalculator.Models.ApiModels;
using InterestsCalculator.Services;

namespace InterestsCalculator.EndpointsRouter;
public static class MainRouter
{
    public static void MapRotues(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/GetLoanOffer", async (GetLoanOfferReq req, IIntrerstCalculatorService intrerstCalculatorService) =>
        {
            var res = await intrerstCalculatorService.CalculateLoan(req);
            return res;
        }).WithName("GetLoanOffer"); 
    }
}
