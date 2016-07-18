using Embryo.Data.Contexts;
using Embryo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Embryo.Domain.Models;
using System.Linq.Expressions;
using Embryo.Data.Services;

namespace Embryo.Data.Repositories
{
    public class SqlPostRepository : IPostRepository
    {
        public SqlPostRepository(SqlEfContext dbcontext, IDbGuidGenerator guidGenerator)
        {
            _dbcontext = dbcontext;
            _guidGenerator = guidGenerator;
        }

        IDbGuidGenerator _guidGenerator;
        SqlEfContext _dbcontext;

        public Domain.Models.Post Get(string entityId)
        {
            Data.Models.Post post = null;

            // Try find post in db
            post = _dbcontext.Posts.FirstOrDefault(p => string.Equals(p.Id, entityId, StringComparison.OrdinalIgnoreCase));

            if (post == null)
                return null;

            // Map to domain model
            return new Domain.Models.Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastUpdated = post.LastUpdated,
                PublishedDate = post.PublishedDate
            };
        }

        public IList<Domain.Models.Post> GetAll()
        {
            List<Models.Post> posts = new List<Models.Post>();

            // Get posts from db
            posts = _dbcontext.Posts.ToList();

            // Map to domain models
            return posts.Select(p => new Domain.Models.Post
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                IsPublished = p.IsPublished,
                PublishedDate = p.PublishedDate,
                LastUpdated = p.LastUpdated
            }).ToList();
        }

        public bool Insert(Domain.Models.Post entity)
        {
            var newId = _guidGenerator.Generate();

            // Map to data model
            var mapped = new Models.Post
            {
                // Autogen Id
                Id = newId,
                // Map values
                Title = entity.Title,
                Content = entity.Content,
                IsPublished = entity.IsPublished,
                PublishedDate = entity.PublishedDate,
                LastUpdated = entity.LastUpdated
            };

            // Assign new id to entity passed in
            entity.Id = newId;

            // Insert into db
            _dbcontext.Posts.Add(mapped);
            return (_dbcontext.SaveChanges() > 0);
        }

        public bool Update(Domain.Models.Post entity)
        {
            // Map to data model
            var mapped = new Models.Post
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                IsPublished = entity.IsPublished,
                PublishedDate = entity.PublishedDate,
                LastUpdated = entity.LastUpdated
            };

            // Update in db
            _dbcontext.Posts.Update(mapped);
            return (_dbcontext.SaveChanges() > 0);
        }

        public bool Delete(string entityId)
        {
            // Delete from db if found
            var post = _dbcontext.Posts.FirstOrDefault(p => string.Equals(p.Id, entityId, StringComparison.OrdinalIgnoreCase));

            if (post != null)
            {
                _dbcontext.Posts.Remove(post);
                return (_dbcontext.SaveChanges() > 0);
            }
            else
            {
                return false;
            }
               
        }

    }
}
