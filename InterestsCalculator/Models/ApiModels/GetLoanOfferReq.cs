using System.ComponentModel.DataAnnotations;

namespace InterestsCalculator.Models.ApiModels
{
    public record GetLoanOfferReq
    {
        [MaxLength(9)]
        [Required]
        public string IDNumber { get; set; }
        [Range(12, 10000)]
        public int Months { get; set; }
        [Range(0, 100000)]
        public decimal Amount { get; set; }
    }
}
