using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Reports
{
    public partial class ClientsWithNoEmails : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ClientsWithNoEmails(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        /// <summary>
        /// Initialise page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadClientWithNoEmails();
        }

        /// <summary>
        /// Retrieve clients with no emails from database
        /// </summary>
        private void LoadClientWithNoEmails()
        {
            grdClientWithEmails.DataSource = _repositoryWrapper.ClientInfo.GetClientsWithNoEmails();
            grdClientWithEmails.DataBind();
        }
        protected void grdClientWithEmails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientWithEmails.PageIndex = e.NewPageIndex;
            LoadClientWithNoEmails();
        }
    }
}