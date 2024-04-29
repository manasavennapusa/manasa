using Common.Console;
using Common.Data;
using DataAccessLayer;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;

public partial class Authenticate : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       Page.RegisterStartupScript("Pop", "<script> javascript:window.open('default.aspx','_top','')</script>");
        
          
    }
   
}
