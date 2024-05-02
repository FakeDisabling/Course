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
    public class ClientService : IClientService
    {
        private IMapper clientMapper;
        private IClient clientService;

        public ClientService(IMapper clientMapper, IClient clientService)
        {
            this.clientMapper = clientMapper;
            this.clientService = clientService;
        }

        public void Add(ClientDTO service)
        {
            var item = clientMapper.Map<Client>(service);
            clientService.Add(item);
        }

        public void DeleteById(ClientDTO service)
        {
            var item = clientMapper.Map<Client>(service);
            clientService.Delete(item);
        }

        public ClientDTO FindById(int id)
        {
            return clientMapper.Map<ClientDTO>(clientService.GetById(id));
        }

        public List<ClientDTO> GetAll()
        {
            return clientMapper.Map<List<ClientDTO>>(clientService.GetAll());
        }

        public void Update(ClientDTO service)
        {
            var item = clientMapper.Map<Client>(service);
            clientService.Update(item);
        }
    }
}
