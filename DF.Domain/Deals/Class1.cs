using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Domain
{
    [Table("USERS")]
    public class DfUser
    {
        [Column("USR_ID")]
        public int Id { get; set; }
        [Column("USR_AUTH_CODE")]
        public string AuthCode { get; set; }
        [Column("USR_USERNAME")]
        public string Username { get; set; }
        [Column("USR_PASSWORD")]
        public string Password { get; set; }
        [Column("USR_TITLE")]
        public string Title { get; set; }
        [Column("USR_FIRST_NAME")]
        public string FirstName { get; set; }
        [Column("USR_LAST_NAME")]
        public string LastName { get; set; }
        [Column("CITY_ID")]
        public int CityId { get; set; }
        [Column("URS_EMAIL")]
        public string UserEmail { get; set; }
        [Column("USR_MOBILE_NO")]
        public string MobileNo { get; set; }
        [Column("URS_AGE_GROUP")]
        public string AgeGroup { get; set; }
        [Column("URS_GENDER")]
        public string UserGender { get; set; }
        [Column("CAT_ID")]
        public string CatId { get; set; }
        [Column("PAR_ID")]
        public string ParId { get; set; }
        [Column("VEN_ID")]
        public string VenId { get; set; }
        [Column("USR_SMS_ALERT")]
        public bool SmsAlert { get; set; }
        [Column("USR_EMAIL_ALERT")]
        public bool EmailAlert { get; set; }
        [Column("USR_NEWSLETTER")]
        public bool NewsLetter { get; set; }
        [Column("USR_DATE_CREATED")]
        public DateTime DateCreated { get; set; }
        [Column("USR_ACTIVE")]
        public bool UserActive { get; set; }
    }
    public class Class1
    {
    }
}
