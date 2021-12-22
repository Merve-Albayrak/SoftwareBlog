using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
   public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IBlogPostRepository BlogPosts { get; }
        void Save();
    }
}
