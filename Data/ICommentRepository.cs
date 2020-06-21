using System.Collections.Generic;
using Forum.Model;

namespace Forum.Data
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
    }
}