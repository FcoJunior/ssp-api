using System;

namespace SSP.Domain
{
    public class UserDomain : DomainBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Enable { get; set; }
        public Guid ProfileId { get; set; }

        public ProfileDomain Profile { get; set; }
    }
}