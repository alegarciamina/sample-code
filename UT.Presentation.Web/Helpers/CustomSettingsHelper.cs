using System;
using System.Web;
using UT.Presentation.Web.Constants;

namespace UT.Presentation.Web.Helpers
{
    public class CustomSettingsHelper
    {
        public static void SetCookie(HttpResponseBase response, string accountNumber)
        {
            var customerSettingsCookie = new HttpCookie(Cookies.CustomSettings + accountNumber)
            {
                Expires = DateTime.Now.AddDays(30),
                Value = "1"
            };
            customerSettingsCookie.HttpOnly = true;
#if !DEBUG
            csddCookie.Secure = true;
#endif
            response.Cookies.Add(customerSettingsCookie);
        }

        public static bool AreUpdated(HttpRequestBase request, string accountNumber)
        {
            var customerSettingsCookie = request.Cookies[Cookies.CustomSettings + accountNumber];
            return customerSettingsCookie != null;
        }
    }
}