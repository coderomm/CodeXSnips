using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.Models.ViewModels
{
    public class CodeSnippetVM
    {
        public CodeSnippet CodeSnippet { get; set; }
        public Comment Comment { get; set; }
        public Like Like { get; set; }

        public IEnumerable<CodeSnippet> CodeSnippetList { get; set; }
        public List<Comment> CommentList { get; set; }
        public List<Like> LikeList { get; set; }
    }
}
