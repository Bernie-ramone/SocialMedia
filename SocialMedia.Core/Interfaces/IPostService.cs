﻿using System.Collections.Generic;
using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task InsertPost(Post post);

        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);


        Task<bool> UpdatePost(Post post);

        Task<bool> DeletePost(int Id);
    }
}