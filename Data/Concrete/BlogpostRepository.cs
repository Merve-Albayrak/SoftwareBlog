using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
  public  class BlogpostRepository:GenericRepository<BlogPost,BlogContext>,IBlogPostRepository
    {

        public BlogpostRepository(BlogContext context):base(context)
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
