using SoftwareBlog.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwareBlog.Models
{
    public class UserDetailsModel:User
    {
        public string UserId { get; set; }
       
       
        public IEnumerable<string> SelectedRoles { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}