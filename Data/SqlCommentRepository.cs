using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Model;

namespace Forum.Data
{
    public class SqlCommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public SqlCommentRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            if (comment.User != null && comment.User.Id != 0)
            {
                _context.Attach(comment.User);
            }
             if (comment.Topic != null && comment.Topic.Id != 0)
            {
                _context.Attach(comment.Topic);
            }
            _context.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            _context.Comments.Remove(comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComment(Comment comment){}
    }
}