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
#nullable enable
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PostNumber { get; set; }

        public int? BlogPostId { get; set; }
        public List<BlogPost>? BlogPosts { get; set; }
#nullable disable
        public string AboutMeText { get; set; }
       
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
    }
}
