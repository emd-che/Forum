using System.Collections.Generic;
using System.Linq;
using Forum.Model;

namespace Forum.Data
{
    public class SqlCommentRepository : ICommentRepository
    {
        private readonly ForumContext _context;

        public SqlCommentRepository(ForumContext context)
        {
            _context = context;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}