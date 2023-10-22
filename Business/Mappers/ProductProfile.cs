using AutoMapper;
using Model.Dto.ProductDtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
   public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            {
                CreateMap<Product, ProductGetDto>()

                 .ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.ProductName == null
                                    ? ""
                                    : src.ProductName.ToUpper()))
          


                 .ReverseMap();


            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();

        }

    }
}
}
