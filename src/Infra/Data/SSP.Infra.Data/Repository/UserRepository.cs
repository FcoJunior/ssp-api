using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSP.Domain;
using SSP.Domain.Repository;
using SSP.Infra.Data.Entity;

namespace SSP.Infra.Data.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IContext context, IMapper mapper) 
            : base(context, mapper) { }

        public UserDomain GetUserByLogin(string email, string password)
        {
            var query = this._context.User
                .Include(x => x.Profile)
                .Where(x => x.Email.Equals(email))
                .Where(x => x.Password.Equals(password))
                .SingleOrDefault();

            return this._mapper.Map<UserDomain>(query);
        }

        public Guid Insert(UserDomain user)
        {
            var entity = this._mapper.Map<UserEntity>(user);
            this._context.User.Add(entity);
            this._context.SaveChanges();
            return entity.Id;
        }
    }
}