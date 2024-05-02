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
    public class UserService : IUserService
    {
        private IMapper userMapper;
        private IUser userService;

        public UserService(IMapper userMapper, IUser userService)
        {
            this.userMapper = userMapper;
            this.userService = userService;
        }

        public void Add(UserDTO service)
        {
            var item = userMapper.Map<User>(service);
            userService.Add(item);
        }

        public void DeleteById(UserDTO service)
        {
            var item = userMapper.Map<User>(service);
            userService.Delete(item);
        }

        public UserDTO FindById(string id)
        {
            return userMapper.Map<UserDTO>(userService.GetById(id));
        }

        public List<UserDTO> GetAll()
        {
            return userMapper.Map<List<UserDTO>>(userService.GetAll());
        }

        public void Update(UserDTO service)
        {
            var item = userMapper.Map<User>(service);
            userService.Update(item);
        }
    }
}
