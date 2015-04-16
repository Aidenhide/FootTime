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
        <div class="row text-center tactics">
            <span>Táctica:</span>
            <span id="s_defenders">0</span> -
            <span id="s_midfielders">0</span> -
            <span id="s_forwards">0</span>
            <span> | </span>
            <img src="../Content/Images/shirtSelected20.png" />
            <span id="s_totalSelected">0</span> | 
            <img src="../Content/Images/shirtSubs20.png" />
            <span id="s_totalSubs">0</span>
        </div>


        <div class="col-md-2 side-menu">
            <div class="row menu-option">
                <asp:LinkButton ID="lk_beginJourney" Text="Começar Jornada" runat="server" CssClass="menu-lk" OnClick="lk_beginJourney_Click" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Táctica" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Treinos" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton ID="lk_calendar" Text="Calendário" runat="server" CssClass="menu-lk" OnClick="lk_calendar_Click"/>
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Classificação" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Mercado" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Estádio" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Finanças" runat="server" CssClass="menu-lk" />
            </div>
            <div class="row menu-option">
                <asp:LinkButton Text="Notícias" runat="server" CssClass="menu-lk" />
            </div>
        </div>
        <div class="col-md-10">
            <div class="row">

                <%-- TEAM VIEWER --%>
                <div class="col-md-12">
                    <asp:UpdatePanel runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="row">
                                            <div class="col-md-6" id="div_1" runat="server"></div>
                                            <div class="col-md-6" id="div_2" runat="server"></div>
                                        </div>
                            <asp:Repeater ID="repeaterTeam" runat="server" OnItemDataBound="repeaterTeam_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="row">
                                        
                                        <div class="col-12-md">
                                            <table class="home-table">
                                                <tr>
                                                    <th class="text-center">Selc.</th>
                                                    <th class="text-center">Posição</th>
                                                    <th class="text-center">Nome</th>
                                                    <th class="text-center">Idade</th>
                                                    <th class="text-center">País</th>
                                                    <th class="text-center">Lesão</th>
                                                    <th class="text-center">RES</th>
                                                    <th class="text-center">FOR</th>
                                                    <th class="text-center">TEC</th>
                                                    <th class="text-center">EXP</th>
                                                    <th class="text-center">Total</th>
                                                    <th class="text-center">Salário</th>
                                                    <th class="text-center">Valor</th>
                                                </tr>
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <tr style="height: 24px">
                                        <td><img src="../Content/Images/shirt20.png" id="i_shirt" runat="server"
                                                onclick='<%# "selectPlayer(\"" + DataBinder.Eval(Container.DataItem, "PlayerId") + "\",\"" + DataBinder.Eval(Container.DataItem, "Position") + "\"," + "this" +");" %>' />
                                        </td>
                                        <td class="td-big"><%# DataBinder.Eval(Container.DataItem, "Position") %></td>
                                        <td class="td-big"><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Age") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Nationality") %></td>
                                        <td class="td-small"><%# (bool)DataBinder.Eval(Container.DataItem, "Injured") == false ? "" : "Lesão" %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Stamina") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Strength") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Technick") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "Experience") %></td>
                                        <td class="td-small"><%# DataBinder.Eval(Container.DataItem, "OverallPower") %></td>
                                        <td class="td-medium"><%# Math.Floor((decimal)DataBinder.Eval(Container.DataItem, "Salary")) + " €" %></td>
                                        <td class="td-medium"><%# Math.Floor((decimal)DataBinder.Eval(Container.DataItem, "MarketValue")) + " €" %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                            </div>
                        </div>
                            
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
            <div class="row"></div>
        </div>
    </div>


    <script>
        var players = [];
        var subsPlayers = [];
        var defenders = 0;
        var midfielders = 0;
        var forwards = 0;

        var haveGoalkeeper = false;

        function selectPlayer(id, position, image) {
            if (players.length >= 11) {
                if (subsPlayers.length >= 7) {
                    alert("No máximo podes escolher 11 titulares e 7 substitutos");
                    return true;
                }
                else {
                    return addPlayerToSubs(id, position, image);
                }
            }
            else {
                if (players.length == 10 && haveGoalkeeper == false) {
                    if (position == "GoalKeeper") {
                        players.push(id);
                        $("#s_totalSelected").text(players.length);
                        haveGoalkeeper = true;
                        image.src = "../Content/Images/shirtSelected20.png"
                        return true;
                    }
                    else {
                        alert("Precisas de 1 Guarda-redes na equipa titular.");
                        return true;
                    }
                }
                if (haveGoalkeeper && position == "GoalKeeper") {
                    if (subsPlayers.length >= 7) {
                        alert("No máximo podes 7 substitutos");
                        return true;
                    }
                    return addPlayerToSubs(id, position, image);
                }
                return addPlayerToSelected(id, position, image);

            }
        }

        function addPlayerToSelected(id, position, image) {
            for (var i = 0; i < players.length; i++) {
                if (players[i] == id) {
                    players = players.slice(0, i).concat(players.slice((i + 1), players.length - 1));
                    $("#s_totalSelected").text(players.length);
                    if (position == "GoalKeeper") {
                        haveGoalkeeper = false;
                    }
                    image.src = "../Content/Images/shirt20.png";
                    updateTactics(false, position);
                    $("#s_totalSelected").text(players.length);
                    return true;
                }
            }
            if (position == "GoalKeeper") {
                haveGoalkeeper = true;
            }
            players.push(id);
            $("#s_totalSelected").text(players.length);
            updateTactics(true, position);
            image.src = "../Content/Images/shirtSelected20.png";
            return true;
        }

        function addPlayerToSubs(id, position, image) {
            for (var i = 0; i < subsPlayers.length; i++) {
                if (subsPlayers[i] == id) {
                    subsPlayers = subsPlayers.slice(0, i).concat(subsPlayers.slice((i + 1), subsPlayers.length - 1));
                    $("#s_totalSubs").text(subsPlayers.length);
                    image.src = "../Content/Images/shirt20.png";
                    return true;
                }
            }
            subsPlayers.push(id);
            $("#s_totalSubs").text(subsPlayers.length);
            image.src = "../Content/Images/shirtSubs20.png";
            return true;
        }

        function updateTactics(up, position) {
            debugger;
            if (up) {
                if (position == "Defender") {
                    defenders++;
                    $("#s_defenders").text(defenders);
                }
                else if (position == "Midfielder") {
                    midfielders++;
                    $("#s_midfielders").text(midfielders);
                }
                else if (position == "Forward") {
                    forwards++;
                    $("#s_forwards").text(forwards);
                }
            }
            else {
                if (position == "Defender") {
                    defenders--;
                    $("#s_defenders").text(defenders);
                }
                else if (position == "Midfielder") {
                    midfielders--;
                    $("#s_midfielders").text(midfielders);
                }
                else if (position == "Forward") {
                    forwards--;
                    $("#s_forwards").text(forwards);
                }
            }
        }
    </script>
</asp:Content>
