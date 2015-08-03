<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="TimeCounter_WEB_.Pages.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <center>
    <div>

    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label ID="Label3" runat="server" Text="Sign in" Font-Bold="true" Font-Size="X-Large"
        CssClass="StrongText"></asp:Label>
        </div>

        <center>
         <table>
            <td class="td">User name:</td>

            <td>
                <asp:TextBox ID="txtUseName" runat="server"></asp:TextBox>

            </td>
        <tr>
            <td class="td">Password:</td>
            <td>
                <%--<asp:ChangePassword ID="ChangePassword1" runat="server"></asp:ChangePassword>--%>
                <asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox>

            </td>
        </tr>
             </table>
        </center>

            </div>

        <asp:Button ID="SignInBtn" runat="server" Text="Sign in" OnClick="SignInBtn_Click" />
        <p>
            <asp:Label ID="txtStatus" runat="server"></asp:Label>
        </p>
      </center>
</asp:Content>

