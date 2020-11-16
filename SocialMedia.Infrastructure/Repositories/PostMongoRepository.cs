using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostMongoRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            IEnumerable<Post> posts = Enumerable.Range(1, 35).Select(x => new Post
            {
                PostId = x,
                Description = $"Description MONGO {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{x}",
                UserId = x
            });

            await Task.Delay(10);

            return posts;
        }
    }
}
