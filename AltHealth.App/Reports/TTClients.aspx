<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TTClients.aspx.cs" Inherits="AltHealth.App.Reports.TTClients" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2>Top 10 Clients</h2>
    <br />
      <div class="row">
        <div class="col-md-12">
          <asp:Chart ID="chtTopClients" Width="1179px" Height="395px" runat="server" BackColor="PowderBlue" BackGradientStyle="LeftRight" BackSecondaryColor="192, 255, 192" BorderlineColor="OliveDrab" BorderlineDashStyle="Solid">
              <Series>
                  <asp:Series ChartType="Bar" Name="Series1" XValueMember="Name" YValueMembers="Frequency"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea BackColor="128, 128, 255" BackGradientStyle="LeftRight" BackImageTransparentColor="192, 64, 0" Name="ChartArea1">
                      <AxisY Interval="2" Maximum="22" Minimum="2" Title="Frequency" TitleFont="Microsoft Sans Serif, 12pt"></AxisY>
                      <AxisX Interval="1" Maximum="11" Minimum="0" Title="Clients" TitleFont="Microsoft Sans Serif, 12pt"></AxisX>
                  </asp:ChartArea>
              </ChartAreas>
              <Titles>
                <asp:Title BackColor="Aqua" BackGradientStyle="LeftRight" BackSecondaryColor="128, 255, 128" Font="Microsoft Sans Serif, 14.25pt, style=Bold" Name="Title1" Text="Top 10 Clients"></asp:Title>
               </Titles>
          </asp:Chart>
        </div>
          
    </div>
</asp:Content>
