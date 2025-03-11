using AutoMapper;
using EcommerceMultiShop.Catalog.Dtos.CategoryDtos;
using EcommerceMultiShop.Catalog.Dtos.ProductDetailDtos;
using EcommerceMultiShop.Catalog.Dtos.ProductDtos;
using EcommerceMultiShop.Catalog.Dtos.ProductImageDtos;
using EcommerceMultiShop.Catalog.Entities;

namespace EcommerceMultiShop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();

            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage,UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage,CreateProductImageDto>().ReverseMap();
        }
    }
}
