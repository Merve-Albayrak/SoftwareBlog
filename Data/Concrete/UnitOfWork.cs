using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
   public class UnitOfWork:IUnitOfWork
    {
        private readonly BlogContext _context;

        public UnitOfWork( BlogContext context)
        {
            _context = context;


        }
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;

        private BlogpostRepository _blogPostRepository;

        public ICategoryRepository Categories => _categoryRepository;
        public IBlogPostRepository BlogPosts => _blogPostRepository;
        public ICommentRepository Comments => _commentRepository;

        public void Save()
        {
            _context.SaveChanges();

        }
        public void Dispose()
        {
            _context.Dispose();
            
        }
    }
}
