<%@ Page Title="Stock Levels" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockLevel.aspx.cs" Inherits="AltHealth.App.Reports.StockLevel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Supplements below stock level</h2>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="grdStockLevels" runat="server" AutoGenerateColumns="false"  CssClass="table table-striped table-bordered" OnPageIndexChanging="grdStockLevels_PageIndexChanging" OnRowDataBound="grdStockLevels_RowDataBound" AllowPaging="True"
                 PageSize="10">
                 <Columns>
                     <asp:BoundField DataField="Supplement" HeaderText="SUPPLEMENT" />
                     <asp:BoundField DataField="SupplierInformation" HeaderText="SUPPLIER INFORMATION" ReadOnly="false" SortExpression="SupplierInformation"/>
                     <asp:BoundField DataField="Min_Level" HeaderText="MIN LEVELS" SortExpression="Min_Level" />
                     <asp:BoundField DataField="Current_Stock_Levels" HeaderText="CURRENT STOCK" />
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Stock Levels found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
