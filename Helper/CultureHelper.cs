using System.Globalization;
using System.Threading;
using System.Web.SessionState;

namespace WebJusticeIN.Helper
{
    public class CultureHelper
    {
        protected HttpSessionState session;

        public CultureHelper(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return 0;
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                {
                    return 1;
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "zh-TW")
                {
                    return 2;
                }              
                else
                {
                    return 0;
                }
            }
            set
            {

                if (value == 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                }
                else if (value == 1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-SA");
                }
                else if (value == 2)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-TW");
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                }

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            }
        }
    }
}