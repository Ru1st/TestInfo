using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace TestInfoTecs.Models
{
    public class BaseRepo<T>
        where T: class, new()
    {
        public RegistrationContext Context { get; } = new RegistrationContext();

        protected DbSet<T> Table;

        public T Find(int? id) => Table.Find(id);
        public List<T> GetAll() => Table.ToList();
        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }
        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        protected int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateException) { throw; }
            catch (CommitFailedException) { throw; }
            catch (Exception) { throw; }
        }
    }
}