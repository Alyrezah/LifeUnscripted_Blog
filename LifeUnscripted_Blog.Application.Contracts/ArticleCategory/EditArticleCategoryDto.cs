using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeUnscripted_Blog.Application.Contracts.ArticleCategory
{
    public class EditArticleCategoryDto : CreateArticleCategoryDto
    {
        public long Id { get; set; }
    }
}
