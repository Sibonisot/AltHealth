<%@ Page Title="Manage Suppliers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSuppliers.aspx.cs" Inherits="AltHealth.App.Forms.Suppliers.ManageSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Manage Supplier</h2>
        </div>
        <div class="panel-body">
                <div class="row">
        <div class="col-md-4">
            <label class="required">Supplier ID:</label>
            <asp:TextBox ID="txtSupplierIDS" runat="server" CssClass="form-control" type="text" AutoCompleteType="Disabled" placeholder="Enter supplier ID" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter supplier ID'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSupplierIDS" CssClass="text-danger" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnIsUpdate" runat="server" />
        </div>
        <div class="col-md-4">
            <label class="required">Contact Person:</label>
            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control"  placeholder="Enter name" AutoCompleteType="Disabled" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter name'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="text-danger" ControlToValidate="txtContactPerson" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Email:</label>
            <asp:TextBox ID="txtEmailS" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  placeholder="Enter supplier email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter supplier email'" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ControlToValidate="txtEmailS" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtEmailS" ErrorMessage="*Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
            <label class="required">Tel:</label>
  
            <asp:TextBox data-mask="(999)-(999)-(9999)" ID="txtSupplierTel" runat="server" AutoCompleteType="Disabled" CssClass="form-control" type="text" placeholder="(000)-(000)-(0000)"
                    onfocus="this.placeholder = ''" onblur="this.placeholder = '(000)-(000)-(0000)'"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSupplierTel" CssClass="text-danger" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSupplierTel" CssClass="txt-danger" ErrorMessage="*Invalid Number" ValidationExpression="^\(0\d{2}\)-\(\s?\d{3}\)-\(\d{4}\)$" ValidationGroup="NumericValidate" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Bank:</label>
            <asp:TextBox ID="txtBank" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  placeholder="Enter bank name" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter bank name'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBank" CssClass="text-danger" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label class="required">Bank Code:</label>
            <asp:TextBox ID="txtBankCode" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  placeholder="Enter bank code" onfocus="this.placeholder = ''"  onblur="this.placeholder = 'Enter bank code'" TextMode="Number" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="text-danger" ControlToValidate="txtBankCode" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtBankCode" CssClass="txt-danger" ErrorMessage="*Invalid Bank Code" ValidationExpression="^[0-9]{1,6}$" ValidationGroup="NumericValidate" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Account Type:</label>
            <asp:DropDownList ID="DropDownType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="">Please select</asp:ListItem>
                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                <asp:ListItem Value="Credit">Credit</asp:ListItem>
                <asp:ListItem Value="Savings">Savings</asp:ListItem>
           </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="DropDownType" CssClass="text-danger" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-4">
            <label class="required">Account Number</label>
            <asp:TextBox ID="txtBankNo" runat="server" CssClass="form-control" placeholder="Enter bank number" AutoCompleteType="Disabled" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter bank number'" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBankNo" CssClass="text-danger" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtBankNo" CssClass="txt-danger" ErrorMessage="*Invalid Account Number" ValidationExpression="^[0-9]{1,15}$" ValidationGroup="NumericValidate" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4" style="left: 0px; top: 7px; height: 37px">      
             <asp:Button ID="btnSaveS" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveS_Click"/>
            <a href="~/Forms/Suppliers/ViewSuppliers.aspx" runat="server" class="btn btn-default">Cancel</a>
        </div>
    </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
