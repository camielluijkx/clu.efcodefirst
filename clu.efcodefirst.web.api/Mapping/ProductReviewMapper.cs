using AutoMapper;
using clu.efcodefirst.web.api.Models;

namespace clu.efcodefirst.web.api.Mapping
{
    public class ProductReviewMapper : ObjectMapper, IProductReviewMapper
    {
        protected override void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Product, ProductDetailsDto>();
            config.CreateMap<Review, ReviewDetailsDto>();

            config.CreateMap<ProductDetailsDto, Product>()
                .ForMember(p => p.ProductId, q => q.Ignore());
            config.CreateMap<ReviewDetailsDto, Review>()
                .ForMember(p => p.ProductId, q => q.Ignore())
                .ForMember(p => p.ReviewId, q => q.Ignore())
                .ForMember(p => p.Product, q => q.Ignore());
        }
    }
}