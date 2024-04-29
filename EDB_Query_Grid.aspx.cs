using Smart.HR.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EDB_Query_Grid : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["dtgrid"];
        if (!IsPostBack)
        {
            binddata();
        }
    }

    protected void binddata()
    {
        if (Session["dtgrid"] != null)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=Empdetails.xls");

        GridView1.HeaderStyle.Font.Bold = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.HeaderRow.BackColor = System.Drawing.Color.White;
            GridView1.GridLines = GridLines.Horizontal;

            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {

                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        GridView1.GridLines = GridLines.Both;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                        GridView1.GridLines = GridLines.Both;
                    }
                    cell.CssClass = "textmode";
                    GridView1.GridLines = GridLines.Both;
                }
            }
            GridView1.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

}