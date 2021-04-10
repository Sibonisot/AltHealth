using AltHealth.App.Utils;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Suppliers
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ViewSuppliers(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadSuppliersGrid();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadSuppliersGrid(txtSearch.Text);
        }
        private void LoadSuppliersGrid(string search = null)
        {            
            grdSuppliers.DataSource = _repositoryWrapper.Supplier.GetSuppliers(search);
            grdSuppliers.DataBind();
        }
        protected void grdSuppliers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSuppliers.PageIndex = e.NewPageIndex;
            LoadSuppliersGrid(txtSearch.Text);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Suppliers/ManageSuppliers.aspx");
        }

        protected void grdSuppliers_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdSuppliers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var supplierId = e.CommandArgument.ToString();
            if(e.CommandName == StringHelper.EditCommand)
            {
                Response.Redirect($"~/Forms/Suppliers/ManageSuppliers.aspx?SupplierID={supplierId}");
            }
        }

        protected void grdSuppliers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}