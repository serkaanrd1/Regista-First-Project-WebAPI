using AutoMapper;
using Business.CustomExceptions;
using Business.interfaces;
using DataAcsess.implemantations.interfaces;
using infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Model.Dto.ProductDtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.implementations
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("id değeri pozitif ve geçerli bir değer olmalıdır.");
            }
            var entity = await _repo.GetByIdAsync(id);
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Sucsess(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList)
        {
            if (productId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var product = await _repo.GetByIdAsync(productId, includeList);

            if (product == null)
                throw new NotFoundException("Böyle bir ürün bulunamadı.(REGİSTA)");

            var dto = _mapper.Map<ProductGetDto>(product);

            return ApiResponse<ProductGetDto>.Sucsess(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList)
        {
            var products = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);

                return ApiResponse<List<ProductGetDto>>.Sucsess(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("stok değerleri pozitif değer olmalıdır");


            var products = await _repo.GetByStockAsync(min, max, includeList);
            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);

                return ApiResponse<List<ProductGetDto>>.Sucsess(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Product>> InsertAsync(ProductPostDto dto)
        {
            if (dto.ProductName.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

            


            var entity = _mapper.Map<Product>(dto);
            entity.IsActive = true;



            var insertedProduct = await _repo.InsertAsync(entity);

            return ApiResponse<Product>.Sucsess(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto dto)
        {
            if (dto.ProductID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");

            if (dto.ProductName.Length < 2)
                throw new BadRequestException("ürün adı en az 2 karakterden oluşmalıdır");

            if (dto.UnitsInStock <= 0)
                throw new BadRequestException("ürün stoğu pozitif bir değer olmalıdır");



            var entity = _mapper.Map<Product>(dto);
            entity.IsActive = true;


            await _repo.UpdateAsync(entity);


            return ApiResponse<NoData>.Sucsess(StatusCodes.Status200OK);
        }
    }
}
