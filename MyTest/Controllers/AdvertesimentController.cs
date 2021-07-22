using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MyTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertesimentController : Controller
    {
        private readonly IConfiguration _config;

        private AdvertisementService _advertesimentService { get; set; }
        private CategoryService _categoryService { get; set; }

        public AdvertesimentController(IConfiguration config, AdvertisementService advertesimentService, CategoryService categoryService)
        {
            _config = config;
            _advertesimentService = advertesimentService;
            _categoryService = categoryService;
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currrentAdvertisement = (await _advertesimentService.GetAllAsync());
            return Ok(currrentAdvertisement);
        }

        [HttpGet]
        public async Task<IActionResult> Get(BusinessLogic.ViewModels.Advertisement advertisement)
        {
            if (advertisement != null)
            {
                var currrentAdvertisement = (await _advertesimentService.FindByConditionAsync(x => x.Equals(advertisement)));
                return Ok(currrentAdvertisement);
            }
            return BadRequest();
        }

        #endregion Get

        #region Post

        [HttpPost]
        public async Task<IActionResult> Post(BusinessLogic.ViewModels.Advertisement advertisement)
        {
            if (advertisement != null)
            {
                var currrentAdvertisement = (await _advertesimentService.CreateAsync(advertisement));
                return Ok(currrentAdvertisement);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessLogic.ViewModels.Category category)
        {
            if (category != null)
            {
                var currrentCategory = (await _categoryService.CreateAsync(category));
                return Ok(currrentCategory);
            }
            return BadRequest();
        }

        #endregion Post

        #region Delete

        [HttpDelete]
        public async Task<IActionResult> Delete(BusinessLogic.ViewModels.Advertisement advertisement)
        {
            if (advertisement != null)
            {
                await _advertesimentService.Delete(advertisement);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BusinessLogic.ViewModels.Category category)
        {
            if (category != null)
            {
                await _categoryService.Delete(category);
                return Ok();
            }
            return BadRequest();
        }

        #endregion Delete
    }
}