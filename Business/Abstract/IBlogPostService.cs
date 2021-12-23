﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IBlogPostService:IValidator<BlogPost>
    {
        BlogPost GetById(int id);

      //  BlogPost GetByIdWithProducts(int categoryId);

        List<BlogPost> GetAll();

        bool Create(BlogPost entity);

        void Update(BlogPost entity);
        void Delete(BlogPost entity);
     //   void DeleteFromCategory(int productId, int categoryId);

    }
}
