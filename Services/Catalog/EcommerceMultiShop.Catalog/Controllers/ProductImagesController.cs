using EcommerceMultiShop.Catalog.Dtos.ProductImageDtos;
using EcommerceMultiShop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImagesList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesById(string id)
        {
            var values =await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImages(CreateProductImageDto createProductImagesDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImagesDto);
            return Ok("Başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImages(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Başarıyla Silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImageDto updateProductImagesDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImagesDto);
            return Ok("başarıyla güncellendi");
        }
    }
}
