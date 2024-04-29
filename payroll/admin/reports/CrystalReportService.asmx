<%@ webservice language="C#" class="CrystalReportService" %>

using System;
using System.Web.Services;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web.Services;

[ WebService( Namespace="http://crystaldecisions.com/reportwebservice/9.1/" ) ]
public class CrystalReportService : ReportServiceBase
{
    public CrystalReportService()
    {
        //
        // TODO: Add any constructor code required
        //
        this.ReportSource = this.Server.MapPath( "CrystalReport.rpt" );
    }
}


