<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Univerziteti.aspx.cs" Inherits="Univerziteti.Web.Univerziteti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .univerzitetList
        {
            color: #050773;
            font-size: 130%;
            font-weight: normal;   
            margin-top:0px;         
            padding-top:0px;
        }
        #ulUniverziteti
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        #ulUniverziteti li
        {
            margin-bottom: 10px;
        }
        
        #ulUniverziteti a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetUniverzitet
        {
        	margin-top:0px;         
            padding-top:0px;
        }
        #fieldsetUniverzitet legend
        {
        	padding:5px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset id="fieldsetUniverzitet">
        <legend>Листа на универзитети</legend>
        <ul id="ulUniverziteti">
            <asp:Repeater ID="rptUniverziteti" runat="server">
                <ItemTemplate>
                    <li><a href='UniverzitetDetails.aspx?id=<%# Eval("Id") %>'>
                        <%# Eval("Ime") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </fieldset>
</asp:Content>
