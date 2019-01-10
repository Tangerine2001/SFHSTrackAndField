<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SFHSTrackAndField.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="jumbotron" id="registerPage" runat="server">
    <div class="text-center"><h1>Login</h1></div> 
    <p class="lead">*Email: <asp:RequiredFieldValidator ID="requireEmail" runat="server" controltovalidate="email" ErrorMessage="Required field" /></p>
    <p><asp:TextBox ID="email" runat="server"></asp:TextBox><asp:Label ID="invalidEmail" runat="server"></asp:Label></p>
    <p class="lead">*Password: <asp:RequiredFieldValidator ID="requirePassword" runat="server" controltovalidate="password" ErrorMessage="Required field" /></p>
    <p><asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></p>  
    <br />  
        <p><asp:Button ID="loginButton" runat ="server" OnClick="loginButton_Click" Text="Login!"/></p> 
    </div>
</asp:Content>

