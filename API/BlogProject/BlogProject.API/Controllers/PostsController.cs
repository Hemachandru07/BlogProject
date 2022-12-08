using BlogProject.API.Data;
using BlogProject.API.Models.DTO;
using BlogProject.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext dbcontext;

        public PostsController(BlogDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await dbcontext.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var posts = await dbcontext.Posts.FirstOrDefaultAsync(x => x.id == id);
            if(posts != null)
            {
                return Ok(posts);
            }
            return BadRequest("Data not Found");
            
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPost post)
        {
            //convert DTO to entity

            var newPost = new Post()
            {
                title = post.title,
                content = post.content,
                author = post.author,
                featuredImageUrl = post.featuredImageUrl,
                publishedDate= post.publishedDate,
                updatedDate= post.updatedDate,
                summary= post.summary,
                urlHandle= post.urlHandle,
                visible= post.visible,
            };
            if(post != null)
            {
                await dbcontext.Posts.AddAsync(newPost);
                await dbcontext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPostById), new {id = newPost.id}, post);
            }
            return BadRequest("Post not added");
            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Updatepost([FromRoute] int id, AddPost post)
        {

            //post check
            var existingPost = await dbcontext.Posts.FindAsync(id);
            if(existingPost != null)
            {
                existingPost.title = post.title;
                existingPost.content = post.content;
                existingPost.author = post.author;
                existingPost.featuredImageUrl = post.featuredImageUrl;
                existingPost.publishedDate = post.publishedDate;
                existingPost.updatedDate = post.updatedDate;
                existingPost.summary = post.summary;
                existingPost.urlHandle = post.urlHandle;
                existingPost.visible = post.visible;

                await dbcontext.SaveChangesAsync();
                return Ok(existingPost);
            }
            return NotFound("No Id found");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existingPost = await dbcontext.Posts.FindAsync(id);

            if(existingPost != null)
            {
               dbcontext.Posts.Remove(existingPost);
                await dbcontext.SaveChangesAsync();
                return Ok(existingPost);
            }

            return NotFound("Id not found");
        }

    }
}
