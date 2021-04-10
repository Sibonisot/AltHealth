using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Configuration;
using System.Web.UI;

namespace AltHealth.App.Forms.Suppliments
{
    public partial class ManageSupliments : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;
        /// <summary>
        /// Property to determine wherether you perform an update or create
        /// </summary>
        private bool IsUpdate = false;
        /// <summary>
        /// Overloaded constructor to pass injectors
        /// </summary>
        /// <param name="repositoryWrapper"></param>
        public ManageSupliments(IRepositoryWrapper repositoryWrapper)
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
            if(!Page.IsPostBack)
            {
                LoadSupplierLookup();

                IsUpdate = Request.HasQueryString(StringHelper.SupplimentID);

                CustomLinqExtensions.SetControlsForCreateOrUpdate(IsUpdate, hdnIsUpdate, txtSupplementIDS);
                
                PopulateFields();
            }
        }

        /// <summary>
        /// Load data when the supplier ID is supplied
        /// </summary>
        private void PopulateFields()
        {
            if (IsUpdate)
            {
                var supplimentId = Request.GetQueryString(StringHelper.SupplimentID);
                if (!string.IsNullOrWhiteSpace(supplimentId))
                {
                    tblSupplement tblSupplement = _repositoryWrapper.Suppliment.GetById(supplimentId);
                    txtSupplementIDS.Text = tblSupplement?.Supplement_id;
                    DdlSupplierID.SelectedValue = tblSupplement?.Supplier_Id;
                    txtDescription.Text = tblSupplement?.Supplement_Description;
                    txtNappiCode.Text = tblSupplement?.Nappi_code;
                    txtCostE.Text = tblSupplement?.Cost_excl.ToString();
                    txtCostI.Text = tblSupplement?.Cost_incl.ToString();
                    txtStock.Text = tblSupplement?.Current_Stock_Levels.ToString();
                    txtMinLevel.Text = tblSupplement?.Min_Level.ToString();
                }
            }
        }
        protected void txtCostE_TextChanged(object sender, EventArgs e)
        {
            var Rate = 1.15 /*double.Parse(ConfigurationManager.AppSettings["Rate"])*/;
            try
            {
                var costEx = float.Parse(txtCostE.Text);
                var result = Rate * costEx;

                txtCostI.Text = result.ToString();
            }
            catch { }
        }

        /// <summary>
        /// Populate supplements dropdown list
        /// </summary>
        private void LoadSupplierLookup()
        {
            DdlSupplierID.DataSource = _repositoryWrapper.Supplier.ListAll();
            DdlSupplierID.DataValueField = nameof(tblSupplier_info.Supplier_Id);
            DdlSupplierID.DataTextField = nameof(tblSupplier_info.Contact_Person);
            DdlSupplierID.DataBind();
        }
        /// <summary>
        /// Save user input to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            tblSupplement supplement = new tblSupplement
            {
                Supplement_id = txtSupplementIDS.Text,
                Supplement_Description = txtDescription.Text,
                Cost_excl = decimal.Parse(txtCostE.Text),
                Cost_incl = decimal.Parse(txtCostI.Text),
                Min_Level = int.Parse(txtMinLevel.Text),
                Current_Stock_Levels = int.Parse(txtStock.Text),
                Nappi_code = txtNappiCode.Text,
                Supplier_Id = DdlSupplierID.SelectedValue
            };
            IsUpdate = bool.Parse(hdnIsUpdate.Value);

            var dbSupplement = _repositoryWrapper.Suppliment.GetById(supplement.Supplement_id);
            if(!IsUpdate && dbSupplement != null)
            {
                lblError.Text = "Suppliment already exists in the database";
                return;
            }
            lblError.Text = string.Empty;

            if (dbSupplement == null)
                _repositoryWrapper.Suppliment.Add(supplement);
            else
                _repositoryWrapper.Suppliment.Update(supplement, supplement.Supplement_id);

            RedirectToList();
        }

        private void RedirectToList()
        {
            Response.Redirect("~/Forms/Suppliments/ViewSuppliments.aspx");
        }
      
    }
}