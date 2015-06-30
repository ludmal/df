using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DF.Domain.Registrations;
using DF.Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DF.Tests
{
    [TestClass]
    public class RegistrationTests
    {
        private RegisterNewUserCommandHandler _handler = null;
        private IRepository<User, int> _repo = null;

        [TestInitialize]
        public void Initialize()
        {
            this._repo = new EntityRepository<User, int, RegistrationContext>();
            this._handler = new RegisterNewUserCommandHandler(_repo);
        }
        
        [TestMethod]
        public void register_new_user()
        {
            var command = new RegisterNewUserCommand()
            {
                Email = "ludmal@gmail.com",
                Password = "pass"
            };
            
            _handler.Execute(command);
            Assert.IsTrue(_repo.FindBy(x => x.Email == command.Email).FirstOrDefault() != null);
        }
    }
}
