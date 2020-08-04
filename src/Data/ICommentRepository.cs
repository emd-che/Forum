using System.Collections.Generic;
using Forum.Models;

namespace Forum.Data
{
    public interface ICommentRepository
    {
        bool SaveChanges();
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}