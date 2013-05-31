<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVraboten.aspx.cs" MasterPageFile="~/Admin.master" Inherits="Univerziteti.Web.Admin.AdminVraboten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link href="../Styles/Admin.css" rel="stylesheet" type="text/css" />
<link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="tbl">
    <tr>
        <td class="leftLabel">Име</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtIme" runat="server" EnableViewState="False" CssClass="txtWidth250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIme" runat="server" 
                ErrorMessage="*" ValidationGroup="Grupa" CssClass="validator"
                ControlToValidate="txtIme"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Презиме</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtPrezime" runat="server" EnableViewState="False" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Опис</td>
        <td class="rightTxt"">
            <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" 
                EnableViewState="False" CssClass="txtWidth250" Height="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Телефон</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtTelefon" runat="server" EnableViewState="False" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">E-Mail</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtEmail" runat="server" EnableViewState="False" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Слика</td>
        <td class="rightTxt">
            <asp:FileUpload ID="fuSlika" runat="server" EnableViewState="False" />
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td colspan="2">   
            <asp:Image ID="imgSlika" runat="server" Visible="False" Width="100%"/>     
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt">
            <asp:Button ID="btnVnesi" runat="server" Text="Внеси Вработен" 
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
     <td class="leftLabel"></td>
        <td class="rightTxt">
             <asp:Label ID="lblIme" runat="server" Font-Bold="True" Font-Size="Larger" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
       <td colspan="2" class="td960">
            <asp:GridView ID="gvTelefoni" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvTelefoni_RowDeleting" Visible="False" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Opis" HeaderText="Опис" />
                    <asp:BoundField DataField="Broj" HeaderText="Број" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"><asp:Label ID="lblOpis" runat="server" Text="Опис" Visible="False"></asp:Label></td>
        <td class="rightTxt"><asp:TextBox ID="txtTelefonOpis" runat="server" CssClass="txtWidth250" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftLabel"><asp:Label ID="lblBroj" runat="server" Text="Број" Visible="False"></asp:Label></td>
        <td class="rightTxt"><asp:TextBox ID="txtTelefonBroj" runat="server" CssClass="txtWidth250" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt"><asp:Button ID="btnVnesiTel" runat="server" onclick="btnVnesiTel_Click" Text="Внеси Телефон" Visible="False" /></td>
    </tr>
    <tr>
       <td colspan="2" class="td960">&nbsp</td>
    </tr>
    <tr>
         <td colspan="2" class="td960">
            <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvEmail_RowDeleting" Visible="False" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Adresa" HeaderText="Е-Мail" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"><asp:Label ID="lblEmail" runat="server" Text="E-Mail" Visible="False"></asp:Label></td>
        <td class="rightTxt"><asp:TextBox ID="txtEmailAdresa" runat="server"  CssClass="txtWidth250" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt"><asp:Button ID="btnEmailV" runat="server" onclick="btnEmailV_Click" Text="Внеси E-Mail" Visible="False" /></td>
    </tr>
   <tr>
       <td colspan="2" class="td960">&nbsp</td>
    </tr>
    <tr>
       <td colspan="2" class="td960">
            <asp:GridView ID="gvVraboteni" runat="server" AutoGenerateColumns="False" 
                onrowcancelingedit="gvVraboteni_RowCancelingEdit" 
                onrowdeleting="gvVraboteni_RowDeleting" onrowediting="gvVraboteni_RowEditing" 
                onrowupdating="gvVraboteni_RowUpdating" 
                onselectedindexchanged="gvVraboteni_SelectedIndexChanged" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Име" />
                    <asp:BoundField DataField="Prezime" HeaderText="Презиме" />
                    <asp:BoundField DataField="Opis" HeaderText="Опис" />
                    <asp:BoundField DataField="Slika" HeaderText="Слика" />
                    <asp:BoundField DataField="KontaktId" HeaderText="Контакт" ReadOnly="True" />
                    <asp:CommandField SelectText="Селектирај" ShowSelectButton="True" />
                    <asp:CommandField CancelText="Откажи" EditText="Промени" ShowEditButton="True" 
                        UpdateText="Зачувај" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>