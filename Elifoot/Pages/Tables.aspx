<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="Elifoot.Pages.Tables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container">

        <asp:Repeater ID="repLeagues" runat="server">
            <HeaderTemplate>
                <strong>
                    <asp:Label ID="l_leagueName" runat="server" Text='<%# Eval("Name") %>' />
                </strong>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Repeater ID="repTeams" runat="server">
                    <ItemTemplate>

                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>

        </asp:Repeater>
</asp:Content>
