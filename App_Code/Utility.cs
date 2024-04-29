using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Utilities
{
    public sealed class Utility
    {
        private Utility() { }

        ///<summary>Default Format mm/dd/yyyy,Default Delimination '/', Format 1 'dd/mm/yyyy' </summary> 
           

        public static DateTime dataformat(string date)
        {
            try
            {
                string[] datesplit = date.Split('/');
                DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }
        public static DateTime dataformat(string date,char delim)
        {
            try
            {
                string[] datesplit = date.Split(delim);
                DateTime dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }
      

        public static DateTime dataformat(string date, char delim,int format)
        {
            try
            {
                string[] datesplit = date.Split(delim);
                DateTime dates=new DateTime();
                if (format == 1)
                {
                    dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[0]), Convert.ToInt32(datesplit[1]));
                }
                else if (format == 2)
                {
                   dates = new DateTime(Convert.ToInt32(datesplit[2]), Convert.ToInt32(datesplit[1]), Convert.ToInt32(datesplit[0]));
                }
                    return dates;
            }
            catch (Exception e)
            {
                throw new Exception("Error converting" + e.Message);
            }
        }

    }
}
