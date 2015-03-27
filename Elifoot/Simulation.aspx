<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" Inherits="Elifoot.Simulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container">
        <h3 class="row text-center">
            <asp:Label ID="l_journey" runat="server"></asp:Label>
        </h3>
        <asp:Repeater ID="leagueRepeater" runat="server" OnItemDataBound="leagueRepeater_ItemDataBound">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="l_leagueName" runat="server" Text='<%# Eval("Name") %>' />
                <div class="row league-table">
                    <asp:Repeater ID="MatchRepeater" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <asp:Label ID="l_houseLastEvent" runat="server" />
                                </div>
                                <div class="col-md-2 text-right team-field">
                                    <asp:Label ID="l_house" runat="server" Text='<%# Eval("HouseName") %>' />
                                </div>
                                <div class="col-md-1 text-right score-field">
                                    <asp:Label ID="l_houseScore" runat="server" Text='<%# Eval("HouseScore") %>' />
                                </div>
                                <div class="col-md-1 score-field">
                                    <asp:Label ID="l_visitoScore" runat="server" Text='<%# Eval("VisitorScore") %>' />
                                </div>
                                <div class="col-md-2 team-field">
                                    <asp:Label ID="l_visitor" runat="server" Text='<%# Eval("VisitorName") %>' />
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="l_visitorLastEvent" runat="server" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>

</asp:Content>
