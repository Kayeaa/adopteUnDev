using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    public interface IDeveloperRepository<TEntity, Tid> : IRepository<TEntity, Tid> where TEntity : IDeveloper
    {

    }
}
