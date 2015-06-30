using System;
using System.Linq;
using DF.Infrastructure.CQRS;
using DF.Infrastructure.Data;

namespace DF.Domain.Registrations
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
    {
        private readonly IRepository<User, int> _repository;

        public RegisterNewUserCommandHandler(IRepository<User, int> repository)
        {
            _repository = repository;
        }

        public void Execute(RegisterNewUserCommand command)
        {
            if (this._repository.FindBy(x => x.Email.Equals(command.Email)).FirstOrDefault() != null)
            {
                throw new UserAlreadyRegisteredExpcetion();
            }

            this._repository.Save(new User()
            {
                Email = command.Email,
                IsActive = true,
                Password = command.Password,
                RegisteredOn = DateTime.Now
            });
        }
    }
}