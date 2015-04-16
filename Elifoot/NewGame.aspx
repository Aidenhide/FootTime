<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="Elifoot.NewGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" id="div_page" runat="server">
        <h3>Criar Novo Jogo</h3>
        <hr />
        <div class="row">
            <asp:Label Text="Número de Jogadores:" runat="server" />
            <asp:DropDownList ID="ddlplayers" runat="server" OnSelectedIndexChanged="ddlplayers_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="1 Jogador" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="2 Jogador" Value="2"></asp:ListItem>
                <asp:ListItem Text="3 Jogador" Value="3"></asp:ListItem>
                <asp:ListItem Text="4 Jogador" Value="4"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-3" id="div_p1" runat="server">
                <span>Jogador 1:</span>
                <asp:TextBox ID="tb_player1" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" id="div_p2" runat="server" visible="false">
                <span>Jogador 2:</span>
                <asp:TextBox ID="tb_player2" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" id="div_p3" runat="server" visible="false">
                <span>Jogador 3:</span>
                <asp:TextBox ID="tb_player3" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3" id="div_p4" runat="server" visible="false">
                <span>Jogador 4:</span>
                <asp:TextBox ID="tb_player4" runat="server"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <asp:Button ID="b_begin" runat="server" Text="Começar Jogo" OnClick="b_begin_Click" />
            <asp:Label ID="l_error" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </div>

</asp:Content>
