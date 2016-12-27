<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WNG_eDash_Board._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WNG Assmbly Dash Board</h1>
        <p class="lead">Product:</p>
        <p class="lead">Cum%</p>
        <p class="Lead">Target:</p>
        <p class="Lead">Time Lapses:</p>
        <p class="lead">
            <asp:Timer ID="Timer1" runat="server">
            </asp:Timer>
        </p>
    </div>

</asp:Content>
