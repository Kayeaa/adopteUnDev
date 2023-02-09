using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    public interface ICategoryRepository<TEntity, Tid> : IRepository<TEntity, Tid> where TEntity : ICategories
    {
    }
}
