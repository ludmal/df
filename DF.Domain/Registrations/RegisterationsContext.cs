using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DF.Domain.Registrations
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext()
            : base("connection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
