using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.Models.AccountViewModels
{
    public class RegisterTeacherViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A name must be a minimum of 4 characters and no more than 100", MinimumLength = 4)]
        [Display(Name = "Name")]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "A studio name must be a minimum of 6 characters and no more than 256", MinimumLength = 6)]
        [Display(Name = "Studio")]
        public string Studio { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "A certification must be a minimum of 6 characters and no more than 256", MinimumLength = 6)]
        [Display(Name = "Cert")]
        public string Cert { get; set; }

        [Display(Name = "I am a")]
        public string LevelSelect { get; set; }
    }
}
