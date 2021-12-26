using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private IBlogPostService _blogPostService;
        public BlogController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;

        }
        private static readonly string[] contents =
        {
            "post","post"
        };
        [HttpGet]
        public async Task< IActionResult> GetPosts()
        {
            var posts= await _blogPostService.GetAll();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _blogPostService.GetById(id);
            if (post == null)
            {

                return NotFound();
            }
            return Ok(post);
        }
    }
}
