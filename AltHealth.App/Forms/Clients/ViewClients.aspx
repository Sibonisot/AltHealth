<%@ Page Title="View Clients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClients.aspx.cs" Inherits="AltHealth.App.Forms.Clients.ViewClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Clients</h2>
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
                            <a href="ManageClients.aspx" class="btn btn-primary">New</a>
                          </div>
                      </div>
                  </div>    
            </div>
        <br />
    <div class="row">
        <div class="col-md-12">
             <asp:GridView ID="grdClients" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnRowEditing="grdClients_RowEditing" OnRowCommand="grdClients_RowCommand" OnRowDataBound="grdClients_RowDataBound" OnPageIndexChanging="grdClients_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Client_id" HeaderText="CLIENT ID" />
                     <asp:BoundField DataField="Name" HeaderText="NAME" />
                     <asp:BoundField DataField="Address" HeaderText="ADDRESS" />
                     <asp:BoundField DataField="Code" HeaderText="CODE" />
                     <asp:BoundField DataField="C_Tel_H" HeaderText="TEL(HOME)" />
                     <asp:BoundField DataField="C_Tel_W" HeaderText="TEL(WORK)" />
                     <asp:BoundField DataField="C_Tel_Cell" HeaderText="TEL(MOBILE)" />
                     <asp:BoundField DataField="C_Email" HeaderText="EMAIL" />
                     <asp:BoundField DataField="Description" HeaderText="REFERENCE" />
                     <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:Button Text="Edit" runat="server" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%#Eval("Client_id").ToString() %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Clients found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
        </div>
    </div>

</asp:Content>
