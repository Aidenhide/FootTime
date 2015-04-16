<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Simulation.aspx.cs" Inherits="Elifoot.Simulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row container league-table" id="div_page" runat="server">

        <asp:UpdatePanel ID="up_panel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <h3 class="row text-center">
                    <asp:Label ID="l_journey" runat="server"></asp:Label>
                </h3>
                <h3 class="text-center">
                    <span>Tempo: </span>
                    <asp:Label ID="l_time" runat="server" />
                </h3>
                <asp:Label ID="lblTime" runat="server" />
                <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="1000" />
                <asp:Repeater ID="leagueRepeater" runat="server" OnItemDataBound="leagueRepeater_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="l_leagueName" runat="server" Text='<%# Eval("Name") %>' />
                        <div class="row league-table">
                            <asp:Repeater ID="MatchRepeater" runat="server" OnItemDataBound="MatchRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-md-3 text-right">
                                            <asp:Label ID="l_houseLastEvent" runat="server" />
                                            <img src="" id="I_house" runat="server" />
                                        </div>
                                        <div class="col-md-2 text-right team-field" 
                                            style='<%# "background-color:" + Eval("HouseBackgroundColor") + ";"%>'>
                                            <asp:Label ID="l_house" runat="server" Text='<%# Eval("HouseName") %>' 
                                                style='<%# "color:" + Eval("HouseForegroundColor") + " !important;"%>' />
                                        </div>
                                        <div class="col-md-1 text-right score-field">
                                            <asp:Label ID="l_houseScore" runat="server" Text='<%# Eval("HouseScore") %>' />
                                        </div>
                                        <div class="col-md-1 score-field">
                                            <asp:Label ID="l_visitoScore" runat="server" Text='<%# Eval("VisitorScore") %>' />
                                        </div>
                                        <div class="col-md-2 team-field"
                                            style='<%# "background-color:" + Eval("VisitorBackgroundColor") + ";"%>'>
                                            <asp:Label ID="l_visitor" runat="server" Text='<%# Eval("VisitorName") %>'
                                                style='<%# "color:" + Eval("VisitorForegroundColor") + " !important;"%>' />
                                        </div>
                                        <div class="col-md-3">
                                            <img src="" id="I_visitor" runat="server" />
                                            <asp:Label ID="l_visitorLastEvent" runat="server" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>




    </div>

    <asp:UpdatePanel ID="up_panel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>

            <asp:Timer ID="Timer2" runat="server" OnTick="GetTime" Interval="1000" />
            <div class="event-popup" id="div_event" runat="server">
                <div class="row container">
                    <asp:Label ID="l_eventHeader" runat="server" Text=""></asp:Label>
                </div>
                <div class="row container">
                    <asp:Label ID="l_eventBody" runat="server" Text=""></asp:Label>
                </div>
                <div class="row container">
                    <asp:Button ID="b_closeModal" runat="server" Text="Continuar" OnClick="b_closeModal_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
