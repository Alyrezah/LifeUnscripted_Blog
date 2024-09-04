using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeUnscripted_Blog.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategoryDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
    }
}
