using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeXSnips.Models
{
    public class Like
    {
        public int LikeId { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }

        // Foreign Key (Optional)
        public int? CodeSnippetId { get; set; }

        [ForeignKey("CodeSnippetId")]
        [ValidateNever]
        public CodeSnippet CodeSnippet { get; set; }

        public int? CodeReelId { get; set; }

        [ForeignKey("CodeReelId")]
        [ValidateNever]
        public CodeReel CodeReel { get; set; }

        public int? StoryId { get; set; }

        [ForeignKey("StoryId")]
        [ValidateNever]
        public Story Story { get; set; }
    }
}
