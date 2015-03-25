<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Elifoot.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row container-fuild">
        
        <%-- CLUB RELATED --%>
        <div class="col-md-3 club-panel">
            <div class="row">
                <span>Clube:</span>
                <asp:Label ID="l_teamName" runat="server" />
            </div>
            <div class="row">
                <span>Posição:</span>
                <asp:Label ID="l_position" runat="server" />
            </div>
            <div class="row">
                <span>Dinheiro:</span>
                <asp:Label ID="l_money" runat="server" />
            </div>
        </div>
        <%-- GAME RELATED --%>
        <div class="col-md-4 col-md-offset-1 game-panel">
            <div class="row">
                <span>Próximo Adversário:</span>
                <asp:Label ID="l_opponent" runat="server" />
            </div>
            <div class="row">
                <span>Posição Adversária:</span>
                <asp:Label ID="l_oppPosition" runat="server" />
            </div>
            <div class="row">
                <span>Histórico:</span>
                <asp:Label ID="l_history" runat="server" />
            </div>
        </div>
        <%-- MANAGER RELATED --%>
        <div class="col-md-3 col-md-offset-1 manager-panel">
            <div class="row">
                <span>Nome:</span>
                <asp:Label ID="l_managerName" runat="server" />
            </div>
            <div class="row">
                <span>Aprovação do Clube:</span>
                <asp:Label ID="l_clubAproval" runat="server" />
            </div>
            <div class="row">
                <span>Aprovação dos Adeptos:</span>
                <asp:Label ID="l_fanAproval" runat="server" />
            </div>
        </div>
    </div>
    <div class="row container">
        <div class="col-md-2 side-menu">
            <div class="row menu-option">
                <asp:LinkButton Text="Táctica" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Treinos" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Calendário" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Classificação" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Mercado" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Estádio" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Finanças" runat="server" CssClass="menu-lk"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Notícias" runat="server" CssClass="menu-lk"/>
            </div>
        </div>
        <div class="col-md-10">
            <div class="row">

                <%-- TEAM VIEWER --%>
                <div class="col-md-12">
                    <asp:Repeater ID="repeaterTeam" runat="server">
                        <HeaderTemplate>
                            <div class="row">
                                <div class="col-12-md">
                                    <table class="home-table">
                                        <tr>
                                            <th>Posição</th>
                                            <th>Nome</th>
                                            <th>Idade</th>
                                            <th>País</th>
                                            <th>Lesão</th>
                                            <th>RES</th>
                                            <th>FOR</th>
                                            <th>TEC</th>
                                            <th>EXP</th>
                                            <th>Total</th>
                                            <th>Salário</th>
                                            <th>Valor</th>
                                        </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="td-big"><%# DataBinder.Eval(Container.DataItem, "Position") %></td>
                                <td class="td-big"><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Age") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Nationality") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Injured") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Stamina") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Strength") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Technick") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Experience") %></td>
                                <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "OverallPower") %></td>
                                <td class="td-medium"><%# DataBinder.Eval(Container.DataItem, "Salary") %></td>
                                <td class="td-medium"><%# DataBinder.Eval(Container.DataItem, "MarketValue") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                            </div>
                        </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row"></div>
        </div>
    </div>
</asp:Content>
