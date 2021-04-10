<%@ Page Title="Manage Suppliments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSupliments.aspx.cs" Inherits="AltHealth.App.Forms.Suppliments.ManageSupliments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Manage Supplements</h2>
        </div>
        <div class="panel-body">
                <div class="row">
        <div class="col-md-4">
            <asp:HiddenField ID="hdnIsUpdate" runat="server" />
            <label class="required">Supplement ID:</label>
            <asp:TextBox ID="txtSupplementIDS" runat="server" CssClass="form-control" placeholder="Enter supplement ID" AutoCompleteType="Disabled" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter supplement ID'"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="text-danger" ControlToValidate="txtSupplementIDS" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label class="required">Supplier</label>
            <asp:DropDownList ID="DdlSupplierID" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="">Please select</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvSupplierID" runat="server" ControlToValidate="DdlSupplierID" ErrorMessage="*Required" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" AutoCompleteType="Disabled" placeholder="Enter supplement description"  onfocus="this.placeholder = ''"   onblur="this.placeholder = 'Enter supplement description'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" CssClass="text-danger" ControlToValidate="txtDescription" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label>Nappi Code</label>
            <asp:TextBox ID="txtNappiCode" runat="server" CssClass="form-control" placeholder="Enter nappi code"  onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter nappi code'"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Cost(Excl):</label>
            <asp:TextBox ID="txtCostE" runat="server" CssClass="form-control" AutoPostBack="True" AutoCompleteType="Disabled" OnTextChanged="txtCostE_TextChanged" TextMode="Number" placeholder="Enter supplement cost"  onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter supplement cost'"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="text-danger" ControlToValidate="txtCostE" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCostE" Display="Dynamic" ErrorMessage="*Invalid Cost" ForeColor="Red" ValidationExpression="(?=.*?\d)^\$?(([1-9]\d{0,2}(,\d{3})*)|\d+)?(\.\d{1,2})?$"></asp:RegularExpressionValidator>
        </div>
         <div class="col-md-4">
            <label>Cost(Incl):</label>
            <asp:TextBox ID="txtCostI" runat="server" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ControlToValidate="txtCostI" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Current Stock:</label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" placeholder="Enter current stock number"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter current stock number'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ControlToValidate="txtStock" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStock" Display="Dynamic" ErrorMessage="*Invalid Stock" ForeColor="Red" ValidationExpression="^[0-9]{1,6}$"></asp:RegularExpressionValidator>
        </div>
        <div class="col-md-4">
            <label class="required">Min Level:</label>
            <asp:TextBox ID="txtMinLevel" runat="server" AutoCompleteType="Disabled" CssClass="form-control" placeholder="Enter min level number"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter min level number'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="text-danger" ControlToValidate="txtMinLevel" ErrorMessage=" *Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMinLevel" Display="Dynamic" ErrorMessage="*Invalid Stock Level" ForeColor="Red" ValidationExpression="^[0-9]{1,6}$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
           <a href="~/Forms/Suppliments/ViewSuppliments.aspx" runat="server" class="btn btn-default">Cancel</a>
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
    <br />

</asp:Content>
