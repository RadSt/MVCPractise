using System.Web.Security;

namespace WebApp.Models.Abstract
{
    public interface ICustomMembershipProvider
    {

        bool ValidateUser(string username, string password);
        MembershipUser CreateUser(string username, string emai,string password);
        MembershipUser GetUser(string username, bool userIsOnline);
      
    }
}