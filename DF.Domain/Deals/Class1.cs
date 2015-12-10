using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Domain
{
    [Table("VW_NewDeals")]
    public class ActiveDeal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DealDesc { get; set; }
        public string DealImage { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal SortOrder { get; set; }
        public string DealSlug { get; set; }
        public string CatSlug { get; set; }

    }

    public class DealContext : DbContext
    {
        public IDbSet<ActiveDeal> ActiveDeals { get; set; }

        public DealContext() : base("connection")
        {
            Database.SetInitializer<DealContext>(null);
        }
    }
    public class Class1
    {
    }
}
