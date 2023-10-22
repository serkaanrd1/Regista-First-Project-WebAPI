using infrastructure.Utilities;
using Model.Dto.ProductDtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IProductBs
    {
        Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList);
        Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList);

        Task<ApiResponse<Product>> InsertAsync(ProductPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
