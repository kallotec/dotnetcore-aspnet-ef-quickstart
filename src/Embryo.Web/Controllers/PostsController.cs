using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Embryo.Web.Infrastructure;
using Microsoft.Extensions.Options;
using Embryo.Domain.Repositories;
using Embryo.Web.Models;

namespace Embryo.Web.Controllers
{
    public class PostsController : Controller
    {
        public PostsController(IPostRepository postRepository, IOptions<EmbryoSettings> settings)
        {
            _postRepository = postRepository;
            _settings = settings.Value;
        }

        IPostRepository _postRepository;
        EmbryoSettings _settings;

        // GET: /Posts/
        public IActionResult Index()
        {
            // Get and map all posts
            var allPostsMapped = _postRepository.GetAll()
                .Select(p =>
                    new Web.Models.Post
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = p.Content,
                        IsPublished = p.IsPublished,
                        PublishedDate = p.PublishedDate,
                        LastUpdated = p.LastUpdated,
                    }).ToList();

            return View(allPostsMapped);
        }

        // GET: /Posts/123
        public IActionResult Details(string id)
        {
            // Try find post
            var post = _postRepository.Get(id);
            if (post == null)
                return NotFound();

            // Map to model
            var postMapped = new Web.Models.Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastUpdated = post.LastUpdated,
                PublishedDate = post.PublishedDate
            };

            return View(postMapped);
        }

        // GET: /Posts/Create
        public IActionResult Create()
        {
            return View(new Post());
        }

        // POST: /Posts/Create
        [HttpPost]
        public IActionResult Create(Post post)
        {
            // Validate
            if (!ModelState.IsValid)
                return View(post);

            // Map request to domain model
            var postMapped = new Domain.Models.Post
            {
                // [Id] is assigned to in the repo's insert call
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastUpdated = post.LastUpdated,
                PublishedDate = post.PublishedDate
            };

            // Try create post
            if (_postRepository.Insert(postMapped))
                return RedirectToAction(nameof(PostsController.Details), new { id = postMapped.Id });
            else
                return BadRequest();
        }

        // GET: /Posts/Edit/123
        public IActionResult Edit(string id)
        {
            // Try find post
            var post = _postRepository.Get(id);
            if (post == null)
                return NotFound();

            // Map request to domain model
            var postMapped = new Web.Models.Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastUpdated = post.LastUpdated,
                PublishedDate = post.PublishedDate
            };

            return View(postMapped);
        }

        // POST: /Posts/Edit/123
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            // Validate
            if (!ModelState.IsValid)
                return View(post);

            // Map request to domain model
            var postMapped = new Domain.Models.Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastUpdated = post.LastUpdated,
                PublishedDate = post.PublishedDate
            };

            // Try update post
            if (_postRepository.Update(postMapped))
                return RedirectToAction(nameof(PostsController.Details), new { id = post.Id });
            else
                return BadRequest();
        }


        // GET: /Posts/Delete/123
        public IActionResult Delete(string id)
        {
            // Try delete post
            if (_postRepository.Delete(id))
                return RedirectToAction(nameof(PostsController.Index));
            else
                return BadRequest();
        }


    }
}
