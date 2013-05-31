<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FakultetDetails.aspx.cs" Inherits="Univerziteti.Web.FakultetDetails" %>
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
        .ulFakulteti
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        .ulFakulteti li
        {
            margin-bottom: 10px;
        }
        
        .ulFakulteti a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetFakultet
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetFakultet legend
        {
            padding: 5px 15px;
        }
        .fakuletDescription
        {
            padding-top: 15px;
            width: 60%;
            text-align: justify;
            float: left;
        }
        .fakultetContact
        {
            padding-top: 15px;
            width: 33%;
            float: right;
        }
        .fakultetSlika
        {
        	width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetFakultet">
        <legend>
            <label id="lblFakultetIme" runat="server">
            </label>
        </legend>
        <div class="fakultetSlika">
        <img src="" id="imgFakultetSlika" runat="server" alt="FakultetSLika" />
        </div>
        <div class="fakuletDescription">
            <label id="lblOpis" runat="server">
            </label>
            <br />
            <h3>
                Насоки</h3>
            <ul class="ulFakulteti">
                <asp:Repeater ID="rptNasoki" runat="server">
                    <ItemTemplate>
                        <li><a href='NasokaDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("Ime") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <br />
            <h3>
                Вработени</h3>
                 
            <ul class="ulFakulteti">
                <li>
                   <a id="aDekan" runat="server"> Декан:  <label id="lblDekan" runat="server"></label> </a>
                </li>
                <asp:Repeater ID="rptProdekani" runat="server">
                    <ItemTemplate>
                        <li><a href='VrabotenDetails.aspx?id=<%# Eval("Id") %>'>
                           Продекан: <%# Eval("Ime") %>: <%# Eval("Prezime") %></a> </li>
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
        <fieldset class="fakultetContact">
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
