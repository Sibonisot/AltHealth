<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="AltHealth.App.Forms.Shopping.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Cart</h2>
        </div>
        <div class="panel-body">
                <div class="row">
        <div class="col-md-2">
            <label>Invoice No:</label>
        </div>
        <div class="col-md-1">
            <asp:Label ID="lblInvoiceNo" runat="server" CssClass="font-weight-bold"></asp:Label>
            <asp:HiddenField ID="hdnIsUpdate" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Client:</label>
            <asp:DropDownList ID="DdlClientId" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DdlClientId_SelectedIndexChanged">
                <asp:ListItem Value="">Please select</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvClientID" runat="server" ControlToValidate="DdlClientId" CssClass="text-danger" ErrorMessage="*Required"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-8">
            <label>Client Details</label>
            <asp:ListBox ID="lstClients" runat="server" Enabled="false" CssClass="form-control"></asp:ListBox>
        </div>
    </div>
     <div class="row">
         <div class="col-md-4">             
            <label class="required">Invoice Paid?</label>  
             <asp:RadioButtonList ID="rblInvoicePaid" runat="server" CssClass="custom-radio" RepeatDirection="Horizontal">
                <asp:ListItem Value="true">Yes</asp:ListItem>  
                <asp:ListItem Value="false">No</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ControlToValidate="rblInvoicePaid" ErrorMessage="*Required"></asp:RequiredFieldValidator>
         </div>
         <div class="col-md-6">
            <label>Comments</label>
            <asp:TextBox ID="txtComments" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine" MaxLength="255"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvComments" ControlToValidate="txtComments" runat="server" CssClass="text-danger"  ErrorMessage="*Required"></asp:RequiredFieldValidator>--%>
        </div>
    </div>
  <%--  <div class="row">
        <div class="col-md-4">
            <label>Invoice Date:</label>
            <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control" TextMode="DateTime" MaxLength="10" placeholder="Select invoice date" onfocus="this.placeholder = ''"   onblur="this.placeholder = 'Select invoice date'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtInvoiceDate" CssClass="text-danger" ErrorMessage="*Required"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label>Date Paid</label>
            <asp:TextBox ID="txtDatePaid" runat="server" CssClass="form-control" placeholder="Select paid date"  onfocus="this.placeholder = ''"  onblur="this.placeholder = 'Select paid date'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDatePaid" CssClass="text-danger" ErrorMessage="*Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtInvoiceDate" CssClass="text-danger" ControlToValidate="txtDatePaid" ErrorMessage="*Incorrect Date" Operator="GreaterThanEqual" Display="Dynamic"></asp:CompareValidator>
        </div>
    </div>--%>
   
    <div class="row">
        <div class="col-md-4">
            <label>Supplement:</label>
            <asp:DropDownList ID="DdlSuplimentID" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DdlSupliment_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="">Please select</asp:ListItem>
            </asp:DropDownList>
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="*Required" ControlToValidate="DdlSuplimentID"></asp:RequiredFieldValidator>--%>
        </div>
        <div class="col-md-8">
             <label>Item Price:</label>
            <asp:ListBox ID="lstSuppment" runat="server" Enabled="false" CssClass="form-control"></asp:ListBox>  
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter item quantity" AutoCompleteType="Disabled"  onfocus="this.placeholder = ''"  onblur="this.placeholder = 'Enter item quantity'" MaxLength="4" TextMode="Number"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger"  ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="*Number Only" ValidationExpression="^-?[0-9,\.]+$"></asp:RegularExpressionValidator>
             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtQuantity" ErrorMessage="*Required"></asp:RequiredFieldValidator>--%>
        </div>
        
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnSave" runat="server" CausesValidation="true" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnClear" runat="server" CausesValidation="false" CssClass="btn btn-secondary" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="BtnPrintInvoice" runat="server" Visible="false" CausesValidation="false" CssClass="btn btn-primary" Text="Print Invoice" OnClick="BtnPrintInvoice_Click" />
            <asp:Button ID="BtnEmail" runat="server" Visible ="false" CausesValidation="false" CssClass="btn btn-primary" Text="Email Invoice" OnClick="BtnEmail_Click" />
            <a href="Invoices.aspx" runat="server" class="btn btn-default">Invoices</a>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>
    <div class="row">        
         <div class="col-md-12">
             <div id="heading" runat="server" visible="false">                 
             <h4>Cart Items</h4>
             </div>
             <asp:GridView ID="grdCartItems" runat="server" CssClass="table table-striped table-bordered" OnRowEditing="grdCartItems_RowEditing" OnRowDataBound="grdCartItems_RowDataBound"  AutoGenerateColumns="false" OnRowDeleting="grdCartItems_RowDeleting" OnPageIndexChanging="grdClients_PageIndexChanging" AllowPaging="True" OnRowCommand="grdCartItems_RowCommand"
                 PageSize="5" ShowFooter="true">
                 <Columns>
                     <asp:BoundField DataField="Supplement_id" HeaderText="Suppliment ID" Visible="False" />
                     <asp:BoundField DataField="Supplement_Description" HeaderText="Supplement Description"/>
                     <asp:BoundField DataField="Item_Price" HeaderText="Price" />
                     <asp:BoundField DataField="Item_Quantity" HeaderText="Quantity" />
                     <asp:BoundField DataField="SubTotalText" HeaderText="Sub Total" />
                     <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:Button Text="Edit" runat="server" CausesValidation="false" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%#Eval("Supplement_id").ToString() %>' />
                             <asp:Button Text="Remove" runat="server" CausesValidation="false" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%#Eval("Supplement_id").ToString() %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                <EmptyDataTemplate>
                    <div>No Cart items found</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
        </div>
    </div>

</asp:Content>
