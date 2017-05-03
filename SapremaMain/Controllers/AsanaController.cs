using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SapremaMain.Models;
using SapremaMain.Models.MeditationViewModels;
using SapremaMain.Services;
using SapremaMain.DAL;
using SapremaMain.Models.ProfileViewModels;

namespace SapremaMain.Controllers
{
    public class AsanaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;

        public AsanaController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Store()
        {
            return View();
        }

        public async Task<IActionResult> MyGroups()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            List<MyGroupsViewModel> myGroupsList = new List<MyGroupsViewModel>();

                MyGroupsViewModel myGroupsViewModel = new MyGroupsViewModel()
                {
                    GroupName = "Dolphins",
                    GroupTeacher = "John",
                    GroupDescription = "Alpha ghroup",
                    GroupId = "1"
        };
                myGroupsList.Add(myGroupsViewModel);

            MyGroupsViewModel myGroupsViewModel2 = new MyGroupsViewModel()
            {
                GroupName = "BBQ Yoga",
                GroupTeacher = "Che",
                GroupDescription = "BBQ + yoghurt",
                GroupId = "2"
            };
            myGroupsList.Add(myGroupsViewModel2);

            MyGroupsViewModel myGroupsViewModel3 = new MyGroupsViewModel()
            {
                GroupName = "Twister",
                GroupTeacher = "Mike",
                GroupDescription = "hi nrg yoga yo",
                GroupId = "3"
        };
            myGroupsList.Add(myGroupsViewModel3);

            //List<MyGroupsViewModel> myGroupsList = new Get().GetMyGroups(user.Id);
            return View(myGroupsList);
        }

        // GET: Profile/Details/5
        public IActionResult AddGroup()
        {
            return View();
        }
    }
}