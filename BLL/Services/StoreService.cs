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
    public class StoreService : IStoreService
    {
        private IMapper storeMapper;
        private IStore storeService;

        public StoreService(IMapper storeMapper, IStore storeService)
        {
            this.storeMapper = storeMapper;
            this.storeService = storeService;
        }

        public void Add(StoreDTO service)
        {
            var item = storeMapper.Map<Store>(service);
            storeService.Add(item);
        }

        public void DeleteById(StoreDTO service)
        {
            var item = storeMapper.Map<Store>(service);
            storeService.Delete(item);
        }

        public StoreDTO FindById(int id)
        {
            return storeMapper.Map<StoreDTO>(storeService.GetById(id));
        }

        public List<StoreDTO> GetAll()
        {
            return storeMapper.Map<List<StoreDTO>>(storeService.GetAll());
        }

        public void Update(StoreDTO service)
        {
            var item = storeMapper.Map<Store>(service);
            storeService.Update(item);
        }
    }
}
