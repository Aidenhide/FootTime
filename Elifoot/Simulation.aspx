<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" Inherits="Elifoot.Simulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container">

        <asp:Repeater ID="leagueRepeater" runat="server" OnItemDataBound="leagueRepeater_ItemDataBound">
            <HeaderTemplate>
                <asp:Label ID="l_leagueName" runat="server" Text='<%# Eval("Name") %>' />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Repeater ID="MatchRepeater" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-5">
                                <asp:Label ID="l_house" runat="server" Text='<%# Eval("HouseName") %>'/>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="l_houseScore" runat="server" Text='<%# Eval("HouseScore") %>' />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="l_visitoScore" runat="server" Text='<%# Eval("VisitorScore") %>'/>
                            </div>
                            <div class="col-md-5">
                                <asp:Label ID="l_visitor" runat="server" Text='<%# Eval("VisitorName") %>' />
                                <span>TEMPO: <%# Eval("Time") %></span>
                            </div>
                        </div>
                    </ItemTemplate>
            </asp:Repeater>
            </ItemTemplate>

        </asp:Repeater>

    </div>

</asp:Content>
