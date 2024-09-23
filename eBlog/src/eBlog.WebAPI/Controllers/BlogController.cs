using AutoMapper;
using eBlog.Application.Blogs.Commands.CreateBlog;
using eBlog.Application.Blogs.Commands.DeleteBlog;
using eBlog.Application.Blogs.Commands.UpdateBlog;
using eBlog.Application.Blogs.Queries.GetBlogById;
using eBlog.Application.Blogs.Queries.GetBlogs;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public BlogController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("blogs")]
        public async Task<IActionResult> GetAllBlogsAsync()
        {
            var blogsVm = await Mediator.Send(new GetBlogQuery());
            return Ok(blogsVm);
        }

        [HttpGet("blog/{id}")]
        public async Task<IActionResult> GetBlogByIdAsync(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id});
            if(blog == null)
                return NotFound();
            return Ok(blog);
        }

        [HttpPost("blog/add")]
        public async Task<IActionResult> CreateBlogAsync(CreateBlogCommand command)
        {
            var createdBlogVm = await Mediator.Send(command);
            var createdBlog = _mapper.Map<Blog>(createdBlogVm);
            return CreatedAtAction(nameof(GetBlogByIdAsync), new { id = createdBlog.Id }, createdBlog);
        }

        
        [HttpPut("blog/update/{id}")]
        public async Task<IActionResult> UpdateBlogByIdAsync(int id, UpdateBlogCommand command)
        {
            //if(id != command.Id)
              //  return BadRequest();
             await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("blog/delete/{id}")]
        public async Task<IActionResult> DeleteBlogByIdAsync(int id)
        {
            if(id == 0)
                return BadRequest();
            var deletedBlog = await Mediator.Send(new DeleteBlogCommand() { Id = id});
            return NoContent();
        }
    }
}
