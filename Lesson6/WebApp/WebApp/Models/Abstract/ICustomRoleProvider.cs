namespace WebApp.Models.Abstract
{
    public interface ICustomRoleProvider
    {
        string[] GetRolesForUser(string userName);
        void CreateRole(string roleName);
        bool IsUserInRole(string userName, string roleName);
    }
}