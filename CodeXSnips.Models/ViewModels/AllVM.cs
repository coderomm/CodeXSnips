using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.Models.ViewModels
{
    public class AllVM
    {
        [ValidateNever]
        public Comment Comment { get; set; }

        [ValidateNever]
        public List<Comment> CommentList { get; set; }

        [ValidateNever]
        public Like Like { get; set; }

        [ValidateNever]
        public List<Like> LikeList { get; set; }

        [ValidateNever]
        public CodeSnippetVM CodeSnippetVM { get; set; }
        
        [ValidateNever]
        public IEnumerable<CodeSnippet> CodeSnippetList { get; set; }

        [ValidateNever]
        public List<ApplicationUser> UserList { get; set; }

        [ValidateNever]
        public StoryVM StoryVM { get; set; }

        [ValidateNever]
        public List<Story> StoryList { get; set; }
    }
}
