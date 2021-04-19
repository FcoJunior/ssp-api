using System;

namespace SSP.Domain.Repository
{
    public interface IUserRepository
    {
        Guid Insert(UserDomain user);
        UserDomain GetUserByLogin(string email, string password);
    }
}