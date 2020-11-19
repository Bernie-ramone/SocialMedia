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
        private readonly IUnitOfWork _unitOfWork;
        

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);

            if (user is null)
            {
                throw new Exception("User doesn't exist");
            }

            if (post.Description.Contains("Sexo"))
            {
                throw  new  Exception("no sex allow");
            }

            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int Id)
        {
            await _unitOfWork.PostRepository.Delete(Id);
            return true;
        }


        //only register users can publish a post






        //If user has less than 10 post Only one post per week


        //No sex post
    }



}
