using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.Models.MeditationViewModels
{
    public class ManageMeditationsViewModel
    {
        public List<ManageMeditationItem> MeditationItems { get; set; }

        public string MeditationId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Meditate Theme")]
        public string MeditateTheme { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Meditation Name")]
        public string MeditateName { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Meditation Type")]
        public string MeditateType { get; set; }

        public string MeditateCreator { get; set; }

        //why you broke?
        //[FileExtensions(Extensions = "jpg,jpeg")]
        public IFormFile MeditateAudio { get; set; }

        public IFormFile MeditateImage { get; set; }
    }

    public class ManageMeditationItem
    {
        public Guid MeditationId { get; set; }
        public string MeditationName { get; set; }
    }
}
