using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
   public class CommentRepository:GenericRepository<Comment,BlogContext>,ICommentRepository
    {

        public CommentRepository(BlogContext context):base(context)
        {

        }
        public BlogContext BlogContext
        {
            get
            {
                return context as BlogContext;
            }
        }
    }
}
