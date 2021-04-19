using System.Collections.Generic;

namespace SSP.Domain
{
    public class ProfileDomain : DomainBase
    {
        public string Name { get; set; }

        public ICollection<UserDomain> Users { get; set; }
    }
}