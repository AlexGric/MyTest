using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategory
    {
        public CategoryRepository(AdvertisementContext context) : base(context)
        {
        }

        async Task<IReadOnlyCollection<Category>> ICategory.FindAllCategorysAllIncludedAsync()
        {
            return await Entities.ToListAsync().ConfigureAwait(false);
        }

        async Task<IReadOnlyCollection<Category>> ICategory.FindCategoryByConditionAllIncludedAsync(Expression<Func<Category, bool>> categoryPredicate)
        {
            return await Entities.Where(categoryPredicate).ToListAsync().ConfigureAwait(false);
        }

        async Task<Category> ICategory.GetCategoryAllIncludedAsync(Expression<Func<Category, bool>> categoryPredicate)
        {
            return await AdvertisementContext.Categories.Where(categoryPredicate).FirstOrDefaultAsync();
        }

        public override async Task<Category> CreateAsync(Category category)
        {
            await AdvertisementContext.Categories.AddAsync(category);
            await AdvertisementContext.SaveChangesAsync();
            return category;
        }
    }
}
