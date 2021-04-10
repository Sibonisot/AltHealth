using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Suppliments
{
    public partial class ViewSuppliments : System.Web.UI.Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ViewSuppliments(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadSupplimentsGrid();
        }

        protected void grdSuppliments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSuppliments.PageIndex = e.NewPageIndex;
            LoadSupplimentsGrid(txtSearch.Text);
        }
        private void LoadSupplimentsGrid(string search = null)
        {           
            var items = _repositoryWrapper.Suppliment.GetSuppliments(search).Select(supplement => new
            {
                supplement.Supplement_id,
                supplement.Supplier_Id,
                supplement.Supplement_Description,
                CostExclV = supplement.Cost_excl.ToString("R0.00"),
                ConstIncV = supplement.Cost_incl.ToString("R0.00"),
                supplement.Current_Stock_Levels,
                supplement.Min_Level
            }).ToList();
            grdSuppliments.DataSource = items;
            grdSuppliments.DataBind();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Suppliments/ManageSupliments.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadSupplimentsGrid(txtSearch.Text);
        }

        protected void grdSuppliments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdSuppliments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var supplimentId = e.CommandArgument.ToString();
            if(e.CommandName == StringHelper.EditCommand)
            {
                Response.Redirect($"~/Forms/Suppliments/ManageSupliments.aspx?SupplimentID={supplimentId}");
            }
        }

        protected void grdSuppliments_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}