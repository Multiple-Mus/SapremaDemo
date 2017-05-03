using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapremaMain.Entities;
using SapremaMain.Models.MeditationViewModels;
using SapremaMain.Models.ProfileViewModels;
using SapremaMain.Models.ManageViewModels;
using static SapremaMain.Models.MeditationViewModels.ManageTeachersViewModel;
using static SapremaMain.Models.MeditationViewModels.MeditationsViewModel;

namespace SapremaMain.DAL
{
    public class Get
    {
        // This returns a single teacher id
        public string GetTeacher(string teacherId)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var teachId = teacher.TeachId;
                return teachId;
            }
        }

        // This returns a teachers Bio
        public string GetTeacherName(string teacherId)
        {
            //Models.ManageViewModels.TeacherModelVM teacherModelVM = new Models.ManageViewModels.TeacherModelVM();

            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var name = teacher.FullName;
                return name;
            }
        }

        // This returns a teachers Bio
        public string GetTeacherBio(string teacherId)
        {
            //Models.ManageViewModels.TeacherModelVM teacherModelVM = new Models.ManageViewModels.TeacherModelVM();

            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var bio = teacher.Bio;
                return bio;
            }
        }

        // This returns a teachers Ccert
        public string GetTeacherCert(string teacherId)
        {
            //Models.ManageViewModels.TeacherModelVM teacherModelVM = new Models.ManageViewModels.TeacherModelVM();

            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var cert = teacher.Cert;
                return cert;
            }
        }

        // This returns a teachers studio
        public string GetTeacherStudio(string teacherId)
        {
            //Models.ManageViewModels.TeacherModelVM teacherModelVM = new Models.ManageViewModels.TeacherModelVM();

            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var studio = teacher.Studio;
                return studio;
            }
        }

        // This returns a teachers studio
        public string GetTeacherSite(string teacherId)
        {
            //Models.ManageViewModels.TeacherModelVM teacherModelVM = new Models.ManageViewModels.TeacherModelVM();

            using (var dbConn = new SapremaFinalContext())
            {
                var teacher = dbConn.SapTeachers.Where(a => a.TeachId == teacherId).SingleOrDefault();
                var site = teacher.Site;
                return site;
            }
        }

        // This returns all teachers
        public ManageTeachersViewModel ManageTeachers()
        {
            ManageTeachersViewModel manageTeacherViewModels = new ManageTeachersViewModel();

            using (var dbConn = new SapremaFinalContext())
            {
                manageTeacherViewModels.TeacherItems = dbConn.SapTeachers.Select(teacher => new ManageTeacherItem() { TeachId = teacher.TeachId, FullName = teacher.FullName, Verified = teacher.Verified }).ToList();
                return manageTeacherViewModels;
            }
        }

        public PlayMeditationViewModel GetPlayMeditation(Guid meditationId)
        {
            PlayMeditationViewModel playMeditationViewModel = new PlayMeditationViewModel();

            using (var dbConn = new SapremaFinalContext())
            {
                dbConn.SapMeditations.Where(a => a.MeditationId == meditationId).Select(meditatation => new PlayMeditationViewModel() { MeditationId = meditatation.MeditationId, MeditationImage = meditatation.MeditationImage, MeditationName = meditatation.MeditationName, MedPath = new DALHelpers().ConvertToAudioPath(meditatation.MeditationId) });
                    //Select(meditation => new playMeditationViewModel() { MeditationId = meditation.MeditationId, MeditationImage = meditation.MeditationImage, MeditationName = meditation.MeditationName }).ToList();
                return playMeditationViewModel;
            }
        }

        // This returns all a users meditations
        public List<MeditationsViewModel> GetUsersMeditations(string userId)
        {
            List<MeditationsViewModel> meditationsViewModel = new List<MeditationsViewModel>();

            using (var dbConn = new SapremaFinalContext())
            {
                var meditationsList = dbConn.SapUserMeditations.Where(useId => useId.UserId == userId).Select(x => x.Meditation).ToList();

                foreach(var record in meditationsList)
                {
                    MeditationsViewModel mModel = new MeditationsViewModel()
                    {
                        MeditationId = record.MeditationId,
                        MeditationName = record.MeditationName,
                        MeditationTheme = record.MeditationTheme,
                        MeditationType = record.MeditationType
                    };
                    meditationsViewModel.Add(mModel);
                }

              
                return meditationsViewModel;
            }
        }

        //public ManageMeditationsViewModel GetAllMeditations(string teacherId)
        public ManageMeditationsViewModel GetTeachers()
        {
            ManageMeditationsViewModel manageMeditationViewModels = new ManageMeditationsViewModel();

            using (var dbConn = new SapremaFinalContext())
            {
                manageMeditationViewModels.MeditationItems = dbConn.SapMeditations.Select(meditation => new ManageMeditationItem() { MeditationId = meditation.MeditationId, MeditationName = meditation.MeditationName }).ToList();

                return manageMeditationViewModels;
            }
        }

        public ManageMeditationsViewModel GetMeditation(string meditationId)
        {
            Guid medId = Guid.Parse(meditationId);
            using (var dbConn = new SapremaFinalContext())
            {
                var manageMeditationsViewModel = dbConn.SapMeditations.Where(meditation => meditation.MeditationId == medId).Select(meditation => new ManageMeditationsViewModel() { MeditateName = meditation.MeditationName, MeditateTheme = meditation.MeditationTheme, MeditateType = meditation.MeditationType, ImageUrl = new DALHelpers().ConvertToImagePath(meditation.MeditationImage, "~/images/meditationimg/"), MeditationId = meditation.MeditationId.ToString() }).FirstOrDefault();
                manageMeditationsViewModel.MeditationItems = dbConn.SapMeditations.Select(meditation => new ManageMeditationItem() { MeditationId = meditation.MeditationId, MeditationName = meditation.MeditationName }).ToList();
                return manageMeditationsViewModel;
            }
        }

        public MeditationViewModel GetSingleMeditation(string meditationId)
    {
        Guid medId = Guid.Parse(meditationId);
        using (var dbConn = new SapremaFinalContext())
        {
            return dbConn.SapMeditations.Where(meditation => meditation.MeditationId == medId).Select(meditation => new MeditationViewModel() { MeditateName = meditation.MeditationName, MeditateTheme = meditation.MeditationTheme, MeditateType = meditation.MeditationType, ImageUrl = new DALHelpers().ConvertToImagePath(meditation.MeditationId, "~/images/meditationimg/") }).FirstOrDefault();
        }
    }

    // This returns the poses a user has selected on/off
    public List<EditPosesViewModel> GetUserPosees(string userId)
    {
        List<EditPosesViewModel> editPosesViewModel = new List<EditPosesViewModel>();

        using (var dbConn = new SapremaFinalContext())
        {
                //var poseList = dbConn.SapUserPoses.GroupJoin(editPosesViewModel, pose => pose.PoseId, user => user.PoseId, (pose, user) => new {pose = pose, user = user });//Where(useId => useId.UserId == userId).Select(x => x.Pose).ToList();
                //var userPoses = dbConn.SapUserPoses.Where(c => c.UserId == userId).SelectMany(p => p.SapUserPoses.Any() ? p.SapUserPoses.Select(c => new EditPosesViewModel() { UserId = c.UserId, PoseId = c.PoseId, PoseName = p.PoseName }));
                //Where(a => a.PoseId == userId).Select(b => b.PoseId).ToList();
            // var poses = dbConn.SapPoses.Where(a => userPoseId.Contains(a.PoseId));
            //foreach (var record in userPoses)
            //{
                //MeditationsViewModel mModel = new MeditationsViewModel()
                //{
                //    PoseId = record.PoseId,
                //    PoseName = record.PoseName,
                //    PoseOn = record.SapUserPoses
                //};
                //editPosesViewModel.Add(mModel);
            //}

            return editPosesViewModel;
        }
    }


    //public IQueryable<SapPoses> GetUserPoses(string userId)
    //{
    //    using (var dbConn = new SapremaFinalContext())
    //    {
    //        var userPoseId = dbConn.SapUserPoses.Where(a => a.UserId == userId).Select(b => b.PoseId).ToList();
    //        var poses = dbConn.SapPoses.Where(a => userPoseId.Contains(a.PoseId));
    //        return poses;
    //    }
    //}

    // This returns the list of poses within the app
    public Dictionary<string, List<SapPoses>> GetPoseList()
    {
        using (var dbConn = new SapremaFinalContext())
        {
            var poseList = dbConn.SapPoses.GroupBy(themeName => themeName.PoseTheme)
                .ToDictionary(kv => kv.Key, kv => kv.ToList());
            return poseList;
        }
    }

    public List<MyGroupsViewModel> GetMyGroups(String groupId)
    {
        var groupGuid = Guid.Parse(groupId);
        using (var dbConn = new SapremaFinalContext())
        {
            return dbConn.SapGroups.Where(group => group.GroupId == groupGuid).Select(group => new MyGroupsViewModel() { GroupName = group.GroupName, GroupTeacher = group.GroupAdmin, GroupDescription = group.GroupDescription, GroupId = group.GroupId.ToString() }).ToList();
        }
    }
}
}

