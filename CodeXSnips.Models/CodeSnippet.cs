using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeXSnips.Models
{
    public class CodeSnippet
    {
        public int CodeSnippetId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        public string? CodeImage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
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
