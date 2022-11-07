namespace DAL.Repositories.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository
    {
        //add some methods

        public void Add(TEntity entity);
        //public virtual TEntity GetAll(TEntity entity);
    }
}