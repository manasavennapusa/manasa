using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using encodequerystring;



using System.Collections;


/// <summary>
/// Summary description for Class1
/// </summary>
namespace querystring
{
    public class query
    {
        public string this[string ordinal]
        {
            get
            {
                if (ordinal == "")
                {
                    return null;
                }
                if (HttpContext.Current.Request.QueryString["q"] == null)
                {
                    return null;
                }

                // decodes to name/value pairs: id=1&something=what&test=true
                string decode;
                try
                {
                    decode = encodequerystring.Base64.Decode(HttpContext.Current.Request.QueryString["q"]);
                }
                catch (Exception)
                {
                    return null;
                }

                string[] pairs = decode.Split('&');

                foreach (string pair in pairs)
                {
                    string[] item = pair.Split('=');

                    if (item[0].ToLower() == ordinal.ToLower())
                    {
                        return item[1];
                    }
                }

                return null;
            }






        }
        public string EncodePairs(string data)
        {
            if (data == "")
            {
                return "";
            }

            return encodequerystring.Base64.Encode(data);
        }
        public static Boolean authnthicate( )
        {
            string a = System.IO.Path.GetFileName(HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"]);
            string[] rols = Convert.ToString(HttpContext.Current.Session["rols"]).Split(new char[] { '|' });
            foreach (string s in rols)
            {
                if (s == a)
                {
                    return true;

                }
               
            }
            return false;
        }

    }
}