using DevCodeChallenge.Models;
using NHibernate;
using System.Collections.Generic;

namespace DevCodeChallenge.Repositories
{
    public class PurchaseRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public PurchaseRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IList<Purchase> GetAll(bool ascendingOrder = true)
        {
            return GetPurchasesQuery(ascendingOrder).List();
        }

        public IList<Purchase> GetAllWithTotalCostGreaterThan(decimal totalCost, bool ascendingOrder = true)
        {
            return GetPurchasesQuery(ascendingOrder)
                .Where(p => p.TotalCost > totalCost)
                .List();
        }

        private IQueryOver<Purchase, Purchase> GetPurchasesQuery(bool ascendingOrder)
        {
            var session = _sessionFactory.OpenSession();
            var query = session.QueryOver<Purchase>();

            return ascendingOrder
                ? query.OrderBy(p => p.Date).Asc
                : query.OrderBy(p => p.Date).Desc;
        }
    }
}