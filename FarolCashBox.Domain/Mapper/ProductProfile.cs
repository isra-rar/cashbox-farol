using AutoMapper;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductResponse>();
                
        }
    }
}
