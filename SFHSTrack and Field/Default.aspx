<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SFHSTrackAndField._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="jumbotron">
            <img style="margin:0px auto;display:block" src="Images/SFHSLogo.png" />
            <div class ="text-center"><h1>SFHS Track and Field</h1>
                <p class="lead">Welcome to the homepage of the War Eagles Track and Field Team</p>
                <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
            </div>
        </div>

    <div class="row">
        <div class="col-md-4">
            <div class="jumbotron">
                <h2>Upcoming Meets</h2>
                <p>
                    View any upcoming meet here.
                </p>
                <p>
                    <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class ="jumbotron">
                <h2>Past Meets</h2>
                <p>
                    View any past meets here
                </p>
                <p>
                    <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="jumbotron">
                <h2>Donate</h2>
                <p>
                    Click here to donate to the SFHS track team.
                </p>
                <p>
                    <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
