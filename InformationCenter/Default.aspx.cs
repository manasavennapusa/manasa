using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformationCenter_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private string saveDir = @"Uploads\";

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && FileUpload1.FileBytes.Length < 10000 &&
            !CheckForFileName())
        {
            string savePath = Request.PhysicalApplicationPath + saveDir +
                Server.HtmlEncode(FileName.Text);
            //Remove comment from the next line to upload file.
            //FileUpload1.SaveAs(savePath);
            UploadStatusLabel.Text = "The file was processed successfully.";
        }
        else
        {
            UploadStatusLabel.Text = "You did not specify a file to upload, or a file name, or the file was too large. Please try again.";
        }
    }

    protected void CheckButton_Click(object sender, EventArgs e)
    {
        if (FileName.Text.Length > 0)
        {
            string s = CheckForFileName() ? "exists already." : "does not exist.";
            UploadStatusLabel.Text = "The file name choosen " + s;
        }
        else
        {
            UploadStatusLabel.Text = "Specify a file name to check.";
        }
    }
    private Boolean CheckForFileName()
    {
        System.IO.FileInfo fi = new System.IO.FileInfo(Request.PhysicalApplicationPath + 
            saveDir + Server.HtmlEncode(FileName.Text));
            return fi.Exists;
    }

    }
