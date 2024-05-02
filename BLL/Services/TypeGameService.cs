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
    public class TypeGameService : ITypeGameService
    {
        private IMapper typeGameMapper;
        private ITypeGame typeGameService;

        public TypeGameService(IMapper typeGameMapper, ITypeGame typeGameService)
        {
            this.typeGameMapper = typeGameMapper;
            this.typeGameService = typeGameService;
        }

        public void Add(TypeGameDTO service)
        {
            var item = typeGameMapper.Map<TypeGame>(service);
            typeGameService.Add(item);
        }

        public void DeleteById(TypeGameDTO service)
        {
            var item = typeGameMapper.Map<TypeGame>(service);
            typeGameService.Delete(item);
        }

        public TypeGameDTO FindById(int id)
        {
            return typeGameMapper.Map<TypeGameDTO>(typeGameService.GetById(id));
        }

        public List<TypeGameDTO> GetAll()
        {
            return typeGameMapper.Map<List<TypeGameDTO>>(typeGameService.GetAll());
        }

        public void Update(TypeGameDTO service)
        {
            var item = typeGameMapper.Map<TypeGame>(service);
            typeGameService.Update(item);
        }
    }
}
