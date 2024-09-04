using LifeUnscripted_Blog.Application.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeUnscripted_Blog.Application.Contracts.Article
{
    public class ArticleDto : BaseApplicationDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
