using Microsoft.EntityFrameworkCore;
using FinPe.Model.Context;
using FinPe.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinPe.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MysqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MysqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T CriarNovo(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.codigo.Equals(id));

            try
            {
                if (result != null)
                    dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return dataset.Any(p => p.codigo.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.codigo.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exist(item.codigo)) return null;

            var result = dataset.SingleOrDefault(p => p.codigo.Equals(item.codigo));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
