<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Elifoot.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container">
        <div class="col-md-3">
        </div>
        <div class="col-md-9">
            <div class="row"></div>
            <div class="row">

                <%-- TEAM VIEWER --%>
                <div class="col-md-12">
                    <asp:Repeater ID="repeaterTeam" runat="server">
                        <HeaderTemplate>
                            <div class="row">
                                <div class="col-12-md">
                                    <table class="homeTable">
                                        <tr class="text-center">
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
                                <td><%# DataBinder.Eval(Container.DataItem, "Position") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Age") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Nationality") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Injured") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Stamina") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Strength") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Technick") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "Experience") %></td>
                                <td class="tdSmall"><%# DataBinder.Eval(Container.DataItem, "OverallPower") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Salary") %></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "MarketValue") %></td>
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
