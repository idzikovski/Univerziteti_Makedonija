<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VrabotenDetails.aspx.cs" Inherits="Univerziteti.Web.VrabotenDetails" %>
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
        .ulVraboteni
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        .ulVraboteni li
        {
            margin-bottom: 10px;
        }
        
        .ulVraboteni a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetVraboten
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetVraboten legend
        {
            padding: 5px 15px;
        }
        .vrabotenDescription
        {
            padding-top: 15px;
            width: 60%;
            text-align: justify;
            float: left;
        }
        .vrabotenContact
        {
            padding-top: 15px;
            width: 33%;
            float: right;
        }
        .vrabotenSlika
        {
        	width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetVraboten">
        <legend>
            <label id="lblVrabotenIme" runat="server">
            </label>
        </legend>
        <div class="vrabotenSlika">
        <img src="" id="imgVrabotenSlika" runat="server" alt="VrabotenSLika" />
        </div>
        <div class="vrabotenDescription">
            <label id="lblOpis" runat="server">
            </label>
            <br />
            <h3>
                Работи во</h3>
            <ul class="ulVraboteni">
                <asp:Repeater ID="rptUniverzieti" runat="server">
                    <ItemTemplate>
                        <li><a href='UniverzitetDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("Ime") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptFakulteti" runat="server">
                    <ItemTemplate>
                        <li><a href='FakultetDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("Ime") %></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

        </div>
        <fieldset class="vrabotenContact">
            <legend>Контакти</legend>
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
