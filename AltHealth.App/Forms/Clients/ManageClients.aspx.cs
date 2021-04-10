using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Clients
{
    public partial class ManageClients : System.Web.UI.Page
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
        ///  Overloaded constructor to pass injectors 
        /// </summary>
        /// <param name="repositoryWrapper"></param>
        public ManageClients(IRepositoryWrapper repositoryWrapper)
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
            {
                PopulateDropDownList();
                IsUpdate = Request.HasQueryString(StringHelper.ClientID);
                CustomLinqExtensions.SetControlsForCreateOrUpdate(IsUpdate, hdnIsCreate, txtClientID);
                PopulateFields();
            }
        }

        /// <summary>
        /// Load data when client ID is supplied
        /// </summary>
        private void PopulateFields()
        {
            if (IsUpdate)
            {
                var clientId = Request.GetQueryString(StringHelper.ClientID);
                if (!string.IsNullOrWhiteSpace(clientId))
                {
                    tblClientInfo tblClientInfo = _repositoryWrapper.ClientInfo.GetById(clientId);
                    txtClientID.Text = tblClientInfo?.Client_id;
                    txtName.Text = tblClientInfo?.C_name;
                    txtSurname.Text = tblClientInfo.C_surname;
                    txtTelH.Text = tblClientInfo?.C_Tel_H;
                    txtTelW.Text = tblClientInfo?.C_Tel_W;
                    txtTelM.Text = tblClientInfo?.C_Tel_Cell;
                    txtAddress.Text = tblClientInfo?.Address;
                    txtACode.Text = tblClientInfo?.Code;
                    txtEmail.Text = tblClientInfo?.C_Email;
                    DropDownRefID.SelectedValue = tblClientInfo?.Reference_ID.ToString();
                }
            }
        }
       /// <summary>
       /// Save data to database when you click save button 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string idNumber = txtClientID.Text;
            IsUpdate = bool.Parse(hdnIsCreate.Value);
            if (!IsUpdate && !idNumber.IsValidSouthAfricaIdNumber())
            {
                lblIDError.Text = "Invalid South African Identity Number";
                return;
            }
            lblIDError.Text = string.Empty;

            tblClientInfo dbClient = _repositoryWrapper.ClientInfo.GetById(idNumber); 
            if(!IsUpdate && dbClient != null)
            {
                lblIDError.Text = "Client already exists in the database";
                return;
            }
            tblClientInfo clientInfo = new tblClientInfo
            {
                Client_id = idNumber,
                C_name = txtName.Text,
                C_surname = txtSurname.Text,
                Address = txtAddress.Text,
                Code = txtACode.Text,
                C_Tel_H = txtTelH.Text,
                C_Tel_W = txtTelW.Text,
                C_Tel_Cell = txtTelM.Text,
                C_Email = txtEmail.Text,
                Reference_ID = int.Parse(DropDownRefID.SelectedValue)
            };
            if (dbClient == null)
                _repositoryWrapper.ClientInfo.Add(clientInfo);
            else
                _repositoryWrapper.ClientInfo.Update(clientInfo, clientInfo.Client_id);

            Response.Redirect("~/Forms/Clients/ViewClients.aspx");
            //ClearControls();
        }
        /// <summary>
        /// Clear all user input
        /// </summary>
        private void ClearControls()
        {
            txtClientID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtACode.Text = string.Empty;
            txtTelH.Text = string.Empty;
            txtTelW.Text = string.Empty;
            txtTelM.Text = string.Empty;
            txtEmail.Text = string.Empty;
            DropDownRefID.SelectedValue = string.Empty;
        }

        protected void txtTelH_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtClientID_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Populate dropdown list to select a reference
        /// </summary>
    
        private void PopulateDropDownList()
        {
            DropDownRefID.DataSource = _repositoryWrapper.Reference.ListAll();
            DropDownRefID.DataValueField = nameof(tblReference.Reference_ID);
            DropDownRefID.DataTextField = nameof(tblReference.Description);
            DropDownRefID.DataBind();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Redirect to view clients page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        protected void btnViewClients_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Clients/ViewClients.aspx");
        }
    }
}