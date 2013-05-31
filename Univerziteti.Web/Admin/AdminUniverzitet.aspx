<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUniverzitet.aspx.cs" MasterPageFile="~/Admin.master" Inherits="Univerziteti.Web.Admin.AdminUniverzitet" %>
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
        <td class="leftLabel">Телефон</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtTelefon" runat="server" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Е-Mail</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Адреса</td>
        <td class="rightTxt">
            <asp:TextBox ID="txtAdresa" runat="server" CssClass="txtWidth250"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Слика</td>
        <td class="rightTxt">
            <asp:FileUpload ID="fuSlika" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="leftLabel">Ректор</td>
        <td class="rightTxt">
            <asp:DropDownList ID="ddlVraboteni" runat="server" CssClass="txtWidth250"></asp:DropDownList>
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
            <asp:Button ID="btnVnesi" runat="server" onclick="btnVnesi_Click" Text="Внеси Универзитет" ValidationGroup="Grupa" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="Data Source=DC04L\IVAN;Initial Catalog=Univerziteti;Integrated Security=True" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="VrabotenSelectImePrezime" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
            <asp:GridView ID="gvAdresi" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvAdresi_RowDeleting" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Ulica" HeaderText="Адреса" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
       <td colspan="2" class="td960"></td>
    </tr>
    <tr>
        <td class="leftLabel"><asp:Label ID="lblAdresa" runat="server" Text="Адреса" Visible="False"></asp:Label></td>
        <td class="rightTxt"><asp:TextBox ID="txtAdresaVnes" runat="server" Wrap="False" CssClass="txtWidth250" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="leftLabel"></td>
        <td class="rightTxt"><asp:Button ID="btnAdresaVnes" runat="server" Text="Внеси Адреса" Visible="False" onclick="btnAdresaVnes_Click" /></td>
    </tr>
   <tr>
       <td colspan="2" class="td960">&nbsp</td>
    </tr>
    <tr>
        <td colspan="2" class="td960">
            <asp:GridView ID="gvUniverziteti" runat="server" AutoGenerateColumns="False" 
                onrowcancelingedit="gvUniverziteti_RowCancelingEdit" 
                onrowdeleting="gvUniverziteti_RowDeleting" 
                onrowediting="gvUniverziteti_RowEditing" 
                onrowupdating="gvUniverziteti_RowUpdating" 
                onselectedindexchanged="gvUniverziteti_SelectedIndexChanged" CssClass="Grid" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Име" />
                    <asp:BoundField DataField="Opis" HeaderText="Опис" />
                    <asp:BoundField DataField="Slika" HeaderText="Слика" />
                    <asp:TemplateField HeaderText="Ректор">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlVrab" runat="server" DataSourceID="SqlDataSource1" 
                                DataTextField="ImePrezime" DataValueField="Id">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Rektor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="KontaktId" HeaderText="Контакт" 
                        HtmlEncodeFormatString="False" ReadOnly="True" />
                    <asp:CommandField SelectText="Селектирај" ShowSelectButton="True" />
                    <asp:CommandField CancelText="Откажи" EditText="Промени" ShowEditButton="True" 
                        UpdateText="Зачувај" />
                    <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle CssClass="Grid" />
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>