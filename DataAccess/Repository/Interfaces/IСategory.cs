using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IСategory : IRepository<Models.Category>
    {
        Task<IReadOnlyCollection<Models.Category>> FindAllCategorysAllIncludedAsync();
        Task<IReadOnlyCollection<Models.Category>> FindCategoryByConditionAllIncludedAsync(Expression<Func<Models.Category, bool>> categoryPredicate);
        Task<Models.Category> GetCategoryAllIncludedAsync(Expression<Func<Models.Category, bool>> taskPredicate);
    }
}
