using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.Models.MeditationViewModels
{
    public class ManageTeachersViewModel
    {
        public List<ManageTeacherItem> TeacherItems { get; set; }

        public string TeacherId { get; set; }

        public class ManageTeacherItem
        {
            public string TeachId { get; set; }
            public string FullName { get; set; }
            public bool Verified { get; set; }
            public string Email { get; set; }
        }
    }
}
