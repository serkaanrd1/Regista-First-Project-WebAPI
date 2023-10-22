using DataAcsess.implemantations.EF.Context;
using DataAcsess.implemantations.interfaces;
using infrastructure.DataAccses.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.implemantations.Repositories
{
    public class ProductRepository : BaseRepository<Product, RegistaContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int productId, params string[] includeList)
        {
            return await GetAsync(p=> p.ProductID == productId,includeList);
        }

        public async Task<List<Product>> GetByStockAsync(short min, short max, params string[] includeList)
        {
            return await GetAllAsync(p => p.UnitsInStock > min && p.UnitsInStock < max, includeList);
        }
    }
}
