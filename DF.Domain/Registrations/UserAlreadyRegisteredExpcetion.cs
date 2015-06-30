using System;

namespace DF.Domain.Registrations
{
    public class UserAlreadyRegisteredExpcetion : Exception
    {
        public UserAlreadyRegisteredExpcetion(): base("User already registered")
        {
            
        }
    }
}