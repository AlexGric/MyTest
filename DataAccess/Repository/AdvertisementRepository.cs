using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(AdvertisementContext context) : base(context) { }
        async Task<IReadOnlyCollection<Advertisement>> IAdvertisementRepository.FindAdvertisementByConditionAllIncludedAsync(Expression<Func<Advertisement, bool>> advertisementPredicate)
        {
            return await Entities.Where(advertisementPredicate).ToListAsync().ConfigureAwait(false);           
        }

        async Task<IReadOnlyCollection<Advertisement>> IAdvertisementRepository.FindAllAdvertisementsAllIncludedAsync()
        {
            return await Entities.ToListAsync().ConfigureAwait(false);
        }

        async Task<Advertisement> IAdvertisementRepository.GetAdvertisementAllIncludedAsync(Expression<Func<Advertisement, bool>> advertisementPredicate)
        {
            return await AdvertisementContext.Advertisements.Where(advertisementPredicate).FirstOrDefaultAsync();
        }
        public override async Task<Advertisement> CreateAsync(Advertisement advertisement)
        {
            await AdvertisementContext.Advertisements.AddAsync(advertisement);
            await AdvertisementContext.SaveChangesAsync();
            return advertisement;
        }

        public async Task Delete(Expression<Func<Models.Advertisement, bool>> advertisementPredicate)
        {
            Advertisement advertisement = (Advertisement)await FindByConditionAsync(x=>x.Equals(advertisementPredicate));
            if (advertisement != null) AdvertisementContext.Remove(advertisement);
            await AdvertisementContext.SaveChangesAsync();
        }
    }
}
