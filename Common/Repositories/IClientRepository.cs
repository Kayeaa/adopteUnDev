using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    public interface IClientRepository<TEntity, Tid> : IRepository<TEntity, Tid>
        where TEntity : IClient
    {
        int ? CheckPassword(string CliLogin, string CliPassword);
    }
}
