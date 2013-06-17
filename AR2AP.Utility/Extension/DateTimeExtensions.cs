using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Utility
{
    public static class  DateTimeExtensions
    {
        #region 年龄
        public static int Age(this DateTime birthdate)
        {
            var currDate=DateTime.Today;
            var age = currDate.Year - birthdate.Year;
            if (currDate.Month < birthdate.Month || (currDate.Month == birthdate.Month && currDate.Day < birthdate.Day))
            {
                age--;
            }
            return age;
        }
        #endregion

        #region 下次生日
        public static DateTime NextBirthdate(this DateTime birthdate)
        {
            var currDate = DateTime.Today;
            int yearDiff = currDate.Year - birthdate.Year;
            birthdate = birthdate.AddYears(yearDiff);
            if (birthdate < currDate)
                birthdate = birthdate.AddYears(1);
            return birthdate;
        }
        #endregion
    }
}
