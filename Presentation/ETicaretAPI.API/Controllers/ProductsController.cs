using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),Name="Product 1",Price=100L,Stock=10,CreatedDate=DateTime.UtcNow},
                new(){Id=Guid.NewGuid(),Name="Product 2",Price=200L,Stock=20,CreatedDate=DateTime.UtcNow},
                new(){Id=Guid.NewGuid(),Name="Product 3",Price=300L,Stock=30,CreatedDate=DateTime.UtcNow},
                new(){Id=Guid.NewGuid(),Name="Product 4",Price=400L,Stock=40,CreatedDate=DateTime.UtcNow},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
