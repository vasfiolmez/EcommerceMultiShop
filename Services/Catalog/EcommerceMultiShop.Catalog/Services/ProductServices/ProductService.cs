using AutoMapper;
using EcommerceMultiShop.Catalog.Dtos.ProductDtos;
using EcommerceMultiShop.Catalog.Entities;
using EcommerceMultiShop.Catalog.Settings;
using MongoDB.Driver;

namespace EcommerceMultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly Mapper _mapper;

        public ProductService(Mapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _productsCollection=database.GetCollection<Product>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values=_mapper.Map<Product>(createProductDto);
            await _productsCollection.InsertOneAsync(values);
        }
        public async Task DeleteProductAsync(string id)
        {
           await _productsCollection.DeleteOneAsync(x=>x.ProductId==id);
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var values=await _productsCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productsCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productsCollection.FindOneAndReplaceAsync(x=>x.ProductId==updateProductDto.ProductId, values);
        }
    }
}
