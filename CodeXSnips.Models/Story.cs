using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeXSnips.Models
{
    public class Story
    {
        public int StoryId { get; set; }

        [StringLength(18, ErrorMessage ="Too long caption!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Choose the file")]
        public string MediaPath { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
