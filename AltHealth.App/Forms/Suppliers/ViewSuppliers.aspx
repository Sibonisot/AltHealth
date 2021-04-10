<%@ Page Title="View Suppliers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="AltHealth.App.Forms.Suppliers.ViewSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Suppliers</h2>
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
                  <a href="ManageSuppliers.aspx" class="btn btn-primary">New</a>
                  </div>
              </div>
          </div>    
    </div>
    <br/>
    <div class="row">
        <div class="col-md-12">
             <asp:GridView ID="grdSuppliers" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnRowEditing="grdSuppliers_RowEditing" OnRowCommand="grdSuppliers_RowCommand" OnRowDataBound="grdSuppliers_RowDataBound" OnPageIndexChanging="grdSuppliers_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Supplier_Id" HeaderText="Supplier ID" />
                     <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" />
                     <asp:BoundField DataField="Supplier_Tel" HeaderText="Supplier Telephone" />
                     <asp:BoundField DataField="Supplier_Email" HeaderText="Supplier Email" />
                     <asp:BoundField DataField="Bank" HeaderText="Bank" />
                     <asp:BoundField DataField="Bank_Code" HeaderText="Bank Code" />
                     <asp:BoundField DataField="Supplier_BankNum" HeaderText="Account Number" />
                     <asp:BoundField DataField="Supplier_Type_Bank_Annount" HeaderText="Account Type" />
                      <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:Button Text="Edit" runat="server" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%#Eval("Supplier_Id").ToString() %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Suppliers found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
        </div>
    </div>
</asp:Content>
