using System;

namespace SSP.Infra.Data.Entity
{
    public class UserEntity : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Enable { get; set; }
        public string Password { get; set; }
        public Guid ProfileId { get; set; }

        public virtual ProfileEntity Profile { get; set; }
    }
}