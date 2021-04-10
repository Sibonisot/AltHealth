using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;

namespace AltHealth.App.Reports
{
    public partial class PurchaseStats : System.Web.UI.Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PurchaseStats(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPurchaseStatsChart();
                SetYearLookup();
            }
        }
        private void LoadPurchaseStatsChart(int? startYear = null)
        {
            
            ChrtStats.DataSource = _repositoryWrapper.InvoiceInfo.GetPurchaseStats(startYear);
            ChrtStats.DataBind();
            Title title = ChrtStats.Titles.FindByName("Number of Purchases");
            if (title != null)
                ChrtStats.Titles.FindByName("Number of Purchases").Text = $"Number of Purchases from {startYear ?? 2012} to Now";
        }

       
        private void SetYearLookup()
        {
            List<int> Years = new List<int>();
            int start = 2012;
            while(start <= DateTime.Now.Year - 1)
            {
                Years.Add(start);
                start++;
            }
            DdlYears.DataSource = Years;
            DdlYears.DataBind();
        }

        protected void DdlYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPurchaseStatsChart(int.Parse(DdlYears.SelectedValue));
        }
    }
}