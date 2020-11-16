using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository
    {
        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> posts = Enumerable.Range(1, 35).Select(x => new Post { 
             PostId = x,
             Description = $"Description {x}",
             Date = DateTime.Now,
             Image = $"https://misapis.com/{x}",
             UserId = x
            });

            return posts;
        }
            
    }
}
