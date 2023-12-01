using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeXSnips.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [DisplayName("Full Name")] 
        public string FullName { get; set; }

        [StringLength(500)]
        public string? Bio { get; set; }

        [StringLength(255)]
        public string? ProfileImage { get; set; }

        // Navigation properties
        [ValidateNever]
        public List<CodeSnippet> CodeSnippets { get; set; }
        [ValidateNever]
        public List<CodeReel> CodeReels { get; set; }
        [ValidateNever]
        public List<Story> Stories { get; set; }
        [ValidateNever]
        public List<CodeSnipChatMessage> CodeSnipChatMessages { get; set; }
        [ValidateNever]
        public List<Follow> Followers { get; set; }
    }
}
