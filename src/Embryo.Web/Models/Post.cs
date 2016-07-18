using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Web.Models
{
    public class Post
    {
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
