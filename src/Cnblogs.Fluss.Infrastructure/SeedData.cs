using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Entities;

namespace Cnblogs.Fluss.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(BlogDbContext context)
        {
            context.Database.EnsureCreated();
            var blog = new BlogSite { Title = "Fluss", SubTitle = "Cnblogs" };
            context.Add(blog);
            context.SaveChanges();
            var body = new ContentBlock() { BlogId = blog.Id, Content = "<p>content block can be referred</p>" };
            var post = new BlogPost
            {
                Title = "Fluss is a open-source blog engine",
                Description = "based on .NET，fluss can save and display your work plan or blog posts。Content block referring can save your time of maintaining same content between different posts",
                AutoDesc = "based on .NET，fluss can save and display your work plan or blog posts。Content block referring can save your time of maintaining same content between different posts",
                ContentBlocks = new List<ContentBlock> { body }
            };
            blog.BlogPosts = new List<BlogPost> { post };
            context.SaveChanges();
            var referBlock = new ContentBlock() { BlogId = blog.Id, Refer = body.Id };
            post.ContentBlocks.Add(referBlock);
            context.SaveChanges();
        }
    }
}