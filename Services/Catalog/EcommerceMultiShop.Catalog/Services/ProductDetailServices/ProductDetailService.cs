using AutoMapper;
using EcommerceMultiShop.Catalog.Dtos.ProductDetailDtos;
using EcommerceMultiShop.Catalog.Entities;
using EcommerceMultiShop.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceMultiShop.Catalog.Services.ProductDetailDetailServices
{
    public class ProductDetailService:IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productsDetailCollection;
        private readonly Mapper _mapper;

        public ProductDetailService(Mapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productsDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productsDetailCollection.InsertOneAsync(values);
        }
        public async Task DeleteProductDetailAsync(string id)
        {
            await _productsDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }
        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productsDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }
        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productsDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }
        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productsDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}
