using Business.implementations;
using Business.interfaces;
using DataAcsess.implemantations.interfaces;
using DataAcsess.implemantations.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class ServicesCollectionExensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductBs));


            services.AddScoped<IProductBs, ProductBs>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();
        }
    }
}
