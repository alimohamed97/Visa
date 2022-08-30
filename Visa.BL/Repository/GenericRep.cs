using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Visa.BL.Interface;
using Visa.DAL.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Visa.BL.Repository
{
    public class GenericRep<TEntity> : IGenericRep<TEntity> where TEntity : class
    {


        private readonly ApplicationContext Context;
        private DbSet<TEntity> dbSet;

        public GenericRep(ApplicationContext Context)
        {
            this.Context = Context;
            this.dbSet = Context.Set<TEntity>();
        }



        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            
            IQueryable<TEntity> data=dbSet;


            if (filter != null)
            {
                if(includeProperties != "")
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        data = data.Where(filter).Include(includeProperty);
                    }
                }

                data = data.Where(filter);
            }
            else
            {

                if (includeProperties != "")
                {
                    foreach (var includeProperty in includeProperties.Split
                                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        data = data.Include(includeProperty);
                    }
                }
            }


            return data.ToList();
        }


        //public async Task GetLast(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        //{
        //    var data = dbSet.OrderByDescending(orderBy);
        //}
        public async Task<TEntity> GetByIDAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {

            if (includeProperties != "")
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                       var data = dbSet.Where(filter).Include(includeProperty).FirstOrDefault();
                    }
                }
            
            return  dbSet.Where(filter).FirstOrDefault(); 
        }


        public async Task InsertAsync(TEntity model)
        {
           await dbSet.AddAsync(model);
        }

        public void Update(TEntity model)
        {
            dbSet.Attach(model);
            Context.Update(model);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity oldData = await dbSet.FindAsync(id);
            dbSet.Remove(oldData);
        }
    }
}
