using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CodeXSnips.Models.ViewModels
{
    public class CodeSnippetVM
    {
        public string Content { get; set; }

        [Required(ErrorMessage = "Choose the media file")]
        [Display(Name = "Image")]
        public IFormFile MediaFile { get; set; }

        [ValidateNever]
        public string MediaPath { get; set; }
    }
}
