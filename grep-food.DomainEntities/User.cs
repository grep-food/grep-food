using System;
using System.Security;

namespace grep_food.DomainEntities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        protected SecureString Password { private get; set; }

        public string Email { get; set; }

        //eventual adaugam data nasterii sau varsta
    }
}
