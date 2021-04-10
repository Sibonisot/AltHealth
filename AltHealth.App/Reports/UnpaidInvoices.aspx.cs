using AltHealth.App.Extensions;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Reports
{
    public partial class UnpaidInvoices : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UnpaidInvoices(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        /// <summary>
        /// Page initialisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadUnpaidInvoices();
        }
        /// <summary>
        /// Load unpaid invoices by retrieving them from database
        /// </summary>
        private void LoadUnpaidInvoices()
        {
            var items = _repositoryWrapper.InvoiceInfo.GetUnpaidInvoices().Select(p => new
            {
                p.Client_id,
                p.Name,
                p.Inv_Num,
                InvoiceDate = p.Inv_Date.ToString("dd MMMM yyyy")
            }).ToList();

            grdUnpaidInvoices.DataSource = items;
            grdUnpaidInvoices.DataBind();
        }
        protected void grdUnpaidInvoices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnpaidInvoices.PageIndex = e.NewPageIndex;
            LoadUnpaidInvoices();
        }
    }
}