<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SFHSTrackAndField.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="jumbotron" id="studentOrTeacher" runat="server">
    <asp:Button ID="student" runat="server" Text="Register as Student" class ="btn btn-primary btn-lg" OnClick="student_Click"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="teacher" runat="server" Text="Register as Teacher" class ="btn btn-primary btn-lg" OnClick="teacher_Click"/>
</div>
<div class="jumbotron" id="registerPage" runat="server">
        <h1>Register</h1>
        <p class="lead">Email: <asp:Label ID="emailCheckLabel" runat="server" ForeColor ="Red"></asp:Label></p>
        <p><asp:TextBox ID="email" runat="server" OnTextChanged="email_TextChanged"></asp:TextBox><asp:RequiredFieldValidator ID="requireEmail" runat="server" controltovalidate="email" ErrorMessage =" Email cannot be blank" ForeColor ="Red"/></p>
        <p class="lead">Password:</p>
        <p><asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="passwordContains" runat="server" controltovalidate="password" ErrorMessage=" Password must contain a number, symbol, or capital letter. " validationexpression =".*[!@#$%^&*`~A-Z0-9].*" ForeColor ="Red"/><asp:RegularExpressionValidator ID="passwordLength" runat="server" controltovalidate="password" ErrorMessage="Password must be between 4-20 characters." validationexpression ="[^\s]{4,20}" ForeColor ="Red" /></p>
        <p class="lead">First Name:</p>
        <p><asp:TextBox ID="firstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="requireFName" runat="server" Display ="Dynamic" controltovalidate="firstName" ErrorMessage=" First name is required" ForeColor ="Red" /></p>
        <p class="lead">Last Name:</p>
        <p><asp:TextBox ID="lastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="requireLName" runat="server" Display ="Dynamic" controltovalidate="lastName" ErrorMessage=" Last name is required" ForeColor ="Red" /></p>
        <br />
        <p><asp:Button ID="registerButton" runat ="server" OnClick="registerButton_Click" Text="Register!"/></p>
    </div>
    <div class="jumbotron" id="verifyCodePage" runat ="server">
        <h3 id ="verifyCodeText" runat ="server">An email has been sent to the email address. Input the 6-digit code here to verify your account: </h3>
        <p class="lead">Code:</p>
        <p><asp:TextBox ID="codeBox" runat="server"></asp:TextBox></p>
        <br />
        <p><asp:Button runat="server" Text ="Verify!" id ="verifyBox" OnClick="verifyBox_Click"/></p>
    </div>
</asp:Content>

