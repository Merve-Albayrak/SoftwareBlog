using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public  class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public int LikeNumber { get; set; }
        public int DislikeNumber { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
    }
}
