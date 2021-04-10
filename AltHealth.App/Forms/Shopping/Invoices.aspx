<%@ Page Title="Invoies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="AltHealth.App.Forms.Shopping.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Invoices</h2>
        </div>
        <div class="panel-body">
             <div class="row">
                  <div class="col-md-12">
                      <div class="col-md-3">
                          <asp:TextBox ID="txtSearch" runat="server" ForeColor="" CssClass="form-control" AutoCompleteType="Disabled"
                            type="text"
                            placeholder="Search"
                            onfocus="this.placeholder = ''"
                            onblur="this.placeholder = 'Search...'"></asp:TextBox>
                      </div>
                      <div class="col-md-2">
                          <asp:Button ID="BtnSearch" causesvalidation="false" CssClass="btn btn-secondary" runat="server" OnClick="BtnSearch_Click" Text="Search" />
                      </div>
                      <div class="col-md-7">
                          <div class="text-right">                      
                            <a href="Cart.aspx" class="btn btn-primary">Shop Items</a>
                          </div>
                      </div>
                  </div>    
            </div>
        <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblEmail" runat="server" ForeColor="Green"></asp:Label>
                    <asp:GridView ID="grdInvoices" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" AllowPaging="true" PageSize="10" OnRowEditing="grdInvoices_RowEditing" OnRowCommand="grdInvoices_RowCommand" OnRowDataBound="grdInvoices_RowDataBound" OnPageIndexChanging="grdInvoices_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Inv_Num" HeaderText="Invoice Number" />
                            <asp:BoundField DataField="Inv_Date" HeaderText="Invoice Date" />
                            <asp:BoundField DataField="Inv_Paid" HeaderText="Invoice Paid"/>
                            <asp:BoundField DataField="Name" HeaderText="Client" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button Text="Edit" CssClass="btn btn-primary" runat="server" CommandName="Edit" CommandArgument='<%#Eval("Inv_Num").ToString() %>' />
                                    <asp:Button Text="Print" CssClass="btn btn-primary" runat="server" CommandName="Print" CommandArgument='<%#Eval("Inv_Num").ToString() %>' />
                                    <asp:Button Text="Email" CssClass="btn btn-primary" runat="server" CommandName="Email" CommandArgument='<%#Eval("Inv_Num").ToString() %>' />                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div>No Invoices found</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
