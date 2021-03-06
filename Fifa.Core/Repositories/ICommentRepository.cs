using System.Collections.Generic;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories
{
    public interface ICommentRepository
    {
        void DeleteComment(int id);
        void SaveComment(Comment comment);
        Comment GetComment(int id);
        IEnumerable<Comment> GetAllComments();
    }
}