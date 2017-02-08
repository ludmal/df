using System;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Table("vw_fav")]
    public class FavDeals
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string DealDesc { get; set; }
        public DateTime AddedDate { get; set; }
        public string DealSlug { get; set; }

    }

    [Table("Favs")]
    public class FavDeal
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int DealId { get; set; }
    }

    [Table("VW_PartnerDeals")]
    public class PartnerDeals
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DealDesc { get; set; }
        public string DealImage { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal SortOrder { get; set; }
        public string DealSlug { get; set; }
        public string PartnerSlug { get; set; }

    }
}