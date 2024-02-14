<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EsercizioCinema.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="adminView">
        <div>
            <h2>SALA NORD:</h2>
            <asp:Label ID="ticketsNord" runat="server" Text=""></asp:Label>
            <asp:Label ID="kidsNord" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <h2>SALA EST:</h2>
            <asp:Label ID="ticketsEst" runat="server" Text=""></asp:Label>
            <asp:Label ID="kidsEst" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <h2>SALA SUD:</h2>
            <asp:Label ID="ticketsSud" runat="server" Text=""></asp:Label>
            <asp:Label ID="kidsSud" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <form id="ticketForm" runat="server">
        <div>
            <asp:Label ID="lblName" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblSurname" runat="server" Text="Cognome:"></asp:Label>
            <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:RadioButtonList ID="RadioSala" runat="server">
                <asp:ListItem Value="Nord">Sala Nord</asp:ListItem>
                <asp:ListItem Value="Est">Sala Est</asp:ListItem>
                <asp:ListItem Value="Sud">Sala Sud</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:CheckBox ID="checkRidotto" runat="server" Text=" Ridotto"/>
        </div>
        <asp:Button ID="btnBuyTicket" runat="server" Text="Invia biglietto" OnClick="btnBuyTicket_Click" />
    </form>
</body>
</html>