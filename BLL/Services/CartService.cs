using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private IMapper cartMapper;
        private ICart cartService;

        public CartService(IMapper cartMapper, ICart cartService)
        {
            this.cartMapper = cartMapper;
            this.cartService = cartService;
        }

        public void Add(CartDTO service)
        {
            var item = cartMapper.Map<Cart>(service);
            cartService.Add(item);
        }

        public void DeleteById(CartDTO service)
        {
            var item = cartMapper.Map<Cart>(service);
            cartService.Delete(item);
        }

        public CartDTO FindById(int id)
        {
            return cartMapper.Map<CartDTO>(cartService.GetById(id));
        }

        public List<CartDTO> GetAll()
        {
            return cartMapper.Map<List<CartDTO>>(cartService.GetAll());
        }

        public void Update(CartDTO service)
        {
            var item = cartMapper.Map<Cart>(service);
            cartService.Update(item);
        }
    }
}
