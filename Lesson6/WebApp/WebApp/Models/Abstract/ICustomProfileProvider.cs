using System.Configuration;

namespace WebApp.Models.Abstract
{
    public interface ICustomProfileProvider
    {
        SettingsPropertyValueCollection GetPropertyValues(SettingsContext context,
            SettingsPropertyCollection collection);

        void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection);
    }
}