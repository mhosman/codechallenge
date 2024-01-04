using DevCodeChallenge.Models;
using FluentNHibernate.Mapping;

namespace DevCodeChallenge.Mappings
{
    public class PurchaseMap : ClassMap<Purchase>
    {
        public PurchaseMap()
        {
            Table("purchases");
            Id(x => x.Id, "id").GeneratedBy.Native();
            Map(x => x.Quantity, "quantity");
            Map(x => x.TotalCost, "total_cost");
            Map(x => x.Date, "date");
        }
    }
}
