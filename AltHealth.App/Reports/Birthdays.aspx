<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Birthdays.aspx.cs" Inherits="AltHealth.App.Reports.Birthdays" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Today's Birthdays</h2>
    <br />
      <div class="row">
        <div class="col-md-12">
             <asp:GridView ID="grdBirthDays" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnPageIndexChanging="grdBirthDays_PageIndexChanging" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Client_id" HeaderText="CLIENT ID" />
                     <asp:BoundField DataField="Name" HeaderText="CLIENT NAME" />
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Birth Days found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
