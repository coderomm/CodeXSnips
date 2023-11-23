using Microsoft.AspNetCore.Identity;
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
        public string Bio { get; set; }

        [StringLength(255)]
        public string ProfileImage { get; set; }

        // Navigation properties
        public List<CodeSnippet> CodeSnippets { get; set; }
        public List<CodeReel> CodeReels { get; set; }
        public List<Story> Stories { get; set; }
        public List<CodeSnipChatMessage> CodeSnipChatMessages { get; set; }
        public List<Follow> Followers { get; set; }
    }
}
