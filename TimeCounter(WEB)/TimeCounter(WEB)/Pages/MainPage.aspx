<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="MainPage.aspx.cs" Inherits="TimeCounter_WEB_.Pages.MainPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Label ID="Label1" runat="server" Text="Welcome!"></asp:Label>
        <div style="background-image:url('../Images/boy-on-computer.jpg');    
                height: 386px;
                background-repeat: no-repeat;
                background-color: #202222;
                width: 619px;">
            <%--<a href="~/Pages/SignIn.aspx" runat="server">Click here to sign in</a>--%>
        </div>
    </center>
</asp:Content>
   