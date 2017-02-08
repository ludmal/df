using System.Data.Entity;

namespace DF.Domain
{
    public class DealContext : DbContext
    {
        public IDbSet<ActiveDeal> ActiveDeals { get; set; }
        public IDbSet<PartnerDeals> PartnerDeals { get; set; }
        public IDbSet<DfUser> Users { get; set; }
        public IDbSet<FavDeal> FavDeals { get; set; }
        public IDbSet<FavDeals> FavDealList { get; set; }

        public DealContext() : base("connection")
        {
            Database.SetInitializer<DealContext>(null);
        }
    }
}