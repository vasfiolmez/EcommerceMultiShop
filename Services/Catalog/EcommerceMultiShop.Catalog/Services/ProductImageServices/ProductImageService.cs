using AutoMapper;
using EcommerceMultiShop.Catalog.Dtos.ProductImageDtos;
using EcommerceMultiShop.Catalog.Entities;
using EcommerceMultiShop.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceMultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _categoryCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
