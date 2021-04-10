<%@ Page Title="Purchase Stats" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseStats.aspx.cs" Inherits="AltHealth.App.Reports.PurchaseStats" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Purchase Statistics</h2>
        <br />
    <div class="row">
        <div class="col-md-12 offset-md-11">
            <div class="form-group">
                <label>Select Start Year</label>
                <asp:DropDownList ID="DdlYears" CssClass="form-control" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="DdlYears_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Chart ID="ChrtStats" runat="server" Width="1127px" Height="373px" style="margin-top: 0px" BorderlineColor="LightSteelBlue" BorderlineDashStyle="Solid" BackColor="192, 255, 192" BackGradientStyle="DiagonalLeft" BackImageTransparentColor="White" BackSecondaryColor="Aqua" Palette="EarthTones">
                <Series>
                    <asp:Series ChartType="Line" Name="Purchases" ChartArea="ChartArea1" XValueMember="Month" YValueMembers="NumberOfPurchases" IsXValueIndexed="True" IsValueShownAsLabel="True" LabelBackColor="Silver" LabelBorderWidth="2" Legend="Legend" MarkerBorderWidth="2" MarkerColor="Lime" MarkerStyle="Circle" YValueType="Int32">
                        </asp:Series>
                </Series>
                <chartareas>
                        <asp:ChartArea Name="ChartArea1" BackColor="PeachPuff" BackGradientStyle="VerticalCenter" BackImageTransparentColor="224, 224, 224" BackSecondaryColor="192, 255, 255" BorderColor="Maroon" BorderDashStyle="Solid" IsSameFontSizeForAllAxes="True">
                            <AxisY Interval="10" IntervalAutoMode="VariableCount" Maximum="150" Minimum="10" Title="Number of Purchases" TitleFont="Microsoft Sans Serif, 12pt" TitleForeColor="DarkSlateGray">
                            </AxisY>
                            <AxisX Interval="1" Maximum="12" Minimum="1" Title="Months" TitleFont="Microsoft Sans Serif, 12pt" TitleForeColor="DarkSlateGray">
                            </AxisX>
                            <Area3DStyle LightStyle="Realistic" />
                        </asp:ChartArea>
                    </chartareas>
                 <Legends>
                        <asp:Legend BackColor="192, 255, 192" BackGradientStyle="DiagonalLeft" Name="Legend" Title="Legend">
                        </asp:Legend>
                    </Legends>
                <Titles>
                        <asp:Title BackColor="Moccasin"  BackGradientStyle="LeftRight" BackImageAlignment="Center" BackSecondaryColor="Aqua" Font="Verdana, 14.25pt, style=Bold" Name="Number of Purchases" Text="">
                        </asp:Title>
                    </Titles>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
