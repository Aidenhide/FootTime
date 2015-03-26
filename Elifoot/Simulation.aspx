<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" Inherits="Elifoot.Simulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container">

        <asp:Repeater ID="leagueRepeater" runat="server" OnItemDataBound="leagueRepeater_ItemDataBound">
            <HeaderTemplate>
                <asp:Label ID="l_leagueName" runat="server" Text='<%# Eval("Name") %>' />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Repeater ID="MatchRepeater" runat="server" OnItemDataBound="MatchRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-5">
                                <asp:Label ID="l_home" runat="server"/>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="l_homeScore" runat="server" Text='<%# Eval("HomeScore") %>' />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="l_visitor" runat="server"/>
                            </div>
                            <div class="col-md-5">
                                <asp:Label ID="l_visitorScore" runat="server" Text='<%# Eval("VisitorScore") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
            </asp:Repeater>
            </ItemTemplate>

        </asp:Repeater>

    </div>

</asp:Content>
