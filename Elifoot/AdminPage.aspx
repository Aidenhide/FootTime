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


    <div class="row">
        <div class="col-lg-12">
            <table class="global-stats-table">
                <tr>
                    <td><span>Ligas</span></td>
                    <td>
                        <asp:Label ID="l_lcount" runat="server" /></td>
                </tr>
                <tr>
                    <td><span>Jornadas</span></td>
                    <td>
                        <asp:Label ID="l_jcount" runat="server" /></td>
                </tr>
                <tr>
                    <td><span>Jogos</span></td>
                    <td>
                        <asp:Label ID="l_mcount" runat="server" /></td>
                </tr>
                <tr>
                    <td><span>Equipas</span></td>
                    <td>
                        <asp:Label ID="l_tcount" runat="server" /></td>
                </tr>
                <tr>
                    <td><span>Jogadores</span></td>
                    <td>
                        <asp:Label ID="l_pcount" runat="server" /></td>
                </tr>
            </table>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h4>Ligas</h4>
            <asp:Repeater ID="repeaterLeagues" runat="server">
                <HeaderTemplate>
                    <table class="stats-table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-6">
            <h4>Jornadas</h4>
            <asp:Repeater ID="repeaterJourneys" runat="server">
                <HeaderTemplate>
                    <table class="stats-table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h4>Jogos</h4>
            <asp:Repeater ID="repeaterMatches" runat="server">
                <HeaderTemplate>
                    <table class="stats-table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("HouseName") %></td>
                        <td>VS</td>
                        <td><%# Eval("VisitorName") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="col-md-6">
            <h4>Equipas</h4>
            <asp:Repeater ID="repeaterTeams" runat="server">
                <HeaderTemplate>
                    <table class="stats-table">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h4>Jogadores</h4>
            <asp:Repeater ID="repeaterPlayers" runat="server">
                <HeaderTemplate>
                    <table class="stats-table">
                        <tr>
                            <th class="text-center">Nome</th>
                            <th class="text-center">Posição</th>
                            <th class="text-center">Idade</th>
                            <th class="text-center">Nacionalidade</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Position") %></td>
                        <td><%# Eval("Age") %></td>
                        <td><%# Eval("Nationality") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
