<%@ Page Title="View Suppliments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliments.aspx.cs" Inherits="AltHealth.App.Forms.Suppliments.ViewSuppliments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Suppliments</h2>
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
                  <a href="ManageSupliments.aspx" class="btn btn-primary">New</a>
                  </div>
              </div>
          </div>    
    </div>
            <br />
            <div class="row">
        <div class="col-md-12">
             <asp:GridView ID="grdSuppliments" runat="server"  CssClass="table table-striped table-bordered" AutoGenerateColumns="false" OnRowEditing="grdSuppliments_RowEditing" OnRowCommand="grdSuppliments_RowCommand" OnRowDataBound="grdSuppliments_RowDataBound" OnPageIndexChanging="grdSuppliments_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Supplement_id" HeaderText="Suppliment ID" />
                     <asp:BoundField DataField="Supplier_Id" HeaderText="Supplier" />
                     <asp:BoundField DataField="Supplement_Description"   HeaderText="Description" />
                     <asp:BoundField DataField="CostExclV" HeaderText="Cost(Exl VAT)" />
                     <asp:BoundField DataField="ConstIncV" HeaderText="Cost(Inc VAT)" />
                     <asp:BoundField DataField="Min_Level" HeaderText="Minimum Level" />
                     <asp:BoundField DataField="Current_Stock_Levels" HeaderText="Current Stock" />
                      <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:Button Text="Edit" runat="server" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%#Eval("Supplement_id").ToString() %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Suppliments found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
        </div>
    </div>
</asp:Content>
