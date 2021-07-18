using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IAdvertisementRepository : IRepository<Models.Advertisement>
    {
        Task<IReadOnlyCollection<Models.Advertisement>> FindAllAdvertisementsAllIncludedAsync();
        Task<IReadOnlyCollection<Models.Advertisement>> FindAdvertisementByConditionAllIncludedAsync(Expression<Func<Models.Advertisement, bool>> advertisementPredicate);
        Task<Models.Advertisement> GetAdvertisementAllIncludedAsync(Expression<Func<Models.Advertisement, bool>> advertisementPredicate);
        Task DeleteById(int id);
    }
}
