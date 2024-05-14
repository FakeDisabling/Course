using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDTO>().ReverseMap();
        }
    }
}
