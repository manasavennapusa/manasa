using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Word;

public partial class recruitment_viewresume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string sb = (string)Session["FileData"];
            Label lt = new Label();
            lt.Text = sb.ToString();
            //myPanel.Controls.Add(lt);6
            //view();
            string filepath = (string)Session["FileData"];
            readFileContent(filepath);
            //frmDoc.Attributes.Add("src", filepath);
            //abc(filepath);
        }
        
    }
    protected void view()
    {
        string filepath = (string)Session["FileData"];
        //WebClient client = new WebClient();
        //Byte[] buffer = client.DownloadData(filepath);
        //Response.ContentType = "application/msword";
        //Response.AddHeader("content-length", buffer.Length.ToString());
        //Response.BinaryWrite(buffer);

        FileInfo file = new FileInfo(filepath);

        Response.ClearContent();

        Response.AddHeader("Content-Disposition", "inline;filename=" + file.Name);

        Response.AddHeader("Content-Length", file.Length.ToString());

        Response.ContentType = "application/msword";

        Response.TransmitFile(file.FullName);

        Response.End();

        

 
    }
    private void readFileContent(string path)
    {
        if (path != "")
        {
            ApplicationClass wordApp = new ApplicationClass();

            object file = path;

            object nullobj = System.Reflection.Missing.Value;

            //Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(

            //ref file, ref nullobj, ref nullobj,

            //ref nullobj, ref nullobj, ref nullobj,

            //ref nullobj, ref nullobj, ref nullobj,

            //ref nullobj, ref nullobj, ref nullobj,

            //ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj,
                                             ref nullobj, ref nullobj, ref nullobj,
                                             ref nullobj, ref nullobj, ref nullobj,
                                             ref nullobj, ref nullobj, ref nullobj);

            doc.ActiveWindow.Selection.WholeStory();

            doc.ActiveWindow.Selection.Copy();

            string sFileText = doc.Content.Text;
            int i = 1;

            foreach (Microsoft.Office.Interop.Word.Paragraph objParagraph
                     in doc.Paragraphs)
            {
                try
                {
                    txt.Text += doc.Paragraphs[i].Range.Text;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                i++;
            }
 

            doc.Close(ref nullobj, ref nullobj, ref nullobj);

            wordApp.Quit(ref nullobj, ref nullobj, ref nullobj);

           // Response.Write(sFileText);
            //mydiv.InnerHtml = sFileText;
        }
        else
        {
            message.InnerHtml = "Resume Not Found.";  
        }
    }


    void abc(string path)
    { 
        //string path = Server.MapPath(strRequest); //get file object as FileInfo  
         System.IO.FileInfo file = new System.IO.FileInfo(path); //-- if the file exists on the server  


         if (file.Exists) //set appropriate headers  
         {
             Response.Clear();
             Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
             Response.AddHeader("Content-Length", file.Length.ToString());
             Response.ContentType = "application/octet-stream";


             // write file to browser
             Response.WriteFile(file.FullName);


             Response.End();

         }
    }
}