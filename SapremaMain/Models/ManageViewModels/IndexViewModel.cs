using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SapremaMain.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public string TeacherName { get; set; }

        public bool BrowserRemembered { get; set; }

        public string Email { get; set; }

        public string Cert { get; set; }

        public string Bio { get; set; }

        public string Site { get; set; }

        public string Studio { get; set; }
    }
}
