using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Models.Abstract
{
    public interface IUserRegisterView
    {
        int BirthdayDay { get; set; }
        int BirthdayMonth { get; set; }
        int BirthdayYear { get; set; }

        IEnumerable<string> BirthdayDayCollect { get; } 
        IEnumerable<string> BirthdayMonthCollect { get; }
        IEnumerable<string> BirthdayYearCollect { get; }  
    }
}