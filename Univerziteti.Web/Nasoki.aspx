<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nasoki.aspx.cs" Inherits="Univerziteti.Web.Nasoki" %>
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
        #ulNasoki
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        #ulNasoki li
        {
            margin-bottom: 10px;
        }
        
        #ulNasoki a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetNasoki
        {
        	margin-top:0px;         
            padding-top:0px;
        }
        #fieldsetNasoki legend
        {
        	padding:5px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetNasoki">
        <legend>Листа на насоки</legend>
        <ul id="ulNasoki">
            <asp:Repeater ID="rptNasoki" runat="server">
                <ItemTemplate>
                    <li><a href='NasokaDetails.aspx?id=<%# Eval("Id") %>'>
                        <%# Eval("Ime") %></a> &nbsp на &nbsp <a href='FakultetDetails.aspx?id=<%# Eval("FakultetId") %>'> <%# Eval("FakultetIme") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </fieldset>
</asp:Content>
