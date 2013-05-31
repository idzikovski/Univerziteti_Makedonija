<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPredmet.aspx.cs" MasterPageFile="~/Admin.master" Inherits="Univerziteti.Web.Admin.AdminPredmet" %>

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
        <td class="leftLabel">Фонд</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtFond" runat="server" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Кредити</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtKrediti" runat="server" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="leftLabel">Опис</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" CssClass="txtWidth250" Height="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Програма</td>
        <td class="rightTxt">
            <asp:FileUpload ID="fuPrograma" runat="server" />
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt">
            <asp:Button ID="btnVnesi" runat="server" onclick="btnVnesi_Click" 
                Text="Внеси Предмет" />
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
            <asp:GridView ID="gvPredmeti" runat="server" AutoGenerateColumns="False" 
                onrowcancelingedit="gvPredmeti_RowCancelingEdit" 
                onrowdeleting="gvPredmeti_RowDeleting" onrowediting="gvPredmeti_RowEditing" 
                onrowupdating="gvPredmeti_RowUpdating" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Име" />
                    <asp:BoundField DataField="Opis" HeaderText="Опис" />
                    <asp:BoundField DataField="Fond" HeaderText="Фонд" />
                    <asp:BoundField DataField="Krediti" HeaderText="Кредитит" />
                    <asp:BoundField DataField="Programa" HeaderText="Програма" />
                    <asp:CommandField CancelText="Откажи" EditText="Промени" ShowEditButton="True" 
                        UpdateText="Зачувај" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>