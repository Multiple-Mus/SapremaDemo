using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.Models.MeditationViewModels
{
    public class PlayMeditationViewModel
    {
        public Guid MeditationId { get; set; }

        public string MeditationName { get; set; }

        public Guid? MeditationImage { get; set; }

        public string MedPath { get; set; }
    }
}
