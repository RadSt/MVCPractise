using System;
using System.Collections.Generic;
using WebApp.Models.Abstract;

namespace WebApp.Models.ViewModel
{
    public class UserRegisterView 
    {
        public int BirthdayDay { get; set; }
        public int BirthdayMonth { get; set; }
        public int BirthdayYear { get; set; }

        public IEnumerable<string> BirthdayDayCollect
        {
            get
            {
                for (var i = 1; i < 32; i++)
                {
                    yield return i.ToString();
                }
            }
        }

        public IEnumerable<string> BirthdayMonthCollect
        {
            get
            {
                for (var i = 1; i < 13; i++)
                {
                    yield return i.ToString();
                }
            }
        }

        public IEnumerable<string> BirthdayYearCollect
        {
            get
            {
                for (var i = 1910; i < DateTime.Now.Year; i++)
                {
                    yield return i.ToString();
                }
            }
        }
    }
}