using Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBlog.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostNumber { get; set; }

        public int BlogPostId { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

    }
}
