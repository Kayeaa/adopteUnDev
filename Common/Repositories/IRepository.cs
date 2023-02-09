using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    public interface IRepository <TEntity, Tid>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(Tid id);

        Tid Insert(TEntity entity);

        bool Delete(Tid id);

        bool Update(Tid id, TEntity entity);
    }
}
