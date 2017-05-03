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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SapremaMain.Controllers
{
    public class MeditationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MeditationController(
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        //remove in production
        [AllowAnonymous]
        public IActionResult ManageMeditations(string returnUrl = null)
        {
            ManageMeditationsViewModel manageMeditaionsViewModel = new Get().GetTeachers();
            ViewData["ReturnUrl"] = returnUrl;
            return View(manageMeditaionsViewModel);
        }

        [HttpGet]
        //remove in production
        [AllowAnonymous]
        public IActionResult PlayMeditation(string MeditationId)
        {
            Guid pareseMedId = Guid.Parse(MeditationId);
            PlayMeditationViewModel playMeditationViewModel = new Get().GetPlayMeditation(pareseMedId);
            return View(playMeditationViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ReviewMediation(string MeditationId)
        {
            return PartialView();
        }

        [HttpGet]
        //remove in production
        [AllowAnonymous]
        public IActionResult Meditations(string returnUrl = null)
        {
            var user = _userManager.GetUserId(User);
            List<MeditationsViewModel> meditationsVMList = new Get().GetUsersMeditations(user);
            ViewData["ReturnUrl"] = returnUrl;
            return View(meditationsVMList);
        }

        [HttpGet]
        //remove in production
        [AllowAnonymous]
        public IActionResult MeditationStore(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult ManageMeditations(ManageMeditationsViewModel manageMeditationsViewModel)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.Identity.Name;

            if (String.IsNullOrEmpty(manageMeditationsViewModel.MeditationId))
            {
                var meditationSavedUpdated = new DAL.Create().CreateMeditation(manageMeditationsViewModel.MeditateName, manageMeditationsViewModel.MeditateTheme, currentUserName, manageMeditationsViewModel.MeditateType, _hostingEnvironment, manageMeditationsViewModel.MeditateImage, manageMeditationsViewModel.MeditateAudio);
                ManageMeditationsViewModel newManageMeditaionsViewModel = new Get().GetTeachers();
                return View(newManageMeditaionsViewModel);
            }


            if (ModelState.IsValid)
            {
                var meditationSavedUpdated = new DAL.Create().UpdateMeditation(manageMeditationsViewModel.MeditationId, manageMeditationsViewModel.MeditateName, manageMeditationsViewModel.MeditateTheme, currentUserName, manageMeditationsViewModel.MeditateType, _hostingEnvironment, manageMeditationsViewModel.MeditateImage, manageMeditationsViewModel.MeditateAudio);
                ManageMeditationsViewModel newManageMeditaionsViewModel = new Get().GetTeachers();
                return View(newManageMeditaionsViewModel);
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMeditationRecord()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetMeditationRecord([FromBody] string meditationId)
        {
            ManageMeditationsViewModel manageMeditationsViewModel = new Get().GetMeditation(meditationId);
            return View(manageMeditationsViewModel);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult GetMeditationRecord(ManageMeditationsViewModel manageMeditationsViewModel)
        //{
        //    var foo = manageMeditationsViewModel;
        //    //GetMeditationRecordViewModel getMeditationRecordViewModel = new Get().GetMeditation(meditationId);
        //    return View(manageMeditationsViewModel);
        //}

    }
}
