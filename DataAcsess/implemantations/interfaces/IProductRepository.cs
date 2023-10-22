using infrastructure.DataAccses.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.implemantations.interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetByStockAsync(short min, short max, params string[] includeList);
        Task<Product> GetByIdAsync(int productId, params string[] includeList);
    }
}
