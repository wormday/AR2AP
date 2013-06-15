using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
namespace AR2AP.WebApp.Authentication
{
    public static class AuthUtility
    {
        #region 注册登录票证
        public static void RegisterTicket(AR2AP.WebApp.Models.CurrEmpData currUserData)
        {
            string strUserData = CreateTicketUserData(currUserData);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, currUserData.Username, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, strUserData);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void RegisterTicket(AR2AP.BLL.EmpEntity entity)
        {
            AR2AP.WebApp.Models.CurrEmpData currUserData = new Models.CurrEmpData();
            currUserData.EmpID = entity.EmpID;
            currUserData.EmpName = entity.EmpName;
            currUserData.Username = entity.Username;
            RegisterTicket(currUserData);
        }
        #endregion

        #region 根据CurrUserData和票证字符串相互创建
        private static string CreateTicketUserData(AR2AP.WebApp.Models.CurrEmpData currUserData)
        {
            string strUserInfo = string.Format("{0},{1},{2}", currUserData.EmpID, currUserData.EmpName, currUserData.Username);
            return strUserInfo;
        }

        private static AR2AP.WebApp.Models.CurrEmpData GetCurrUserDataFromTicket(string strUserData)
        {
            string[] userInfoArray = strUserData.Split(',');
            if (userInfoArray.Length != 3)
                throw new ArgumentException("strUserData");
            AR2AP.WebApp.Models.CurrEmpData rtnValue = new AR2AP.WebApp.Models.CurrEmpData();
            rtnValue.EmpID = int.Parse(userInfoArray[0]);
            rtnValue.EmpName = userInfoArray[1];
            rtnValue.Username = userInfoArray[2];
            return rtnValue;
        }
        #endregion

        #region 获取当前用户信息
        public static AR2AP.WebApp.Models.CurrEmpData GetCurrUserData()
        {
            var p = HttpContext.Current.User as GenericPrincipal;
            if (p == null)
                return null;
            var i = p.Identity as System.Web.Security.FormsIdentity;
            if (i == null)
                return null;
            string strUserData = i.Ticket.UserData;
            return GetCurrUserDataFromTicket(strUserData);
        }
        #endregion
    }
}