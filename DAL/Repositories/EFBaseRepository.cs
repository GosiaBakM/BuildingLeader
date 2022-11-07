using DAL.Repositories.Interfaces;
using DAL.Storage.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFBaseRepository : IRepository
    {
        protected BLeaderContext Context { get; }

        public EFBaseRepository(BLeaderContext context)
        {
            Context = context;
        }
    }

    public class EFBaseRepository<TEntity> : EFBaseRepository, IRepository<TEntity> where TEntity : class
    {
        public EFBaseRepository(BLeaderContext context) : base(context)
        {
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
    }
}
