<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnpaidInvoices.aspx.cs" Inherits="AltHealth.App.Reports.UnpaidInvoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Unpaid Invoices</h2>
    <br />
      <div class="row">
        <div class="col-md-12">
             <asp:GridView ID="grdUnpaidInvoices" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnPageIndexChanging="grdUnpaidInvoices_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Client_id" HeaderText="CLIENT ID" />
                     <asp:BoundField DataField="Name" HeaderText="CLIENT" />
                     <asp:BoundField DataField="Inv_Num" HeaderText="INVOICE NUMBER" />
                     <asp:BoundField DataField="InvoiceDate" HeaderText="INVOICE DATE" />
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Unpaid Invoices found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
