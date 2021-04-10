<%@ Page Title="Manage Clients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageClients.aspx.cs" Inherits="AltHealth.App.Forms.Clients.ManageClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="panel-header">Manage Client</h2>
        </div>
        <div class="panel-body">
                <div class="row">
        <div class="col-md-4">
            <label class="required">Client ID:</label>
            <asp:TextBox ID="txtClientID" placeholder="Enter your ID number" AutoCompleteType="Disabled" CssClass="form-control" runat="server" MaxLength="13" OnTextChanged="txtClientID_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClientID" runat="server" CssClass="text-danger" ControlToValidate="txtClientID" ErrorMessage="*Required"></asp:RequiredFieldValidator>
            
            <%--<asp:RegularExpressionValidator ID="revClientID" Display =Dynamic runat="server" ControlToValidate="txtClientID" ErrorMessage="*Invalid ID" ValidationExpression="(?&lt;Year&gt;[0-9][0-9])(?&lt;Month&gt;([0][1-9])|([1][0-2]))(?&lt;Day&gt;([0-2][0-9])|([3][0-1]))(?&lt;Gender&gt;[0-9])(?&lt;Series&gt;[0-9]{3})(?&lt;Citizenship&gt;[0-9])(?&lt;Uniform&gt;[0-9])(?&lt;Control&gt;[0-9])"></asp:RegularExpressionValidator>--%>
        </div>
        
        <div class="col-md-4">
             <label class="required">Tel (Home):</label>
            <asp:HiddenField ID="hdnIsCreate" runat="server" />
                 <asp:TextBox data-mask="(999)-(999)-(9999)" AutoCompleteType="Disabled" CssClass="form-control" Name="txtTelH" ID="txtTelH" runat="server" OnTextChanged="txtTelH_TextChanged" ForeColor=""                  
                    type="text"
                    placeholder="(000)-(000)-(0000)"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = '(000)-(000)-(0000)'"
                    ></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelH" CssClass="text-danger" ErrorMessage="*Invalid Number" ValidationExpression="^\(0\d{2}\)-\(\s?\d{3}\)-\(\d{4}\)$" ValidationGroup="NumericValidate" Display="Dynamic"></asp:RegularExpressionValidator>
              <asp:RequiredFieldValidator ID="rfvTelHome" runat="server" ControlToValidate="txtTelH" ErrorMessage="*Required" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ForeColor=""   placeholder="Enter your name"    onfocus="this.placeholder = ''" onblur="this.placeholder = 'Enter your name'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="text-danger" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label class="required">Surname:</label>
            <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ForeColor=""
                    type="text"
                    placeholder="Enter your surname"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter your surname'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ControlToValidate="txtSurname" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Tel (Work):</label>
            <asp:TextBox  data-mask="(999)-(999)-(9999)" ID="txtTelW" AutoCompleteType="Disabled" runat="server" CssClass="form-control" ForeColor=""
                    type="text"
                    placeholder="(000)-(000)-(0000)"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = '(000)-(000)-(0000)'"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTelW" ErrorMessage="*Invalid Number"  CssClass="text-danger" ValidationExpression="^\(0\d{2}\)-\(\s?\d{3}\)-\(\d{4}\)$" ValidationGroup="NumericValidate"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvTelWork" runat="server" ControlToValidate="txtTelW" ErrorMessage="*Required" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label>Tel(Mobile):</label>
            <asp:TextBox data-mask="(999)-(999)-(9999)" ID="txtTelM" runat="server" AutoCompleteType="Disabled"  CssClass="form-control" ForeColor=""
                    type="text"
                    placeholder="(000)-(000)-(0000)"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = '(000)-(000)-(0000)'"></asp:TextBox>
             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelM" ErrorMessage=" *Required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>--%>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTelM" ErrorMessage="*Invalid Number" CssClass="text-danger" ValidationExpression="^\(0\d{2}\)-\(\s?\d{3}\)-\(\d{4}\)$" ValidationGroup="NumericValidate" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label class="required">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  ForeColor=""
                    type="text"
                    placeholder="Enter your address"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter your address'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ControlToValidate="txtAddress" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-4">
            <label>Address Code:</label>
            	<asp:TextBox ID="txtACode" runat="server" CssClass="form-control" AutoCompleteType="Disabled" ForeColor="" type="text"
                    placeholder="Enter address code"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter address code'"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtACode" ErrorMessage=" *Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtACode" Display="Dynamic" ErrorMessage="*Invalid Address Code" ForeColor="Red" ValidationExpression="^[0-9]{1,6}$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ForeColor="" AutoCompleteType="Disabled"
                    type="text"
                    placeholder="Enter your email"
                    onfocus="this.placeholder = ''"
                    onblur="this.placeholder = 'Enter your email'"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="*Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage=" *Required" CssClass="text-danger"></asp:RequiredFieldValidator>--%>
        </div>
        <div class="col-md-4">
            <label>Reference:</label>
            <asp:DropDownList ID="DropDownRefID" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="" >Please select</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownRefID" CssClass="text-danger" ErrorMessage=" *Required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br/>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Save" CausesValidation="true" />
            <a href="ViewClients.aspx" runat="server" class="btn btn-default">Cancel</a>
        </div>
    </div>
            <br/>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblIDError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>
