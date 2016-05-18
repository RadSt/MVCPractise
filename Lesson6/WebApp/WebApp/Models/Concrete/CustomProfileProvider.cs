using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web.Profile;
using WebApp.Models.Enteties;

namespace WebApp.Models.Concrete
{
    public class CustomProfileProvider : ProfileProvider
    {
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
           SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();
            if (collection == null || collection.Count < 1 || context==null)
            {
                return result;
            }

            string userName = (string) context["UserName"];
            if (String.IsNullOrEmpty(userName))
                return result;
            WebAppDbContext dbContext = new WebAppDbContext();

            string name = dbContext.Users.FirstOrDefault(us => us.UserName.Equals(userName)).UserName;

            Profile profile = dbContext.Profiles.FirstOrDefault(pr => pr.UserName == name);

            if (profile != null)
            {
                foreach (SettingsProperty settingsProp in collection)
                {
                    SettingsPropertyValue setPropVal = new SettingsPropertyValue(settingsProp);
                    setPropVal.PropertyValue = profile.GetType().GetProperty(settingsProp.Name).GetValue(profile, null);
                    result.Add(setPropVal);
                }
            }
            else
            {
                foreach (SettingsProperty settingsProp in collection)
                {
                    SettingsPropertyValue setPropValue = new SettingsPropertyValue(settingsProp);
                    setPropValue.PropertyValue = null;
                    result.Add(setPropValue);
                }
            }
            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            string userName = (string) context["UserName"];

            if (string.IsNullOrEmpty(userName) || collection.Count < 1)
            return;

            WebAppDbContext dbContext = new WebAppDbContext();
            string name = dbContext.Users.FirstOrDefault(us => us.UserName.Equals(userName)).UserName;

            Profile profile = dbContext.Profiles.FirstOrDefault(pr => pr.UserName == name);

            if (profile != null)
            {
                foreach (SettingsPropertyValue settingsProp in collection)
                {
                    profile.GetType().GetProperty(settingsProp.Name).SetValue(profile,settingsProp.PropertyValue);
                }
                profile.LastUpdateDate = DateTime.Now;
                dbContext.Entry(profile).State = EntityState.Modified;
            }
            else
            {
                profile = new Profile();
                foreach (SettingsPropertyValue settingsProp in collection)
                {
                    profile.GetType().GetProperty(settingsProp.Name).SetValue(profile,settingsProp.PropertyValue);
                }
                profile.LastUpdateDate = DateTime.Now;
                profile.UserName = Name;
                dbContext.Profiles.Add(profile);
            }
            dbContext.SaveChanges();
        }

        public override string ApplicationName { get; set; }
        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption,
            DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch,
            int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption,
            string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}