

namespace Visa.BL.Interface
{
    public interface IUnitOfWork
    {
        bool Save();
        Task<bool> SaveAsync();
    }
}
