using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_RatingMaster : System.Web.UI.Page
{

    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindratingrid();

        }
    }

    protected void gridratings_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridratings.EditIndex = -1;
        bindratingrid();
    }

    protected void gridratings_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridratings.EditIndex = e.NewEditIndex;
        bindratingrid();
    }

    protected void gridratings_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlParameter[] parm = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string rating = ((TextBox)gridratings.Rows[e.RowIndex].Cells[1].FindControl("txtrating")).Text;
            string ratingdesc = ((TextBox)gridratings.Rows[e.RowIndex].Cells[1].FindControl("txtratingdesc")).Text;

            int id = (int)gridratings.DataKeys[e.RowIndex].Value;
            Output.AssignParameter(parm, 0, "@rating", "Int", 0, rating);
            Output.AssignParameter(parm, 1, "@desc", "String", 8000, ratingdesc);
            Output.AssignParameter(parm, 2, "@rating_id", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 3, "@update_by", "String", 50, Session["empcode"].ToString());

            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_apprasial_updateratings", parm);

            if (i <= 0)
            {
                Output.Show("Rating name is already exists.please enter another Rating name");
            }
            else
            {

                Output.Show("Rating Detail has been updated successfully !");
                gridratings.EditIndex = -1;
                bindratingrid();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    private void bindratingrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select rating_id,rating,description from dbo.tbl_appraisal_rating";
            gridratings.DataSource = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gridratings.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["sno"] != null)
        {
            editrating();
            btnsubmit.Text = "Submit";
        }
        else
        {
            insertratings();
        }
        bindratingrid();
    }

    private void reset()
    {
        txt_Rating.Text = "";
        txtdescription.Text = "";
    }

    private void editrating()
    {
        SqlParameter[] parm = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            int id = Convert.ToInt32(Request.QueryString["sno"]);
            Output.AssignParameter(parm, 0, "@rating", "Int", 0, txt_Rating.Text);
            Output.AssignParameter(parm, 1, "@desc", "String", 8000, txtdescription.Text);
            Output.AssignParameter(parm, 2, "@rating_id", "Int", 0, id.ToString());

            int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_apprasial_updateratings", parm);

            if (i <= 0)
            {
                Output.Show("Rating  is already exists. Please enter anothor Rating ");
            }
            else
            {
                Output.Show("Rating Detail has been updated successfully !");
                reset();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void insertratings()
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        int i = 0;
        try
        {

            Output.AssignParameter(sqlparam, 0, "@rating", "Int", 0, txt_Rating.Text);
            Output.AssignParameter(sqlparam, 1, "@desc", "String", 1000, txtdescription.Text);
            Output.AssignParameter(sqlparam, 2, "@create_by", "String", 50, Session["empcode"].ToString());

            Connection = DataActivity.OpenConnection();

            i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_apprasial_insertratings", sqlparam);

            if (i <= 0)
            {
                Output.Show("Rating  is already exists. Please enter another Rating ");
            }
            else
            {
                Output.Show("Rating Detail has been created successfully !");
                reset();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void gridratings_PreRender(object sender, EventArgs e)
    {
        if (gridratings.Rows.Count > 0)
            gridratings.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gridratings.EmptyDataText = "No Records found.";
    }
}