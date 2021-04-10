using AltHealth.App.Extensions;
using AltHealth.App.Utils;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using AltHealth.EmailHelper.Interfaces;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Forms.Shopping
{
    public partial class Invoices : System.Web.UI.Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IEmailSender _emailSender;

        public Invoices(IRepositoryWrapper repositoryWrapper,
                        IEmailSender emailSender)
        {
            _repositoryWrapper = repositoryWrapper;
            _emailSender = emailSender;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadInvoiceGrid(txtSearch.Text);
            }
        }
        private void LoadInvoiceGrid(string search = null)
        {
            var invoices = _repositoryWrapper.InvoiceInfo.GetInvoices(search).Select(invoice => new
            {
                invoice.Inv_Num,
                Inv_Date = invoice.Inv_Date.ToDateFormat(),
                invoice.Name,
                Inv_Paid = invoice.Inv_Paid ? "Yes" : "No"
            }).ToList();
            grdInvoices.DataSource = invoices;
            grdInvoices.DataBind();
        }

        protected void grdInvoices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInvoices.PageIndex = e.NewPageIndex;
            LoadInvoiceGrid(txtSearch.Text);
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadInvoiceGrid(txtSearch.Text);
        }

        protected void grdInvoices_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdInvoices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblEmail.Text = string.Empty;
            string invoiceNumber = e.CommandArgument.ToString();

            if (e.CommandName == StringHelper.EditCommand)
            {
                Response.Redirect($"~/Forms/Shopping/Cart.aspx?InvoiceNumber={invoiceNumber}");
            }
            else if(e.CommandName == StringHelper.PrintCommand)
            {
                Response.DownloadFile(DocumentHelper.GenerateInvoice(invoiceNumber, _repositoryWrapper, Server.MapPath("~/App_Data/")));
            }
            else if(e.CommandName == StringHelper.EmailCommand)
            {
                CustomLinqExtensions.SendEmail(invoiceNumber, Server.MapPath("~/App_Data/"), _repositoryWrapper, _emailSender);
                lblEmail.Text = $"Email has been sent successfully for invoice:{invoiceNumber}";
            }
        }

        protected void grdInvoices_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}