using Embryo.Domain.Models;
using Embryo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Domain.Services
{
    public class PostService
    {
        public PostService(IPostRepository postRepo, IClock clock)
        {
            _postRepo = postRepo;
            _clock = clock;
        }

        IPostRepository _postRepo;
        IClock _clock;

        public void Publish(Post post)
        {
            // To publish means to update the flag and published date
            post.IsPublished = true;
            post.PublishedDate = _clock.GetTime();

            // Persist
            _postRepo.Update(post);
        }

    }
}
