using Embryo.Domain.Services;
using Embryo.Tests.Mocks;
using Embryo.Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Embryo.Tests.UnitTests
{
    public class PostServiceTests
    {
        public PostServiceTests()
        {
        }

        [Fact]
        public void PostService_PublishExistingPost_Works()
        {
            // Arrange
            var timeNow = DateTime.UtcNow;
            var clock = new MockClock(timeNow);
            var postRepo = new MockPostRepository();
            var postService = new PostService(postRepo, clock);
            // Setup existing data
            var postId = "abc";
            var existingPost = new Domain.Models.Post { Id = postId, IsPublished = false };
            postRepo.Insert(existingPost);

            // Act
            postService.Publish(existingPost);

            // Assert
            var updatedPost = postRepo.Get(postId);
            Assert.True(updatedPost.IsPublished);
            Assert.True(updatedPost.PublishedDate == timeNow);
        }

    }
}
