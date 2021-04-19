using System.Collections.Generic;

namespace SSP.Infra.Data.Entity
{
    public class ProfileEntity : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}