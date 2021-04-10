using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace AltHealth.Data.Gateways.Repositories
{
    public abstract class RepositoryBase<T>
        where T : class
    {
        private HealthEntities dataContext;
        private readonly DbSet<T> Table;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected HealthEntities DbContext => dataContext = dataContext ?? DbFactory.Init();

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            Table = DbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            Table.Add(entity);
            Commit();
            return entity;
        }
        public virtual void Update(T entity, object key)
        {
            var entityToUpdate = Table.Find(key);
            if (entityToUpdate != null)
            {
                DbContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                Commit();
            }
        }
        public virtual void Update(T entity, object[] keyValues)
        {
            var entityToUpdate = Table.Find(keyValues);
            if(entityToUpdate != null)
            {
                DbContext.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                Commit();
            }
        }

        public virtual T GetById(object id) => Table.Find(id);
        public virtual T GetById(object[] keyValues) => Table.Find(keyValues);
        public virtual List<T> ListAll() => Table.ToList();
        public virtual void Delete(T entity)
        {
            Table.Remove(entity);
            Commit();
        }
        private void Commit()
        {
            try
            {

                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = Table;
            query = query.Where(where);
            return query.ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return List(where).FirstOrDefault();
        }
    }
}
