<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Logowanie.aspx.cs" Inherits="stronka.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table>
        <tr>
        <th><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Login"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"></asp:TextBox></th>    
        </tr>
        <tr>
        <th>
        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Hasło"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"></asp:TextBox>
       </th>
        </tr>
    </table>
    <asp:Button ID="Button5" runat="server" CssClass="btn" OnClick="Button5_Click" Text="Zaloguj" />
    <asp:Button ID="Button6" runat="server" CssClass="btn" OnClick="Button6_Click" Text="Wyloguj" />

    <br />
    <asp:Label ID="Label3" runat="server"></asp:Label>
        <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
    </asp:Panel>

</asp:Content>
