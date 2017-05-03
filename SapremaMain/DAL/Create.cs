using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapremaMain.Entities;
using SapremaMain.Data;

namespace SapremaMain.DAL
{
    public class Create
    {
        //Adds teacher to db
        public bool CreateTeacher(string teachId, string studio, string cert, string bio, string site, bool verified, string teacherName)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapTeachers sapTeacher = new SapTeachers()
                {
                    Studio = studio,
                    TeachId = teachId,
                    Cert = cert,
                    Verified = verified,
                    Bio = bio,
                    Site = site,
                    FullName = teacherName
                };
                dbConn.SapTeachers.Add(sapTeacher);
                dbConn.SaveChanges();
            };
            return true;
        }

        public bool RegisterRole(string userId)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                Guid newId = Guid.NewGuid();
                AspNetUserRoles aspNetUserRoles = new AspNetUserRoles()
                {
                    UserId = userId,
                    RoleId = "88fea492-c81d-440d-8252-72f6b900a83b",
                    UserRoleId = newId
                };
                dbConn.AspNetUserRoles.Add(aspNetUserRoles);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Adds user pose selection to the db
        public bool CreateUserPoses(string id, string pose)
        {
            //using (var dbConn = new SapremaFinalContext())
            //{
            //    SapUserPoses sapUserPoses = new SapUserPoses()
            //    {
            //        PoseId = id,
            //        Pose = pose
            //    };
            //    dbConn.SapUserPoses.Add(sapUserPoses);
            //    dbConn.SaveChanges();
            //};
            return true;
        }

        //Adds a meditation to db on upload
        public bool CreateMeditation(string meditationName, string meditationTheme, string meditationCreator, string meditationType, IHostingEnvironment hostingEnvironment, IFormFile imgFile, IFormFile audioFile)
        {
            Guid imgGuid = Guid.NewGuid();
            using (var dbConn = new SapremaFinalContext())
            {
                SapMeditations sapMeditation = new SapMeditations()
                {
                    MeditationId = imgGuid,
                    MeditationName = meditationName,
                    MeditationTheme = meditationTheme,
                    MeditationCreator = meditationCreator,
                    MeditationImage = imgGuid,
                    MeditationType = meditationType
                };
                dbConn.SapMeditations.Add(sapMeditation);
                dbConn.SaveChanges();
            };
            var imgSaved = new DAL.CreateImage(hostingEnvironment).CreateMeditationImage(imgGuid, imgFile);
            var audioSave = new DAL.CreateAudio(hostingEnvironment).CreateMeditationAudio(imgGuid, audioFile);
            return true;
        }

        public bool UpdateMeditation(string meditationId, string meditationName, string meditationTheme, string meditationCreator, string meditationType, IHostingEnvironment hostingEnvironment, IFormFile imgFile, IFormFile audioFile)
        {
            Guid medGuid = Guid.Parse(meditationId);
            using (var dbConn = new SapremaFinalContext())
            {
                SapMeditations sapMeditation = dbConn.SapMeditations.Where(medId => medId.MeditationId == medGuid).FirstOrDefault();
                    
                    sapMeditation.MeditationName = meditationName;
                    sapMeditation.MeditationTheme = meditationTheme;
                    sapMeditation.MeditationCreator = meditationCreator;
                    sapMeditation.MeditationType = meditationType;

                dbConn.SaveChanges();
            };
            var imgSaved = new DAL.CreateImage(hostingEnvironment).CreateMeditationImage(medGuid, imgFile);
            var audioSave = new DAL.CreateAudio(hostingEnvironment).CreateMeditationAudio(medGuid, audioFile);
            return true;
        }

        //Adds a created class to the db
        public bool CreateClass(string classCreatedBy, int classLevel, string classTheme, string classDescription, Guid classGroupId, string classSequence)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapClass sapClass = new SapClass()
                {
                    ClassId = Guid.NewGuid(),
                    ClassCreatedBy = classCreatedBy,
                    ClassLevel = classLevel,
                    ClassTheme = classTheme,
                    ClassDescription = classDescription,
                    ClassGroupId = classGroupId,
                    //ClassSequence = classSequence
                };
                dbConn.SapClass.Add(sapClass);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Adds completed class details to db
        public bool CreateClassComplete(string userId, DateTime dateComplete, Guid classId)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapClassComplete sapClassComplete = new SapClassComplete()
                {
                    ClassId = classId,
                    UserId = userId,
                    //DateComplete = dateComplete,
                    //ClasscompleteKey = Guid.NewGuid()
                };
                dbConn.SapClassComplete.Add(sapClassComplete);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Adds a group to the db
        public bool CreateGroup(string groupName, string groupDescription, string groupTeacher, int groupLevel)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapGroups sapGroups = new SapGroups()
                {
                    GroupId = Guid.NewGuid(),
                    GroupStatus = true,
                    GroupName = groupName,
                    GroupDescription = groupDescription,
                    //GroupTeacher = groupTeacher,
                    GroupLevel = groupLevel
                };
                dbConn.SapGroups.Add(sapGroups);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Add class review to db
        public bool CreateClassReview(string userId, Guid classId, decimal reviewStars, string reviewComment)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapReviewClass sapReviewClass = new SapReviewClass()
                {
                    UserId = userId,
                    ClassId = classId,
                    ReviewStars = reviewStars,
                    ReviewComment = reviewComment,
                    //ReviewclassKey = Guid.NewGuid()
                };
                dbConn.SapReviewClass.Add(sapReviewClass);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Add meditation review to db
        public bool CreateMeditationReview(string userId, Guid meditationId, decimal reviewStars, string reviewComment)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapReviewMeditation sapReviewMeditation = new SapReviewMeditation()
                {
                    UserId = userId,
                    MeditationId = meditationId,
                    ReviewStars = reviewStars,
                    ReviewComment = reviewComment,
                    //ReviewmeditationKey = Guid.NewGuid()
                };
                dbConn.SapReviewMeditation.Add(sapReviewMeditation);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Add user group join to db
        public bool CreateUserGroup(string userId, Guid groupId)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapUserGroups sapUserGroup = new SapUserGroups()
                {
                    UserId = userId,
                    GroupId = groupId,
                    //UsergroupKey = Guid.NewGuid()
                };
                dbConn.SapUserGroups.Add(sapUserGroup);
                dbConn.SaveChanges();
            };
            return true;
        }

        //Adds user meditation purchase to db
        public bool CreateUserMeditation(Guid meditationId, string userId)
        {
            using (var dbConn = new SapremaFinalContext())
            {
                SapUserMeditations sapUserMeditation = new SapUserMeditations()
                {
                    MeditationId = meditationId,
                    UserId = userId,
                    //UsermeditationKey = Guid.NewGuid()
                };
                dbConn.SapUserMeditations.Add(sapUserMeditation);
                dbConn.SaveChanges();
            };
            return true;
        }

        /*
        public bool XXXXXXX()
        {
            using (var dbConn = new masterContext())
            {
                XXXXXXX xxx = new XXXXXXX()
                {

                };
                dbConn.XXXX.Add(XXXXX);
                dbConn.SaveChanges();
            };
            return true;
        }
        */
    }
}
