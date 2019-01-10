<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forums.aspx.cs" Inherits="SFHSTrackAndField.Forums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class ="text-right"><asp:Button ID="postMessageButton" runat="server" Text="Post Message" OnClick="postMessageButton_Click" /></div>
    <br /><br />
    <div class ="jumbotron" id ="forumPostPage" runat ="server">
        <div class ="text-center">
        <h1>Forums Post</h1>
        </div>
        <h4>Subject: </h4>
        <asp:TextBox ID="subjectBox" runat="server" Height="36px" Width="423px"></asp:TextBox>
        <h4>Text: </h4>
        <asp:TextBox ID="bodyBox" runat="server" Height="129px" Width="431px" TextMode="MultiLine" />
        <br />
        <asp:Button ID="confirmPostButton" runat="server" Text="Post" Height="56px" Width="142px" OnClick="confirmPostButton_Click" />
    </div>
    <br /><br />
    <asp:Panel ID="div_post_display_panel" style="margin-top:-15px;" runat="server" ForeColor ="Gray"/>

</asp:Content>