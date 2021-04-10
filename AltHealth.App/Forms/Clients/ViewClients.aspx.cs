using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Clients
{
    public partial class ViewClients : System.Web.UI.Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ViewClients(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadClients();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadClients(txtSearch.Text);
        }

        protected void grdClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClients.PageIndex = e.NewPageIndex;
            LoadClients(txtSearch.Text);
        }

        /// <summary>
        /// Load a list of Clients to the Gridview
        /// </summary>
        /// <param name="search"></param>
        private void LoadClients(string search = null)
        {
            grdClients.DataSource = _repositoryWrapper.ClientInfo.GetClients(search);
            grdClients.DataBind();
        }

        protected void grdClients_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var clientId = e.CommandArgument.ToString();
            if(e.CommandName == StringHelper.EditCommand)
            {
                Response.Redirect($"~/Forms/Clients/ManageClients.aspx?ClientID={clientId}");
            }
        }
    }
}