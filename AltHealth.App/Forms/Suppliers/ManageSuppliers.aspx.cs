using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Suppliers
{
    public partial class ManageSuppliers : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;
        /// <summary>
        /// Property to determine wherether you perform an update or create
        /// </summary>
        private bool IsUpddate = false;
            /// <summary>
            /// Overloaded constructor to pass injectors 
            /// </summary>
            /// <param name="repositoryWrapper"></param>
        public ManageSuppliers(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        // <summary>
        /// Page initialisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IsUpddate = Request.HasQueryString(StringHelper.SupplierID);
                CustomLinqExtensions.SetControlsForCreateOrUpdate(IsUpddate, hdnIsUpdate, txtSupplierIDS);
                PopulateFields();
            }
        }
        /// <summary>
        /// Load data when the supplier ID is supplied
        /// </summary>
        private void PopulateFields()
        {
            if (IsUpddate)
            {
                var supplierId = Request.GetQueryString(StringHelper.SupplierID);
                if (!string.IsNullOrWhiteSpace(supplierId))
                {
                    var supplier = _repositoryWrapper.Supplier.GetById(supplierId);
                    txtSupplierIDS.Text = supplier?.Supplier_Id;
                    txtContactPerson.Text = supplier?.Contact_Person;
                    txtEmailS.Text = supplier?.Supplier_Email;
                    txtSupplierTel.Text = supplier?.Supplier_Tel;
                    txtBank.Text = supplier?.Bank;
                    txtBankCode.Text = supplier?.Bank_Code;
                    txtBankNo.Text = supplier?.Supplier_BankNum;
                    DropDownType.SelectedValue = supplier?.Supplier_Type_Bank_Annount;
                }
            }
        }
        protected void btnViewSuppliers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Suppliers/ViewSuppliers.aspx");
        }
        /// <summary>
        /// Save data to database when you click save button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveS_Click(object sender, EventArgs e)
        {
            IsUpddate = bool.Parse(hdnIsUpdate.Value);
            tblSupplier_info dbSupplier = _repositoryWrapper.Supplier.GetById(txtSupplierIDS.Text);
            if(dbSupplier != null && !IsUpddate)
            {
                lblError.Text = "Supplier already exist";
                return;
            }
            lblError.Text = string.Empty;
            tblSupplier_info supplier_Info = new tblSupplier_info
            {
                Supplier_Id = txtSupplierIDS.Text,
                Contact_Person = txtContactPerson.Text,
                Supplier_Tel = txtSupplierTel.Text,
                Supplier_Email = txtEmailS.Text,
                Bank = txtBank.Text,
                Bank_Code = txtBankCode.Text,
                Supplier_BankNum = txtBankNo.Text,
                Supplier_Type_Bank_Annount = DropDownType.SelectedValue
            };
            if (dbSupplier != null)
                _repositoryWrapper.Supplier.Update(supplier_Info, supplier_Info.Supplier_Id);
            else
                _repositoryWrapper.Supplier.Add(supplier_Info);

            Response.Redirect("~/Forms/Suppliers/ViewSuppliers.aspx");
        }
        /// <summary>
        /// Clear all user input
        /// </summary>
        private void ClearControls()
        {
            txtSupplierIDS.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtSupplierTel.Text = string.Empty;
            txtEmailS.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtBankCode.Text = string.Empty;
            txtBankNo.Text = string.Empty;
            DropDownType.SelectedValue = string.Empty;
        }

        protected void txtBank_TextChanged(object sender, EventArgs e)
        {

        }
    }
}