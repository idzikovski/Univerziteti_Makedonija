<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminNasoka.aspx.cs" MasterPageFile="~/Admin.master" Inherits="Univerziteti.Web.Admin.AdminNasoka" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="../Styles/Admin.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="tbl">
    <tr>
        <td class="leftLabel">Име</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtIme" runat="server" CssClass="txtWidth250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIme" runat="server" ControlToValidate="txtIme" ErrorMessage="*" CssClass="validator" ValidationGroup="Grupa"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Опис</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" CssClass="txtWidth250" Height="150px"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="leftLabel">Факултет</td>
        <td class="rightTxt">
            <asp:DropDownList ID="ddlFakultet" runat="server" CssClass="txtWidth250">
         </asp:DropDownList>
        </td>
    </tr>
     <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt">
            <asp:Button ID="btnVnesi" runat="server" Text="Внеси Насока" 
                onclick="Button1_Click" ValidationGroup="Grupa" />
        </td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt">
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </td>
    </tr>
     <tr>
       <td colspan="2" class="td960">&nbsp</td>
    </tr>
    <tr>
       <td colspan="2" class="td960">
           <asp:Panel ID="Panel1" runat="server" CssClass="line"></asp:Panel>
       </td>
    </tr>
     <tr>
       <td colspan="2" class="td960">&nbsp</td>
    </tr>
    <tr>
        <td colspan="2" class="td960">
            <asp:GridView ID="gvNasoki" runat="server" AutoGenerateColumns="False" 
                onrowcancelingedit="gvNasoki_RowCancelingEdit" 
                onrowdeleting="gvNasoki_RowDeleting" onrowediting="gvNasoki_RowEditing" 
                onrowupdating="gvNasoki_RowUpdating" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Име" />
                    <asp:BoundField DataField="Opis" HeaderText="Опис" />
                    <asp:BoundField DataField="FakultetId" HeaderText="Факултет" 
                        ReadOnly="True" />
                    <asp:CommandField CancelText="Откажи" EditText="Промени" ShowEditButton="True" 
                        UpdateText="Зачувај" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>