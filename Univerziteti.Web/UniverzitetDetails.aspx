<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UniverzitetDetails.aspx.cs" Inherits="Univerziteti.Web.UniverzitetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .univerzitetList
        {
            color: #050773;
            font-size: 130%;
            font-weight: normal;
            margin-top: 0px;
            padding-top: 0px;
        }
        .ulUniverziteti
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        .ulUniverziteti li
        {
            margin-bottom: 10px;
        }
        
        .ulUniverziteti a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetUniverzitet
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetUniverzitet legend
        {
            padding: 5px 15px;
        }
        .univezitetDescription
        {
            padding-top: 15px;
            width: 60%;
            text-align: justify;
            float: left;
        }
        .univezitetContact
        {
            padding-top: 15px;
            width: 33%;
            float: right;
        }
        .univerzitetSlika
        {
        	width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset id="fieldsetUniverzitet">
        <legend>
            <label id="lblUniverzitetIme" runat="server">
            </label>
        </legend>
        <div class="univerzitetSlika">
        <img src="" id="imgUniverzitetSlika" runat="server" alt="UnivezitetSLika" />
        </div>
        <div class="univezitetDescription">
            <label id="lblOpis" runat="server">
            </label>
            <br />
            <h3>
                Факултети</h3>
            <ul class="ulUniverziteti">
                <asp:Repeater ID="rptFakulteti" runat="server">
                    <ItemTemplate>
                        <li><a href='FakultetDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("Ime") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <br />
            <h3>
                Вработени</h3>
            <ul class="ulUniverziteti">
                <li>
                   <a id="aRektor" runat="server"> Ректор:  <label id="lblRektor" runat="server"></label> </a>
                </li>
                <asp:Repeater ID="rptProrektori" runat="server">
                    <ItemTemplate>
                        <li><a href='VrabotenDetails.aspx?id=<%# Eval("Id") %>'>
                           Проректор: <%# Eval("Ime") %>: <%# Eval("Prezime") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptVraboteni" runat="server">
                    <ItemTemplate>
                        <li><a href='VrabotenDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("ImePrezime") %>: <%# Eval("Pozicija") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <fieldset class="univezitetContact">
            <legend>Контакти</legend>
            <h3 style="border-bottom: 1px dashed #ccc; padding-left: 5px;">
                Адреси</h3>
            <br />
            <asp:Repeater ID="rptAdresi" runat="server">
                <ItemTemplate>
                    <%# Eval("Ulica")%>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <h3 style="border-bottom: 1px dashed #ccc; padding-left: 5px;">
                Телефони</h3>
            <br />
            <asp:Repeater ID="rptTelefoni" runat="server">
                <ItemTemplate>
                    <%# Eval("Opis")%>: <strong>
                        <%# Eval("Broj")%></strong>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <h3 style="border-bottom: 1px dashed #ccc; padding-left: 5px;">
                Емаил Адреси</h3>
            <br />
            <asp:Repeater ID="rptEmails" runat="server">
                <ItemTemplate>
                    <%# Eval("Adresa")%>
                </ItemTemplate>
            </asp:Repeater>
        </fieldset>
    </fieldset>
</asp:Content>
