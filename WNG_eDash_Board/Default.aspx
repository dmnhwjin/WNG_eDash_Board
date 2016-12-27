<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WNG_eDash_Board._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="jumbotron" >
        <h1>WNG Assmbly Dash Board</h1>
      
 <table id="mainTable">
         <tr>
             <th></th>
         </tr>
     <tr>
         <td>
        <p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase">Product:</td><td><%=strProdName%></p>
         </td>
         </tr>
         <tr>
             <td>
             <p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase"></p>
             </td>
        </tr>
     <tr>
             <td>
              <p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase">Target:</p></td><td><p><%=intTarget %></p>
           </td>
        </tr>
     <tr> <td>    <p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase"></p></td></tr>
               
       <tr > <td > <p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase; background-color: #FFFF00;">Cum%:</p></td> <td><p><%=intCum %></p</td></tr>
        <tr> <td><p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase"></p></td></tr>
        <tr> <td><p class="Lead" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: larger; font-weight: bold; font-style: italic; font-variant: small-caps; text-transform: uppercase">Time Lapses:<%=dateTimeStr %></p></td></tr>
       <tr> <td> <p class="Lead">
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" OnInit="Timer1_Init" Interval="1000">
            </asp:Timer>
        </p></td></tr>
  </table>
    </div>
   
</asp:Content>
