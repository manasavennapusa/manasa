using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;
using System;
using System.Configuration;
using Common.Data;
using Common.Console;
using Smart.HR.Common.Encode;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class informationcenter_empsatisfactionsurvey : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        // message.InnerHtml = "";        
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {

            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }




    }
    protected void ddl_term_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Insert_empsatisfactionsurvey();
    }

    protected void Insert_empsatisfactionsurvey()
    {
        var parm = new SqlParameter[57];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@mulfeedback1", "String", 1000, txt_hremployee.Text);
            Output.AssignParameter(parm, 1, "@mulfeedback2", "String", 1000, txt_hrdepartment.Text);
            Output.AssignParameter(parm, 2, "@mulfeedback3", "String", 1000, txt_hrinformation.Text);
            Output.AssignParameter(parm, 3, "@mulfeedback4", "String", 1000, txt_hrdifficult.Text);
            Output.AssignParameter(parm, 4, "@mulfeedback5", "String", 1000, txt_infservice.Text);
            Output.AssignParameter(parm, 5, "@mulfeedback6", "String", 1000, txt_problem.Text);


            if (rdo_but1.SelectedItem != null)
            {
                Output.AssignParameter(parm, 6, "@feedback6", "Int", 0, rdo_but1.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 6, "@feedback6", "Int", 0, "0");
            }

            if (rdo_but2.SelectedItem != null)
            {
                Output.AssignParameter(parm, 7, "@feedback7", "Int", 0, rdo_but2.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 7, "@feedback7", "Int", 0, "0");
            }


            if (rdo_but3.SelectedItem != null)
            {
                Output.AssignParameter(parm, 8, "@feedback8", "Int", 0, rdo_but3.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 8, "@feedback8", "Int", 0, "0");
            }



            if (rdo_but4.SelectedItem != null)
            {
                Output.AssignParameter(parm, 9, "@feedback9", "Int", 0, rdo_but4.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 9, "@feedback9", "Int", 0, "0");
            }



            if (rdo_but5.SelectedItem != null)
            {
                Output.AssignParameter(parm, 10, "@feedback10", "Int", 0, rdo_but5.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 10, "@feedback10", "Int", 0, "0");
            }



            if (rdo_but6.SelectedItem != null)
            {
                Output.AssignParameter(parm, 11, "@feedback11", "Int", 0, rdo_but6.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 11, "@feedback11", "Int", 0, "0");
            }



            if (rdo_but7.SelectedItem != null)
            {
                Output.AssignParameter(parm, 12, "@feedback12", "Int", 0, rdo_but7.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 12, "@feedback12", "Int", 0, "0");
            }


            if (rdo_but8.SelectedItem != null)
            {
                Output.AssignParameter(parm, 13, "@feedback13", "Int", 0, rdo_but8.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 13, "@feedback13", "Int", 0, "0");
            }

            if (rdo_but9.SelectedItem != null)
            {
                Output.AssignParameter(parm, 14, "@feedback14", "Int", 0, rdo_but9.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 14, "@feedback14", "Int", 0, "0");
            }


            if (rdo_but10.SelectedItem != null)
            {
                Output.AssignParameter(parm, 15, "@feedback15", "Int", 0, rdo_but10.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 15, "@feedback15", "Int", 0, "0");
            }

            if (rdo_but11.SelectedItem != null)
            {
                Output.AssignParameter(parm, 16, "@feedback16", "Int", 0, rdo_but11.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 16, "@feedback16", "Int", 0, "0");
            }



            if (rdo_but12.SelectedItem != null)
            {
                Output.AssignParameter(parm, 17, "@feedback17", "Int", 0, rdo_but12.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 17, "@feedback17", "Int", 0, "0");
            }



            if (rdo_but13.SelectedItem != null)
            {
                Output.AssignParameter(parm, 18, "@feedback18", "Int", 0, rdo_but13.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 18, "@feedback18", "Int", 0, "0");
            }


            if (rdo_but14.SelectedItem != null)
            {
                Output.AssignParameter(parm, 19, "@feedback19", "Int", 0, rdo_but14.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 19, "@feedback19", "Int", 0, "0");
            }



            if (rdo_but15.SelectedItem != null)
            {
                Output.AssignParameter(parm, 20, "@feedback20", "Int", 0, rdo_but15.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 20, "@feedback20", "Int", 0, "0");
            }



            if (rdo_but16.SelectedItem != null)
            {
                Output.AssignParameter(parm, 21, "@feedback21", "Int", 0, rdo_but16.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 21, "@feedback21", "Int", 0, "0");
            }


            ////--------------------------------------------------------

            if (rdo_but17.SelectedItem != null)
            {
                Output.AssignParameter(parm, 22, "@feedback22", "Int", 0, rdo_but17.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 22, "@feedback22", "Int", 0, "0");
            }


            if (rdo_but18.SelectedItem != null)
            {
                Output.AssignParameter(parm, 23, "@feedback23", "Int", 0, rdo_but18.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 23, "@feedback23", "Int", 0, "0");
            }


            if (rdo_but19.SelectedItem != null)
            {
                Output.AssignParameter(parm, 24, "@feedback24", "Int", 0, rdo_but19.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 24, "@feedback24", "Int", 0, "0");
            }



            if (rdo_but20.SelectedItem != null)
            {
                Output.AssignParameter(parm, 25, "@feedback25", "Int", 0, rdo_but20.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 25, "@feedback25", "Int", 0, "0");
            }



            if (rdo_but21.SelectedItem != null)
            {
                Output.AssignParameter(parm, 26, "@feedback26", "Int", 0, rdo_but21.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 26, "@feedback26", "Int", 0, "0");
            }


            if (rdo_but22.SelectedItem != null)
            {
                Output.AssignParameter(parm, 27, "@feedback27", "Int", 0, rdo_but22.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 27, "@feedback27", "Int", 0, "0");
            }

            ////------------------------------------------------------



            if (rdo_but23.SelectedItem != null)
            {
                Output.AssignParameter(parm, 28, "@feedback28", "Int", 0, rdo_but23.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 28, "@feedback28", "Int", 0, "0");
            }



            if (rdo_but24.SelectedItem != null)
            {
                Output.AssignParameter(parm, 29, "@feedback29", "Int", 0, rdo_but24.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 29, "@feedback29", "Int", 0, "0");
            }



            if (rdo_but25.SelectedItem != null)
            {
                Output.AssignParameter(parm, 30, "@feedback30", "Int", 0, rdo_but25.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 30, "@feedback30", "Int", 0, "0");
            }


            if (rdo_but26.SelectedItem != null)
            {
                Output.AssignParameter(parm, 31, "@feedback31", "Int", 0, rdo_but26.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 31, "@feedback31", "Int", 0, "0");
            }



            if (rdo_but27.SelectedItem != null)
            {
                Output.AssignParameter(parm, 32, "@feedback32", "Int", 0, rdo_but27.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 32, "@feedback32", "Int", 0, "0");
            }



            if (rdo_but28.SelectedItem != null)
            {
                Output.AssignParameter(parm, 33, "@feedback33", "Int", 0, rdo_but28.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 33, "@feedback33", "Int", 0, "0");
            }


            if (rdo_but29.SelectedItem != null)
            {
                Output.AssignParameter(parm, 34, "@feedback34", "Int", 0, rdo_but29.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 34, "@feedback34", "Int", 0, "0");
            }



            if (rdo_but30.SelectedItem != null)
            {
                Output.AssignParameter(parm, 35, "@feedback35", "Int", 0, rdo_but30.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 35, "@feedback35", "Int", 0, "0");
            }



            if (rdo_but31.SelectedItem != null)
            {
                Output.AssignParameter(parm, 36, "@feedback36", "Int", 0, rdo_but31.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 36, "@feedback36", "Int", 0, "0");
            }



            if (rdo_but32.SelectedItem != null)
            {
                Output.AssignParameter(parm, 37, "@feedback37", "Int", 0, rdo_but32.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 37, "@feedback37", "Int", 0, "0");
            }
            ////*****************************************************************************



            if (rdo_but33.SelectedItem != null)
            {
                Output.AssignParameter(parm, 38, "@feedback38", "Int", 0, rdo_but33.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 38, "@feedback38", "Int", 0, "0");
            }




            if (rdo_but34.SelectedItem != null)
            {
                Output.AssignParameter(parm, 39, "@feedback39", "Int", 0, rdo_but34.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 39, "@feedback39", "Int", 0, "0");
            }






            if (rdo_but35.SelectedItem != null)
            {
                Output.AssignParameter(parm, 40, "@feedback40", "Int", 0, rdo_but35.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 40, "@feedback40", "Int", 0, "0");
            }




            if (rdo_but36.SelectedItem != null)
            {
                Output.AssignParameter(parm, 41, "@feedback41", "Int", 0, rdo_but36.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 41, "@feedback41", "Int", 0, "0");
            }



            if (rdo_but37.SelectedItem != null)
            {
                Output.AssignParameter(parm, 42, "@feedback42", "Int", 0, rdo_but37.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 42, "@feedback42", "Int", 0, "0");
            }



            if (rdo_but38.SelectedItem != null)
            {
                Output.AssignParameter(parm, 43, "@feedback43", "Int", 0, rdo_but38.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 43, "@feedback43", "Int", 0, "0");
            }


            if (rdo_but39.SelectedItem != null)
            {
                Output.AssignParameter(parm, 44, "@feedback44", "Int", 0, rdo_but39.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 44, "@feedback44", "Int", 0, "0");
            }


            if (rdo_but40.SelectedItem != null)
            {
                Output.AssignParameter(parm, 45, "@feedback45", "Int", 0, rdo_but40.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 45, "@feedback45", "Int", 0, "0");
            }



            if (rdo_but41.SelectedItem != null)
            {
                Output.AssignParameter(parm, 46, "@feedback46", "Int", 0, rdo_but41.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 46, "@feedback46", "Int", 0, "0");
            }



            if (rdo_but42.SelectedItem != null)
            {
                Output.AssignParameter(parm, 47, "@feedback47", "Int", 0, rdo_but42.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 47, "@feedback47", "Int", 0, "0");
            }


            if (rdo_but43.SelectedItem != null)
            {
                Output.AssignParameter(parm, 48, "@feedback48", "Int", 0, rdo_but43.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 48, "@feedback48", "Int", 0, "0");
            }



            if (rdo_but44.SelectedItem != null)
            {
                Output.AssignParameter(parm, 49, "@feedback49", "Int", 0, rdo_but44.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 49, "@feedback49", "Int", 0, "0");
            }



            if (rdo_but45.SelectedItem != null)
            {
                Output.AssignParameter(parm, 50, "@feedback50", "Int", 0, rdo_but45.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 50, "@feedback50", "Int", 0, "0");
            }

            if (rdo_but46.SelectedItem != null)
            {
                Output.AssignParameter(parm, 51, "@feedback51", "Int", 0, rdo_but46.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 51, "@feedback51", "Int", 0, "0");
            }


            if (rdo_but47.SelectedItem != null)
            {
                Output.AssignParameter(parm, 52, "@feedback52", "Int", 0, rdo_but47.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 52, "@feedback52", "Int", 0, "0");
            }

            if (rdo_but48.SelectedItem != null)
            {
                Output.AssignParameter(parm, 53, "@feedback53", "Int", 0, rdo_but48.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 53, "@feedback53", "Int", 0, "0");
            }

            if (rdo_but49.SelectedItem != null)
            {
                Output.AssignParameter(parm, 54, "@feedback54", "Int", 0, rdo_but49.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 54, "@feedback54", "Int", 0, "0");
            }

            if (rdo_but50.SelectedItem != null)
            {
                Output.AssignParameter(parm, 55, "@feedback55", "Int", 0, rdo_but50.SelectedItem.Value);
            }
            else
            {
                Output.AssignParameter(parm, 55, "@feedback55", "Int", 0, "0");
            }


            Output.AssignParameter(parm, 56, "@createdby", "String", 50, _userCode.ToString());

            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_informationemployeefeedback", parm);
            transaction.Commit();


        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {
            //clear();
            Output.Show("Training created successfully");
            Clear();
        }
        else
        {
            Output.Show("This training already exists, try again");


        }


    }


    protected void Clear()
    {
      
        rdo_but1.SelectedValue = "";
        rdo_but2.SelectedValue = "";
        rdo_but3.SelectedValue = "";
        rdo_but4.SelectedValue = "";
        rdo_but5.SelectedValue = "";
        rdo_but6.SelectedValue = "";
        rdo_but7.SelectedValue = "";
        rdo_but8.SelectedValue = "";
        rdo_but9.SelectedValue = "";
        rdo_but10.SelectedValue = "";
        rdo_but11.SelectedValue = "";
        rdo_but12.SelectedValue = "";
        rdo_but13.SelectedValue = "";
        rdo_but14.SelectedValue = "";
        rdo_but15.SelectedValue = "";
        rdo_but16.SelectedValue = "";
        rdo_but17.SelectedValue = "";
        rdo_but18.SelectedValue = "";
        rdo_but19.SelectedValue = "";
        rdo_but20.SelectedValue = "";
        rdo_but21.SelectedValue = "";
        rdo_but22.SelectedValue = "";
        rdo_but23.SelectedValue = "";
        rdo_but24.SelectedValue = "";
        rdo_but25.SelectedValue = "";
        rdo_but26.SelectedValue = "";
        rdo_but27.SelectedValue = "";
        rdo_but28.SelectedValue = "";
        rdo_but29.SelectedValue = "";
        rdo_but30.SelectedValue = "";
        rdo_but31.SelectedValue = "";
        rdo_but32.SelectedValue = "";
        rdo_but33.SelectedValue = "";
        rdo_but34.SelectedValue = "";
        rdo_but35.SelectedValue = "";
        rdo_but36.SelectedValue = "";
        rdo_but37.SelectedValue = "";
        rdo_but38.SelectedValue = "";
        rdo_but39.SelectedValue = "";
        rdo_but40.SelectedValue = "";
        rdo_but41.SelectedValue = "";
        rdo_but42.SelectedValue = "";
        rdo_but43.SelectedValue = "";
        rdo_but44.SelectedValue = "";
        rdo_but45.SelectedValue = "";
        rdo_but46.SelectedValue = "";
        rdo_but47.SelectedValue = "";
        rdo_but48.SelectedValue = "";
        rdo_but49.SelectedValue = "";
        rdo_but50.SelectedValue = "";
        txt_hremployee.Text = "";
        txt_hrdepartment.Text = "";
        txt_hrinformation.Text = "";
        txt_hrdifficult.Text = "";
        txt_infservice.Text = "";
        txt_problem.Text = "";

    }
}

