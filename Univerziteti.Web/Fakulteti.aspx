<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fakulteti.aspx.cs" Inherits="Univerziteti.Web.Fakulteti" %>
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
        #ulFakulteti
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        #ulFakulteti li
        {
            margin-bottom: 10px;
        }
        
        #ulFakulteti a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetFakulteti
        {
        	margin-top:0px;         
            padding-top:0px;
        }
        #fieldsetFakulteti legend
        {
        	padding:5px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetFakulteti">
        <legend>Листа на факултети</legend>
        <ul id="ulFakulteti">
            <asp:Repeater ID="rptFakulteti" runat="server">
                <ItemTemplate>
                    <li><a href='FakultetDetails.aspx?id=<%# Eval("Id") %>'>
                        <%# Eval("Ime") %></a> &nbsp при &nbsp <a href='UniverzitetDetails.aspx?id=<%# Eval("UniverzitetId") %>'> <%# Eval("UniverzitetIme") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </fieldset>
</asp:Content>
