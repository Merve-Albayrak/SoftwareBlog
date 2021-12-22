using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
     public class CategoryRepository:GenericRepository<Category,BlogContext>,ICategoryRepository
    {

        public CategoryRepository(BlogContext context):base(context)
        {

        }
        private BlogContext BlogContext
        {

            get
            {
                return context as BlogContext;
            }
        }

    }
}
