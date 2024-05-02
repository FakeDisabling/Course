using DAL.DBContext;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBRepositories
{
    public class CommentRepositories : IComment
    {
        public ApplicationContext Database { get; set; }
        public CommentRepositories(ApplicationContext Database)
        {
            this.Database = Database;
        }
        public void Add(Comments entity)
        {
            Database.comments.Add(entity);
            Database.SaveChanges();
        }

        public void Delete(Comments entity)
        {
            Database.comments.Remove(entity);
            Database.SaveChanges();
        }

        public IEnumerable<Comments> GetAll() => Database.comments.AsQueryable().AsNoTracking();

        public Comments GetById(int id) => (Comments)Database.comments.Where(comment => comment.CommentsId == id);

        public void Update(Comments entity)
        {
            Database.comments.Update(entity);
            Database.SaveChanges();
        }
    }
}
