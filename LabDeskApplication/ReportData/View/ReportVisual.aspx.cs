using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabDeskApplication.Report.View
{
    public partial class ReportVisual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
        private void ShowReport()
        {
            DataTable xTableStyleReport = GetReportByStyleID(txtStyleID.Text);
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = "ReportData/Report/Article01Report.rdlc";
            ReportDataSource ds = new ReportDataSource("DataSet1", xTableStyleReport);
            ReportViewer1.LocalReport.DataSources.Add(ds);
            ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ResultDataProcessing);
            ReportViewer1.LocalReport.Refresh();
        }
        //GetOrdersByDates
        private DataTable GetReportByStyleID(string StyleCodeID)
        {
            DataTable xTable = new DataTable();
            using (SqlConnection xConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string xQuery = @"SELECT ArtInfo.StyleCode, SProduct.ProductName, ArtInfo.LabID, ArtInfo.ArticleID, StyInfo.StyleID, StyInfo.SampleDate
                , StyInfo.Sample, StyInfo.Volume, StyInfo.Year, StyInfo.Width, SColor.ColourName, SArt.ArticleType, SResult.ResultName, SUser.UserName
                FROM LogInitialArticle AS ArtInfo INNER JOIN SetupProduct SProduct ON SProduct.ProductID = ArtInfo.ProductID

                LEFT JOIN LogInitialStyle StyInfo ON StyInfo.ArticleID = ArtInfo.ArticleID
                INNER JOIN SetupResult SResult ON StyInfo.ResultID = SResult.ResultID
                INNER JOIN SetupColor SColor ON SColor.ColourID = StyInfo.ColourID
                INNER JOIN SetupArticleType SArt ON SArt.ArticleTypeId = StyInfo.ArticleTypeId
                INNER JOIN SetupUserInfo SUser ON SUser.UserID = StyInfo.UserID

                WHERE StyleCode = '" + StyleCodeID + "';";
                SqlCommand xCommand = new SqlCommand(xQuery, xConn);
                xConn.Open();
                SqlDataReader xReader = xCommand.ExecuteReader();
                if (xReader.HasRows)
                {
                    xTable.Load(xReader);
                }
            }
            return xTable;
        }
        void ResultDataProcessing(object sender, SubreportProcessingEventArgs e)
        {
            int StyleID = int.Parse(e.Parameters["StyleID"].Values[0].ToString());
            DataTable dtValues = GetReportTestValues(StyleID);
            ReportDataSource ds = new ReportDataSource("DataSet1", dtValues);
            e.DataSources.Add(ds);
        }
        private DataTable GetReportTestValues(int xStyleID)
        {
            DataTable xTable = new DataTable();
            using (SqlConnection xConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string xQuery = @"SELECT ResData.TestApproachID, TApproach.TestName, TApproach.TestStandard, TApproach.TestApproachName01, TApproach.TestApproachName02, TApproach.TestApproachName03
                        , TApproach.TestApproachName04, TApproach.TestApproachName04, TApproach.TestApproachName05, TApproach.Remarks
                        , ResData.TestNameID, ResData.TestValues01, ResData.TestValues02, ResData.TestValues03, ResData.TestValues04, ResData.TestValues05, Result.ResultName, ResData.StyleID, ResData.Comments 
                        FROM TestValues ResData INNER JOIN TestApproach TApproach ON TApproach.TestApproachID = ResData.TestApproachID 
                        INNER JOIN SetupResult Result ON Result.ResultID = ResData.ResultID
                        WHERE StyleID ='" + xStyleID + "';";
                SqlCommand xCommand = new SqlCommand(xQuery, xConn);
                xConn.Open();
                SqlDataReader xReader = xCommand.ExecuteReader();
                if (xReader.HasRows)
                {
                    xTable.Load(xReader);
                }
            }
            return xTable;
        }
    }
}