using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeXSnips.Models
{
    public class CodeSnipChatMessage
    {
        public int CodeSnipChatMessageId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
