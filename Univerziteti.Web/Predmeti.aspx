<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Predmeti.aspx.cs" Inherits="Univerziteti.Web.Predmeti" %>

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
        #ulPredmeti
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        #ulPredmeti li
        {
            margin-bottom: 10px;
        }
        
        #ulPredmeti a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetPredmeti
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetPredmeti legend
        {
            padding: 5px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset id="fieldsetPredmeti">
        <legend>Листа на предмети</legend>
        <ul id="ulPredmeti">
            <asp:Repeater ID="rptPredmeti" runat="server">
                <ItemTemplate>
                    <li><a href='PredmetDetails.aspx?id=<%# Eval("Id") %>'>
                        <%# Eval("Ime") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </fieldset>
</asp:Content>
