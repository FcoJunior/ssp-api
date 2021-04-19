using System;
using Microsoft.EntityFrameworkCore;
using SSP.Infra.Data.Entity;

namespace SSP.Infra.Data
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
     
        DbSet<UserEntity> User { get; set; }
        DbSet<ProfileEntity> Profile { get; set; }
    }
}