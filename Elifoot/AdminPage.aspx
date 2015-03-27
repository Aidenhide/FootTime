<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Elifoot.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <hr />
    <div class="row">
        <div class="col-md-3">
            <asp:Label Text="Limpa toda a base de dados:" runat="server" />
        </div>
        <div class="col-md-1">
            <asp:Button ID="b_clearDb" CssClass="btn btn-danger" runat="server" Text="Executar" OnClick="b_clearDb_Click" />
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-3">
            <asp:Label Text="Popular a base de dados:" runat="server" />
        </div>
        <div class="col-md-1">
            <asp:Button ID="b_generateTeams" CssClass="btn btn-success" runat="server" Text="Executar" OnClick="b_generateTeams_Click" />
        </div>
    </div>
    <hr />
</asp:Content>
