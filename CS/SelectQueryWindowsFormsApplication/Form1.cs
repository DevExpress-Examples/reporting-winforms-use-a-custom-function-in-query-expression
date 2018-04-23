using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;
// ...

namespace SelectQueryWindowsFormsApplication {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Register the custom function.
            StDevOperator.Register();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a data source connection.
            Access97ConnectionParameters connectionParameters = new Access97ConnectionParameters("../../nwind.mdb", "", "");
            SqlDataSource ds = new SqlDataSource(connectionParameters);

            // Create a query and specify its SELECT expression.
            SelectQuery query = SelectQueryFluentBuilder
                .AddTable("Products")
                .SelectColumn("CategoryID")
                .GroupBy("CategoryID")
                .SelectExpression("StDev([Products].[UnitPrice])", "PriceDeviation")
                .Build("Products");

            //Add the query to the data source.

            ds.Queries.Add(query);

            // Fill the data source.
            ds.Fill();

            // Create a new report and bind it to the data source.
            XtraReport report = new XtraReport();
            report.DataSource = ds;
            report.DataMember = "Products";

            // Create a report layout.
            DetailBand detailBand = new DetailBand();
            detailBand.Height = 50;
            report.Bands.Add(detailBand);

            XRLabel labelCategory = new XRLabel();
            labelCategory.DataBindings.Add("Text", report.DataSource, "Products.CategoryID", "Category ID: {0}");
            labelCategory.TopF = 15;
            detailBand.Controls.Add(labelCategory);

            XRLabel labelDeviation = new XRLabel();
            labelDeviation.DataBindings.Add("Text", report.DataSource, "Products.PriceDeviation", "Price Deviation: {0}");
            labelDeviation.TopF = 30;
            labelDeviation.WidthF = 500;
            detailBand.Controls.Add(labelDeviation);

            // Publish the report.
            ReportPrintTool pt = new ReportPrintTool(report);
            pt.ShowPreviewDialog();
        }
    }
}
