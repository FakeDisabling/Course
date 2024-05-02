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
    public class CommentsService : ICommentsService
    {
        private IMapper commentMapper;
        private IDevelopersGames commentsService;

        public CommentsService(IMapper commentMapper, IDevelopersGames commentService)
        {
            this.commentMapper = commentMapper;
            this.commentsService = commentService;
        }

        public void Add(DevelopersGamesDTO service)
        {
            var item = commentMapper.Map<DevelopersGames>(service);
            commentsService.Add(item);
        }

        public void DeleteById(DevelopersGamesDTO service)
        {
            var item = commentMapper.Map<DevelopersGames>(service);
            commentsService.Delete(item);
        }

        public DevelopersGamesDTO FindById(int id)
        {
            return commentMapper.Map<DevelopersGamesDTO>(commentsService.GetById(id));
        }

        public List<DevelopersGamesDTO> GetAll()
        {
            return commentMapper.Map<List<DevelopersGamesDTO>>(commentsService.GetAll());
        }

        public void Update(DevelopersGamesDTO service)
        {
            var item = commentMapper.Map<DevelopersGames>(service);
            commentsService.Update(item);
        }
    }
}
