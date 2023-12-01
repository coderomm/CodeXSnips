using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.Models.ViewModels
{
    public class StoryVM
    {
        [StringLength(18, ErrorMessage = "Too long caption!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Choose the media file")]
        [Display(Name = "Image")]
        public IFormFile MediaFile { get; set; }

        [ValidateNever]
        public string MediaPath { get; set; }
    }
}
