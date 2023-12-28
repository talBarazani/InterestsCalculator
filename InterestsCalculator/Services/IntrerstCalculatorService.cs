using InterestsCalculator.Models.ApiModels;
using InterestsCalculator.Models.DBModels;
using InterestsCalculator.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.IO.Pipelines;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;

namespace InterestsCalculator.Services;

public class IntrerstCalculatorService(IUserRepository userRepository) : IIntrerstCalculatorService
{
    public async Task<GetLoanOfferRes> CalculateLoan(GetLoanOfferReq req)
    {
        var customer = await userRepository.GetUserById(req.IDNumber);
        UserLoansType u = UserLoansTypeFactory(customer);
        GetLoanOfferRes res = new()
        {
            LoanSum = u.CalculateLoan(req.Amount, req.Months)
        };
        return res;

    }

    static UserLoansType UserLoansTypeFactory(Customer customer)
    {
        int age = DateTime.Now.Year - customer.birthData.Year;
        switch (age)
        {
            case < 20:
                return new UserLoansType1();
            case <= 35:
                return new UserLoansType2();
            case > 35:
                return new UserLoansType3();
        }
    }
}

abstract class UserLoansType
{
    protected readonly decimal prime = 1.5M;
    protected readonly decimal monthExtrasPayRatio = 0.15M;
    private readonly int minLoanPeriod = 12;
    public decimal AddInterest(decimal amount, decimal Interest)
    {
        return amount + amount * Interest / 100;
    }
    public decimal MonthExtrasPayment(decimal amount, int months)
    {
        return (amount * monthExtrasPayRatio * (months - minLoanPeriod) / 100);
    }

    abstract public decimal CalculateLoan(decimal amount, int months);
}

//USER LOANS TYPES:
class UserLoansType1 : UserLoansType
{
    public override decimal CalculateLoan(decimal amount, int months)
    {
        return AddInterest(amount, 2 + prime) + MonthExtrasPayment(amount, months);

    }
}
class UserLoansType2 : UserLoansType
{
    public override decimal CalculateLoan(decimal amount, int months)
    {
        if (amount <= 5000M) return AddInterest(amount, 2) + MonthExtrasPayment(amount, months);
        else if (amount <= 30000M) return AddInterest(amount, 1.5M + prime) + MonthExtrasPayment(amount, months);
        else return AddInterest(amount, 1M + prime) + MonthExtrasPayment(amount, months);
    }
}

class UserLoansType3 : UserLoansType
{
    public override decimal CalculateLoan(decimal amount, int months)
    {
        if (amount <= 5000M) return AddInterest(amount, 1.5M + prime) + MonthExtrasPayment(amount, months);
        else if (amount <= 30000M) return AddInterest(amount, 3M + prime + prime) + MonthExtrasPayment(amount, months);
        else return AddInterest(amount, 1M) + MonthExtrasPayment(amount, months);
    }
}









