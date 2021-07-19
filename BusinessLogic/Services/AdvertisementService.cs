using AutoMapper;
using BusinessLogic.Responses;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AdvertisementService
    {
        private IAdvertisementRepository _advertisementRepository { set; get; }
        private IMapper _mapper { set; get; }
        public CategoryService CategoryService { set; get; }
        public AdvertisementService(IAdvertisementRepository advertisementRepository,  CategoryService categoryService)
        {
            _advertisementRepository = advertisementRepository;            
            CategoryService = categoryService;
            this._mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataAccess.Models.Advertisement, ViewModels.Advertisement>();
                cfg.CreateMap<DataAccess.Models.Category, ViewModels.Category>();

            }).CreateMapper();
        }
        public async Task<IReadOnlyCollection<ViewModels.Advertisement>> FindByConditionAsync(Expression<Func<DataAccess.Models.Advertisement, bool>> predicat)
        {
            return await _mapper.Map<Task<IReadOnlyCollection<DataAccess.Models.Advertisement>>, Task<IReadOnlyCollection<ViewModels.Advertisement>>>((Task<IReadOnlyCollection<DataAccess.Models.Advertisement>>)await _advertisementRepository.FindByConditionAsync(predicat));
        }

        public async Task<IReadOnlyCollection<ViewModels.Advertisement>> GetAllAsync()
        {
            return await _mapper.Map<Task<IReadOnlyCollection<DataAccess.Models.Advertisement>>, Task<IReadOnlyCollection<ViewModels.Advertisement>>>((Task<IReadOnlyCollection<DataAccess.Models.Advertisement>>)await _advertisementRepository.GetAllAsync());
        }

        public async Task<Response<ViewModels.Advertisement>> CreateAsync(ViewModels.Advertisement advertisement)
        {
            try
            {
               
                DataAccess.Models.Advertisement ad = _mapper.Map<ViewModels.Advertisement, DataAccess.Models.Advertisement>(advertisement);
                ViewModels.Advertisement newAdvertisement = _mapper.Map<DataAccess.Models.Advertisement, ViewModels.Advertisement>(await _advertisementRepository.CreateAsync(ad));
                return new Response<ViewModels.Advertisement>(newAdvertisement);
            }
            catch (Exception e)
            {
                string errorMessage = "An error occured while creating new Advertisement";
                return new Response<ViewModels.Advertisement>(errorMessage);
            }
        }

        public async Task Delete(ViewModels.Advertisement advertisement)
        {
            DataAccess.Models.Advertisement ad = _mapper.Map<ViewModels.Advertisement, DataAccess.Models.Advertisement>(advertisement);
            await _advertisementRepository.Delete(x => x.Equals(ad));
           
        }


    }
}
