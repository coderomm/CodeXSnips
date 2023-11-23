using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.Models.ViewModels
{
    public class StoryVM
    {
        public Story Story { get; set; }

        // Navigation properties
        
        [ValidateNever]
        public List<Comment> Comments { get; set; }
        [ValidateNever]
        public List<Like> Likes { get; set; }
    }
}
