using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Reports
{
    public partial class TTClients : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TTClients(IRepositoryWrapper repositoryWrapper)
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
                LoadTopTenClients();
        }
        /// <summary>
        /// Retrieve Top Ten clients from database
        /// </summary>
        private void LoadTopTenClients()
        {
            chtTopClients.DataSource = _repositoryWrapper.ClientInfo.GetTopTenClients();
            chtTopClients.DataBind();
        }

       
    }
}