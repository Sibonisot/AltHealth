<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientsWithNoEmails.aspx.cs" Inherits="AltHealth.App.Reports.ClientsWithNoEmails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Clients with no Emails</h2>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdClientWithEmails" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnPageIndexChanging="grdClientWithEmails_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Client_id" HeaderText="CLIENT" ReadOnly="True" SortExpression="Client_id" />
                     <asp:BoundField DataField="C_Tel_H" HeaderText="HOME TEL" SortExpression="C_Tel_H" />
                     <asp:BoundField DataField="C_Tel_W" HeaderText="WORK TEL" SortExpression="C_Tel_W" />
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Clients with no emails found found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
