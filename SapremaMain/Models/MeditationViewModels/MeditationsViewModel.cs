using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.Models.MeditationViewModels
{
    public class MeditationsViewModel
    {
        public Guid MeditationId { get; set; }
        public string MeditationName { get; set; }
        public string MeditationTheme { get; set; }
        public string MeditationType { get; set; }
    }
}
