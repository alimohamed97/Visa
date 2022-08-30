using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Visa.BL.Interface
{
    public interface IGenericRep<TEntity> where TEntity : class 
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,string includeProperties = "");
        Task<TEntity> GetByIDAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        Task InsertAsync(TEntity model);
        void Update(TEntity model);
        Task DeleteAsync(int id);

    }

}
