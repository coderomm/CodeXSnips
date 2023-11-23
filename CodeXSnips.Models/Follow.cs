using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeXSnips.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }

        [Required]
        public string FollowerId { get; set; }

        [ForeignKey("FollowerId")]
        [ValidateNever]
        public ApplicationUser Follower { get; set; }

        [Required]
        public string FollowingId { get; set; }

        [ForeignKey("FollowingId")]
        [ValidateNever]
        public ApplicationUser Following { get; set; }
    }
}
