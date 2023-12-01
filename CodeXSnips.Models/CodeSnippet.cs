using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeXSnips.Models
{
    public class CodeSnippet
    {
        public int CodeSnippetId { get; set; }

        public string Content { get; set; }

        [Required(ErrorMessage = "Choose the file")]
        public string MediaPath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }

        [ValidateNever]
        public List<Comment> Comments { get; set; }
        
        [ValidateNever]
        public List<Like> Likes { get; set; }
    }
}
