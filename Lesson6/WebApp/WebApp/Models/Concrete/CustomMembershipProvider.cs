using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using WebApp.Models.Abstract;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    /// <summary>
    /// провайдер членства помогает системе определить, что это за пользователь, его идентифицировать
    /// </summary>
    public class CustomMembershipProvider : MembershipProvider, ICustomMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            using (WebAppDbContext dbContext = new WebAppDbContext())
            {
                try
                {
                    User user = dbContext.Users.Select(u => u).FirstOrDefault(u => u.UserName == username);
                    if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                    {
                        isValid = true;
                    }
                }
                catch (Exception)
                {

                    isValid = false;
                }
            }
            return isValid;
        }
        public MembershipUser CreateUser(string userName, string email, string password, DateTime birthdateDate)
        {
            MembershipUser membershipUser = GetUser(userName, false);
            if (membershipUser == null)
            {
                try
                {
                    using (WebAppDbContext dbContext = new WebAppDbContext())
                    {
                        User user = new User();
                        user.UserName = userName;
                        user.Email = email;
                        user.BirthdateDate = birthdateDate;
                        user.Password = Crypto.HashPassword(password);
                        if (dbContext.Roles.Find(2) != null)
                        {
                           user.RoleId = 2; ;
                        }
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        membershipUser = GetUser(userName, false);
                        return membershipUser;

                    }
                }
                //catch (DbEntityValidationException e)
                //{
                //    foreach (var eve in e.EntityValidationErrors)
                //    {
                //        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }
                //}
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                    return null;
                }
            }
            return null;
        }
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                using (WebAppDbContext dbContext = new WebAppDbContext())
                {
                    User user = dbContext.Users.Select(u => u).FirstOrDefault(u => u.UserName == username);
                    if (user != null)
                    {
                        MembershipUser memberUser = new MembershipUser("MyMembershipProvider", user.Email, null, null, null, null,
                            false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                        return memberUser;
                    }
                }
            }
            catch (Exception)
            {

                return null;
            }
            return null;
        }
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public bool ChangePasswordQuestionAndAnswer(string username, string password, string email, string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public MembershipUserCollection FindUserByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public MembershipUserCollection FindUserByName(string userNameToMAtch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }
    }
}