using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using AltHealth.EmailHelper.Classes;
using AltHealth.EmailHelper.Interfaces;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Shopping
{
    public partial class Cart : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;
        /// <summary>
        /// Property for the email sender service
        /// </summary>
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// Property to determine wherether you perform an update or create
        /// </summary>
        private bool IsUpdate = false;
        /// <summary>
        /// Overloaded constructor to pass injectors 
        /// </summary>
        /// <param name="repositoryWrapper"></param>
        /// <param name="emailSender"></param>
        public Cart(IRepositoryWrapper repositoryWrapper,
                   IEmailSender emailSender)
        {
            _repositoryWrapper = repositoryWrapper;
            _emailSender = emailSender;
        }
        /// <summary>
        /// Page initialisation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadClientsLookup();
                LoadSupplimentLookup();
                IsUpdate = Request.HasQueryString(StringHelper.InvoiceNumber);
                CustomLinqExtensions.SetControlsForCreateOrUpdate(IsUpdate, hdnIsUpdate);

                lblInvoiceNo.Text = IsUpdate ? Request.GetQueryString(StringHelper.InvoiceNumber) : _repositoryWrapper.InvoiceInfo.GenerateInvoiceNumber();

                PopulateFields(lblInvoiceNo.Text);
            }
        }
        /// <summary>
        /// Load data when the invoice is supplied
        /// </summary>
        /// <param name="invoiceNo"></param>
        private void PopulateFields(string invoiceNo)
        {
            if (IsUpdate)
            {
                if (!string.IsNullOrWhiteSpace(invoiceNo))
                {
                    tblInv_Info invoiceInfo = _repositoryWrapper.InvoiceInfo.GetById(invoiceNo);

                    if (invoiceInfo == null) return;

                    string invoicePaid = (invoiceInfo.Inv_Paid)? "Yes" : "No";
                    if(rblInvoicePaid.Items.FindByText(invoicePaid) != null)
                    {
                        rblInvoicePaid.Items.FindByText(invoicePaid).Selected = true;
                    }
                    txtComments.Text = invoiceInfo.Comments;
                    
                    DdlClientId.SelectedValue = invoiceInfo.Client_id;
                    
                    LoadClientInfo(invoiceInfo.Client_id);
                    
                    LoadCartGrid(invoiceNo, invoiceInfo.Client_id);
                }
            }
        }
        /// <summary>
        /// Populate clients dropdown list
        /// </summary>
        private void LoadClientsLookup()
        {
            var clients = _repositoryWrapper.ClientInfo.ListAll().OrderBy(p => p.C_name).ThenBy(p => p.C_name).Select(client => new
            {
                ID = client.Client_id,
                Name = $"{client.C_name} {client.C_surname}"
            }).ToList();
            DdlClientId.DataSource = clients;
            DdlClientId.DataTextField = "Name";
            DdlClientId.DataValueField = "ID";
            DdlClientId.DataBind();
        }
        /// <summary>
        /// Populate supplements dropdown list
        /// </summary>
        private void LoadSupplimentLookup()
        {
            var suppliments = _repositoryWrapper.Suppliment.List(where: suppliment => suppliment.Current_Stock_Levels > 0)
                .OrderBy(p => p.Supplement_Description)
                .Select(p => new
                {
                    ID = p.Supplement_id,
                    Name = $"{p.Supplement_id}  -  {p.Supplement_Description}"
                }).ToList();
            DdlSuplimentID.DataSource = suppliments;
            DdlSuplimentID.DataTextField = "Name";
            DdlSuplimentID.DataValueField = "ID";
            DdlSuplimentID.DataBind();
        }

        /// <summary>
        /// Load shopping cart grid by client ID and invoice number
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="clientId"></param>
        private void LoadCartGrid(string invoiceNo, string clientId)
        {           
            var cartItems = _repositoryWrapper.InvoiceItems.GetCartItems(invoiceNo, clientId).Select(p => new
            {
                p.Supplement_id,
                p.Supplement_Description,
                Item_Price = p.Item_Price.AddCurrency(),
                p.Item_Quantity,
                p.SubTotal,
                SubTotalText = p.SubTotal?.AddCurrency()
            }).ToList();

            grdCartItems.DataSource = cartItems;
            grdCartItems.DataBind();
            bool hasRows = grdCartItems.HasRows();
            BtnPrintInvoice.Visible = hasRows;
            BtnEmail.Visible = hasRows;

            if (cartItems.Count > 0)
            {
                heading.Visible = true;
                grdCartItems.FooterRow.Cells[4].Text = "Total";
                grdCartItems.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                grdCartItems.FooterRow.Cells[5].Font.Bold = true;
                grdCartItems.FooterRow.Cells[5].Text = cartItems.Sum(p => p.SubTotal)?.AddCurrency();
            }
        }
        /// <summary>
        /// Load client info on client drop down change
        /// </summary>
        /// <param name="clientId"></param>
        private void LoadClientInfo(string clientId)
        {
            lstClients.Items.Clear();
            if (!string.IsNullOrEmpty(clientId))
            {
                var client = _repositoryWrapper.ClientInfo.GetById(clientId);
                if (client != null)
                {
                    lstClients.Items.Add($"Name:{client.C_name}");
                    lstClients.Items.Add($"Surname:{client.C_surname}");
                    lstClients.Items.Add($"Mobile:{client.C_Tel_Cell}");
                }
            }
        }

        protected void DdlClientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClientInfo(DdlClientId.SelectedValue);
        }
        /// <summary>
        /// Clear form controls
        /// </summary>
        /// <param name="wholeForm"></param>
        private void ClearControls(bool wholeForm = false)
        {
            if(wholeForm)
            {
                DdlClientId.SelectedValue  = string.Empty;
                lstClients.Items.Clear();
            }
            //rblInvoicePaid.ClearSelection();
            DdlSuplimentID.SelectedValue = string.Empty;
            lstSuppment.Items.Clear();
            lblError.Text = txtQuantity.Text = txtComments.Text = string.Empty;
        }
        /// <summary>
        /// Load supplements info on dropdown list change
        /// </summary>
        /// <param name="supplimentID"></param>
        private void LoadSupplimentData(string supplimentID)
        {
            lstSuppment.Items.Clear();
            if (!string.IsNullOrWhiteSpace(supplimentID))
            {
                var suppliment = _repositoryWrapper.Suppliment.GetById(DdlSuplimentID.SelectedValue);
                if (suppliment != null)
                {
                    lstSuppment.Items.Add($"Price:{suppliment.Cost_incl.AddCurrency()}");
                    lstSuppment.Items.Add($"Available item(s):{suppliment.Current_Stock_Levels}");
                }
            }
        }
        
        protected void DdlSupliment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplimentData(DdlSuplimentID.SelectedValue);
        }
        /// <summary>
        /// Save Invoice details
        /// </summary>
        private void Save()
        {
            bool IsValid = !string.IsNullOrWhiteSpace(txtQuantity.Text) && !string.IsNullOrWhiteSpace(DdlSuplimentID.SelectedValue);
            if (!IsValid && !grdCartItems.HasRows())
            {
                lblError.Text = "Add atleast one item in shopping cart";
                return;
            }
            // Save Invoice info
            bool invoicePaid = bool.Parse(rblInvoicePaid.SelectedValue);
            tblInv_Info inv_Info = new tblInv_Info
            {
                Inv_Num = lblInvoiceNo.Text,
                Inv_Date = DateTime.Now,
                Inv_Paid = invoicePaid,
                Comments = txtComments.Text,
                Client_id = DdlClientId.SelectedValue
            };
            var invoiceInfo = _repositoryWrapper.InvoiceInfo.GetById(inv_Info.Inv_Num);
            if (invoiceInfo != null)
            {
                inv_Info.Inv_Date = invoiceInfo.Inv_Date;
                inv_Info.Inv_Paid_Date = invoicePaid && invoiceInfo.Inv_Paid_Date == null ? DateTime.Now : invoiceInfo.Inv_Paid_Date;
                _repositoryWrapper.InvoiceInfo.Update(inv_Info, inv_Info.Inv_Num);
            }
            else
                _repositoryWrapper.InvoiceInfo.Add(inv_Info);

            if (!IsValid)
                return;

            int quantity = int.Parse(txtQuantity.Text);
            if (quantity == 0)
            {
                lblError.Text = "The Quantiy must be greater than 0";
                return;
            }
            //Check stock
            KeyValuePair<bool, tblSupplement> supplement = IsStockAvailable(DdlSuplimentID.SelectedValue, quantity, lblInvoiceNo.Text);
            if (!supplement.Key)
            {
                lblError.Text = $"The quantity supplied:{quantity} exceeds the stock we have.Please reduce your quantity to be less than or equal to :{supplement.Value?.Current_Stock_Levels}";
                return;
            }

            //Save Invoice Items
            tblInv_items invoiceItem = new tblInv_items
            {
                Item_Price = supplement.Value.Cost_incl,
                Item_Quantity = quantity,
                Supplement_id = DdlSuplimentID.SelectedValue,
                Inv_Num = inv_Info.Inv_Num
            };
            var dbInvoiceItem = _repositoryWrapper.InvoiceItems.Get(where: item => item.Inv_Num == invoiceItem.Inv_Num && item.Supplement_id == invoiceItem.Supplement_id);
            int dbQuantity = 0;
            if (dbInvoiceItem == null)
                _repositoryWrapper.InvoiceItems.Add(invoiceItem);
            else
            {
                dbQuantity = dbInvoiceItem.Item_Quantity;
                _repositoryWrapper.InvoiceItems.Update(invoiceItem, new object[] { invoiceItem.Supplement_id, invoiceItem.Inv_Num });
            }

            UpdateStockLevels(supplement.Value.Supplement_id, -invoiceItem.Item_Quantity, dbQuantity);


            LoadCartGrid(invoiceItem.Inv_Num, inv_Info.Client_id);
            ClearControls();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// Check if the stock is still available
        /// </summary>
        /// <param name="supplimentId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private KeyValuePair<bool, tblSupplement> IsStockAvailable(string supplimentId, int quantity, string invoiceNo)
        {
            
            var supplement = _repositoryWrapper.Suppliment.GetById(supplimentId);

            var invoiceItem = _repositoryWrapper.InvoiceItems.GetById(new object[] { supplimentId, invoiceNo });

            if (invoiceItem != null && quantity <= invoiceItem.Item_Quantity)
                return new KeyValuePair<bool, tblSupplement>(true, supplement);

            return new KeyValuePair<bool, tblSupplement>((supplement?.Current_Stock_Levels ?? 0) >= quantity, supplement);
        }

        protected void grdClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCartItems.PageIndex = e.NewPageIndex;
            LoadCartGrid(lblInvoiceNo.Text, DdlClientId.SelectedValue);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void grdCartItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var suppliment = e.CommandArgument.ToString();
            var compositeKey = new object[] { suppliment, lblInvoiceNo.Text };
            if(e.CommandName == "Edit")
            {             
                var invoiceItem = _repositoryWrapper.InvoiceItems.GetById(compositeKey);
                DdlSuplimentID.SelectedValue = suppliment;
                txtQuantity.Text = invoiceItem.Item_Quantity.ToString();
                LoadSupplimentData(suppliment);
            }
            else if(e.CommandName == "Delete")
            {
                var item = _repositoryWrapper.InvoiceItems.GetById(compositeKey);
                if(item != null)
                {
                    _repositoryWrapper.InvoiceItems.Delete(item);
                    UpdateStockLevels(suppliment, item.Item_Quantity);
                }
            }
        }
        /// <summary>
        /// Update Supplement Stock levels
        /// </summary>
        /// <param name="supplimentId"></param>
        /// <param name="quantity"></param>
        private void UpdateStockLevels(string supplimentId, int quantity, int revertValue = 0)
        {
            var suppliment = _repositoryWrapper.Suppliment.GetById(supplimentId);
            if(suppliment != null && suppliment.Current_Stock_Levels > 0)
            {
                suppliment.Current_Stock_Levels = suppliment.Current_Stock_Levels + revertValue  + (quantity);
                _repositoryWrapper.Suppliment.Update(suppliment, supplimentId);
            }
        }

        protected void grdCartItems_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCartItems.EditIndex = e.NewEditIndex;
            
            LoadCartGrid(lblInvoiceNo.Text, DdlClientId.SelectedValue);                   
        }

        protected void grdCartItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))
                {
                    for (int i = 0; i < e.Row.Cells.Count - 1; i++)
                    {
                        if (e.Row.Cells[i].HasControls())
                        {
                            ((TextBox)e.Row.Cells[i].Controls[0]).ReadOnly = true;
                            ((TextBox)e.Row.Cells[i].Controls[0]).BorderStyle = BorderStyle.None;
                        }                        
                    }
                }
            }                       
        }

        protected void grdCartItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LoadCartGrid(lblInvoiceNo.Text, DdlClientId.SelectedValue);
        }

        protected void BtnPrintInvoice_Click(object sender, EventArgs e)
        {
            Save();
            Response.DownloadFile(DocumentHelper.GenerateInvoice(lblInvoiceNo.Text, _repositoryWrapper, Server.MapPath("~/App_Data/")));           
        }

        protected void BtnEmail_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Save();
            CustomLinqExtensions.SendEmail(lblInvoiceNo.Text, Server.MapPath("~/App_Data/"), _repositoryWrapper, _emailSender);
            lblError.ForeColor = Color.Green;
            lblError.Text = $"Email has been sent successfully for {lblInvoiceNo.Text}";
        }
    }
}