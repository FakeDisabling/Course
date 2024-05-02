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
using System.Xml.Linq;

namespace BLL.Services
{
    public class DevelopersService : IDevelopersService
    {
        private IMapper developersMapper;
        private IDevelopers developersService;

        public DevelopersService(IMapper commentMapper, IDevelopers commentService)
        {
            this.developersMapper = commentMapper;
            this.developersService = commentService;
        }

        public void Add(DevelopersDTO service)
        {
            var item = developersMapper.Map<Developers>(service);
            developersService.Add(item);
        }

        public void DeleteById(DevelopersDTO service)
        {
            var item = developersMapper.Map<Developers>(service);
            developersService.Delete(item);
        }

        public DevelopersDTO FindById(int id)
        {
            return developersMapper.Map<DevelopersDTO>(developersService.GetById(id));
        }

        public List<DevelopersDTO> GetAll()
        {
            return developersMapper.Map<List<DevelopersDTO>>(developersService.GetAll());
        }

        public void Update(DevelopersDTO service)
        {
            var item = developersMapper.Map<Developers>(service);
            developersService.Update(item);
        }
    }
}
