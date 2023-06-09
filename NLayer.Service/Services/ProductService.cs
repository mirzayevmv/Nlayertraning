using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using NLayer.Repository.Repositories;

namespace NLayer.Service.Services;

public class ProductService:Service<Product>,IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,IProductRepository productRepository,IMapper mapper) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<ProductWithCategory>>> GetProductsWithCategory()
    {
        var products = await _productRepository.GetProductsWithCategoryAsync();
        var productsDto = _mapper.Map<List<ProductWithCategory>>(products);
        return CustomResponseDto<List<ProductWithCategory>>.Success(productsDto,200);

    }
}