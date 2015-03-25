<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Elifoot._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row container">
        <asp:Label ID="l_team" runat="server" Text="Nome da Equipa:"></asp:Label>
        <asp:TextBox ID="tb_team" runat="server"></asp:TextBox>
        <asp:Button ID="b_team" runat="server" Text="Criar" OnClick="b_team_Click" />
    </div>
    <div class="row">
        <asp:Button ID="b_generateTeams" runat="server" Text="Criar Equipas Aleatórias" OnClick="b_generateTeams_Click" />
    </div>
    <div class="row">
        <asp:ListView ID="lv_teams" runat="server" OnItemDataBound="lv_teams_ItemDataBound">
            <ItemTemplate>
                <h4>Equipa: <%# Eval("Name") %></h4>
                <asp:Repeater ID="playerRepeater" runat="server">
                    <HeaderTemplate>
                         <div class="row">
                            <div class="col-12-md">
                                <table>
                                    <tr>
                                        <th>Nome Jogador</th>
                                        <th>Salario</th>
                                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Salary") %></td>
                                </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:ListView>
    </div>


    <div class="row">
        <asp:Button ID="b_simulate" runat="server" Text="Simular" OnClick="b_simulate_Click" />
    </div>
</asp:Content>
