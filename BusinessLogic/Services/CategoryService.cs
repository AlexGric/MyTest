using AutoMapper;
using BusinessLogic.Responses;
using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoryService
    {
        private ICategoryRepository _categoryRepository { set; get; }
        private IMapper _mapper { set; get; }
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            this._mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataAccess.Models.Category, ViewModels.Category>();
                cfg.CreateMap<DataAccess.Models.Category, ViewModels.Category>();

            }).CreateMapper();
        }
        public async Task<IReadOnlyCollection<ViewModels.Category>> FindByConditionAsync(Expression<Func<DataAccess.Models.Category, bool>> predicat)
        {
            return await _mapper.Map<Task<IReadOnlyCollection<DataAccess.Models.Category>>, Task<IReadOnlyCollection<ViewModels.Category>>>((Task<IReadOnlyCollection<DataAccess.Models.Category>>)await _categoryRepository.FindByConditionAsync(predicat));
        }

        public async Task<IReadOnlyCollection<ViewModels.Category>> GetAllAsync()
        {
            return await _mapper.Map<Task<IReadOnlyCollection<DataAccess.Models.Category>>, Task<IReadOnlyCollection<ViewModels.Category>>>((Task<IReadOnlyCollection<DataAccess.Models.Category>>)await _categoryRepository.GetAllAsync());
        }

        public async Task<Response<ViewModels.Category>> CreateAsync(ViewModels.Category category)
        {
            try
            {

                DataAccess.Models.Category ad = _mapper.Map<ViewModels.Category, DataAccess.Models.Category>(category);
                ViewModels.Category newCategory = _mapper.Map<DataAccess.Models.Category, ViewModels.Category>(await _categoryRepository.CreateAsync(ad));
                return new Response<ViewModels.Category>(newCategory);
            }
            catch (Exception e)
            {
                string errorMessage = "An error occured while creating new Category";
                return new Response<ViewModels.Category>(errorMessage);
            }
        }

        public async Task Delete(ViewModels.Category category)
        {
            DataAccess.Models.Category ad = _mapper.Map<ViewModels.Category, DataAccess.Models.Category>(category);
            await _categoryRepository.Delete(x => x.Equals(ad));

        }
    }
}
