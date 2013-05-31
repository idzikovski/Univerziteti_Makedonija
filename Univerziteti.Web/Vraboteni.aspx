<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vraboteni.aspx.cs" Inherits="Univerziteti.Web.Vraboteni" %>
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
        #ulVraboteni
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        #ulVraboteni li
        {
            margin-bottom: 10px;
        }
        
        #ulVraboteni a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetVraboten
        {
        	margin-top:0px;         
            padding-top:0px;
        }
        #fieldsetVraboten legend
        {
        	padding:5px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetVraboten">
        <legend>Листа на вработени</legend>
        <ul id="ulVraboteni">
            <asp:Repeater ID="rptVraboteni" runat="server">
                <ItemTemplate>
                    <li><a href='VrabotenDetails.aspx?id=<%# Eval("Id") %>'>
                        <%# Eval("Ime") %> <%# Eval("Prezime") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </fieldset>
</asp:Content>
