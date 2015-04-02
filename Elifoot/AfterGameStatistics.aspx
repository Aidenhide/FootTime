<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfterGameStatistics.aspx.cs" Inherits="Elifoot.AfterGameStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row container-fluid">
        <h3 class="row text-center">
            <span>Resultados </span>
            <asp:Label ID="l_journey" runat="server"></asp:Label>
        </h3>

        <asp:Repeater ID="leagueRepeater" runat="server" OnItemDataBound="leagueRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="row text-center" style="border:2px solid black; border-radius:2px 2px;">
                    <asp:Label Text='<%# "Divisão " + Eval("Division") %>' runat="server" CssClass="league-title" />
                    <asp:Repeater ID="matchRepeater" runat="server">
                        <ItemTemplate>
                            <div class="row match-table">
                                <%-- HOUSE --%>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-10 text-right team-field-s">
                                            <asp:Label Text='<%# Eval("HouseName") %>' runat="server" CssClass="team-title" />
                                        </div>
                                        <div class="col-md-2 text-right score-field-s-s">
                                            <asp:Label Text='<%# Eval("HouseScore") %>' runat="server" CssClass="team-title"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10 text-right team-field-s">
                                            <asp:Label Text="Posse de bola: " runat="server" />
                                        </div>
                                        <div class="col-md-2 text-right score-field-s">
                                            <asp:Label Text='<%# Eval("HouseBallTime")+"%" %>' runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10 text-right team-field-s">
                                            <asp:Label Text="Remates: " runat="server" />
                                        </div>
                                        <div class="col-md-2 text-right score-field-s">
                                            <asp:Label Text='<%# Eval("HouseShots") %>' runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10 text-right team-field-s">
                                            <asp:Label Text="Cantos:" runat="server" />
                                        </div>
                                        <div class="col-md-2 text-right score-field-s">
                                            <asp:Label Text='<%# Eval("HouseCorners") %>' runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10 text-right team-field-s">
                                            <asp:Label Text="Faltas cometidas: " runat="server" />
                                        </div>
                                        <div class="col-md-2 text-right score-field-s">
                                            <asp:Label Text='<%# Eval("HouseFaults") %>' runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <%-- VISITOR --%>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-2 text-left score-field-s">
                                            <asp:Label Text='<%# Eval("VisitorScore") %>' runat="server" CssClass="team-title"/>
                                        </div>
                                        <div class="col-md-10 text-left team-field-s">
                                            <asp:Label Text='<%# Eval("VisitorName") %>' runat="server" CssClass="team-title" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 text-left score-field-s">
                                            <asp:Label Text='<%# Eval("VisitorBallTime")+"%" %>' runat="server" />
                                        </div>
                                        <div class="col-md-10 text-left team-field-s">
                                            <asp:Label Text="Posse de bola: " runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 text-left score-field-s">
                                            <asp:Label Text='<%# Eval("VisitorShots") %>' runat="server" />
                                        </div>
                                        <div class="col-md-10 text-left team-field-s">
                                            <asp:Label Text="Remates: " runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 text-left score-field-s">
                                            <asp:Label Text='<%# Eval("VisitorCorners") %>' runat="server" />
                                        </div>
                                        <div class="col-md-10 text-left team-field-s">
                                            <asp:Label Text="Cantos:" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 text-left score-field-s">
                                            <asp:Label Text='<%# Eval("VisitorFaults") %>' runat="server" />
                                        </div>
                                        <div class="col-md-10 text-left team-field-s">
                                            <asp:Label Text="Faltas cometidas: " runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
