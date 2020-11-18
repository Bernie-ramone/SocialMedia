using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{

    //Business Rules


    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _userRepository.GetUser(post.UserId);

            if (user is null)
            {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("Sexo"))
            {
                throw  new  Exception("no sex allow");
            }

            await _postRepository.InsertPost(post);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }

        public async Task<bool> DeletePost(int Id)
        {
            return await _postRepository.DeletePost(Id);
        }


        //only register users can publish a post






        //If user has less than 10 post Only one post per week


        //No sex post
    }



}
