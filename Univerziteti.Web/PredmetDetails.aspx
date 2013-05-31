<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PredmetDetails.aspx.cs" Inherits="Univerziteti.Web.PredmetDetails" %>
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
        .ulPredmet
        {
            font-size: 13px;
            list-style-image: url("Images/bullet.png");
        }
        
        .ulPredmet li
        {
            margin-bottom: 10px;
        }
        
        .ulPredmet a
        {
            text-decoration: none;
            color: #000;
        }
        #fieldsetPredmer
        {
            margin-top: 0px;
            padding-top: 0px;
        }
        #fieldsetPredmer legend
        {
            padding: 5px 15px;
        }
        .predmetDescription
        {
            padding-top: 15px;
            width: 60%;
            text-align: justify;
            float: left;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset id="fieldsetPredmet">
        <legend>
            <label id="lblPredmetIme" runat="server">
            </label>
        </legend>
        <div class="predmetDescription">
            <h3>Опис</h3>
            <br />
            <label id="lblOpis" runat="server">
            </label>
            <br />
            <br />
            <h3>Фонд на часови</h3>
            <br />
            <label id="lblFond" runat="server"></label>
            <br />
            <br />
            <h3>Број на кредити</h3>
            <br />
            <label id="lblKrediti" runat="server"></label>
            <br />
            <br />
            <div id="divPrograma" runat="server">
                Програма: <a id="aPrograma" target="_blank" runat="server"><img src='/Images/dIcon.jpg' alt="Download Icon" /></a>
            </div>

        </div>
    </fieldset>
</asp:Content>
