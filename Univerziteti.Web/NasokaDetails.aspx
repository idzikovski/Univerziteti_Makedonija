<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NasokaDetails.aspx.cs" Inherits="Univerziteti.Web.NasokaDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
<style type="text/css">
        .univerzitetList
        {
            color: #050773;
            font-size: 130%;
            font-weight: normal;
            margin-top: 0px;
            padding-top: 0px;
        }
        .ulNasoki
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        .ulNasoki li
        {
            margin-bottom: 10px;
        }
        
        .ulNasoki a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetNasoka
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetNasoka legend
        {
            padding: 5px 15px;
        }
        .nasokaDescription
        {
            padding-top: 15px;
            width: 60%;
            text-align: justify;
            float: left;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetNasoka">
        <legend>
            <label id="lblNasokaIme" runat="server">
            </label>
        </legend>
        <div class="nasokaDescription">
            <label id="lblOpis" runat="server">
            </label>
            <br />
            <h3>
                Предмети</h3>
            <ul class="ulNasoki">
                <asp:Repeater ID="rptPredmeti" runat="server">
                    <ItemTemplate>
                        <li><a href='PredmetDetails.aspx?id=<%# Eval("Id") %>'>
                            <%# Eval("Ime") %></a> </li>
                    </ItemTemplate>
                 </asp:Repeater>
            </ul>

        </div>
    </fieldset>
</asp:Content>
