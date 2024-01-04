using DevCodeChallenge.Models;
using DevCodeChallenge.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace DevCodeChallenge.Services
{
    public class PurchaseService
    {
        private readonly PurchaseRepository _purchaseRepository;

        public PurchaseService(PurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        private IList<PurchaseDto> FormatPurchases(IEnumerable<Purchase> purchases)
        {
            return purchases.Select(p => new PurchaseDto
            {
                Id = p.Id,
                Quantity = p.Quantity,
                TotalCost = p.TotalCost,
                Date = p.Date.ToString("d 'de' MMMM 'de' yyyy")
            }).ToList();
        }

        public IList<PurchaseDto> GetAllPurchases(bool ascendingOrder = true)
        {
            var purchases = _purchaseRepository.GetAll(ascendingOrder);
            return FormatPurchases(purchases);
        }

        public IList<PurchaseDto> GetPurchasesWithTotalCostGreaterThan(decimal totalCost, bool ascendingOrder = true)
        {
            var purchases = _purchaseRepository.GetAllWithTotalCostGreaterThan(totalCost, ascendingOrder);
            return FormatPurchases(purchases);
        }
    }
}
