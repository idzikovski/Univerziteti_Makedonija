<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMMVrski.aspx.cs" MasterPageFile="~/Admin.master"
    Inherits="Univerziteti.Web.Admin.AdminMMVrski" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/Admin.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="tbl">
        <tr>
            <td colspan="2" class="td960">
                <asp:Label ID="rabotivouni" runat="server" Font-Bold="True" Font-Size="15pt" Text="Работи во Универзитет"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Универзитет:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlUniRab" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Вработен:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlVrabRabUni" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Позиција:
            </td>
            <td class="rightTxt">
                <asp:TextBox ID="txtUniPozicija" runat="server" CssClass="txtWidth250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Button ID="btnRabUni" runat="server" OnClick="btnRabUni_Click" Text="Внеси" />
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Label ID="lblRabUni" runat="server" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:GridView ID="gvRabUni" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvRabUni_RowDeleting"
                    CssClass="Grid" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="UniverzitetId" HeaderText="Универзитет" />
                        <asp:BoundField DataField="UniverzitetIme" HeaderText="Име на Универзитет" />
                        <asp:BoundField DataField="Id" HeaderText="Вработен" />
                        <asp:BoundField DataField="ImePrezime" HeaderText="Име на Вработен" />
                        <asp:BoundField DataField="Pozicija" HeaderText="Позиција" />
                        <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Panel ID="Panel1" runat="server" CssClass="line">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Label ID="rabotivouni0" runat="server" Font-Bold="True" Font-Size="15pt" Text="Проректори"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Универзитет:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlUniProRekt" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Вработен:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlVrabProRekt" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Button ID="btnProrektori" runat="server" Text="Внеси" OnClick="btnProrektori_Click" />
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Label ID="lblProrektori" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:GridView ID="gvProrektori" runat="server" AutoGenerateColumns="False" Style="margin-left: 0px"
                    OnRowDeleting="gvProrektori_RowDeleting" CssClass="Grid" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="UniverzitetId" HeaderText="Универзитет" />
                        <asp:BoundField DataField="Ime" HeaderText="Име на Универзитет" />
                        <asp:BoundField DataField="Id" HeaderText="Вработен" />
                        <asp:BoundField DataField="ImePrezime" HeaderText="Име на Вработен" />
                        <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Panel ID="Panel2" runat="server" CssClass="line">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Label ID="rabotivouni1" runat="server" Font-Bold="True" Font-Size="15pt" Text="Работи на Факултет"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Факултет:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlFakRab" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Вработен:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlVrabRabFak" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Институт:
            </td>
            <td class="rightTxt">
                <asp:TextBox ID="txtInstitut" runat="server" CssClass="txtWidth250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Позиција:
            </td>
            <td class="rightTxt">
                <asp:TextBox ID="txtFakPozicija" runat="server" CssClass="txtWidth250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Button ID="btnRabFak" runat="server" Text="Внеси" OnClick="btnRabFak_Click" />
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Label ID="lblRabFak" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:GridView ID="gvRabFak" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvRabFak_RowDeleting"
                    CssClass="Grid" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="FakultetId" HeaderText="Факултет" />
                        <asp:BoundField DataField="FakultetIme" HeaderText="Име на Факултет" />
                        <asp:BoundField DataField="Id" HeaderText="Вработен" />
                        <asp:BoundField DataField="ImePrezime" HeaderText="Име на Вработен" />
                        <asp:BoundField DataField="Pozicija" HeaderText="Позиција" />
                        <asp:BoundField DataField="Institut" HeaderText="Институт" />
                        <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Panel ID="Panel3" runat="server" CssClass="line">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Label ID="rabotivouni2" runat="server" Font-Bold="True" Font-Size="15pt" Text="Продекани"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Факултет:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlFakProDek" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Вработен:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlVrabProDek" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Button ID="btnProdekani" runat="server" Text="Внеси" OnClick="btnProdekani_Click" />
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Label ID="lblProdekani" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:GridView ID="gvProdekani" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvProdekani_RowDeleting"
                    CssClass="Grid" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="FakultetId" HeaderText="Факултет" />
                        <asp:BoundField DataField="FakultetIme" HeaderText="Име на Факултет" />
                        <asp:BoundField DataField="Id" HeaderText="Вработен" />
                        <asp:BoundField DataField="ImePrezime" HeaderText="Име на Вработен" />
                        <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Panel ID="Panel4" runat="server" CssClass="line">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:Label ID="rabotivouni3" runat="server" Font-Bold="True" Font-Size="15pt" Text="Насока - Предмет"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Насока:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlNasokaNP" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
                Предмет:
            </td>
            <td class="rightTxt">
                <asp:DropDownList ID="ddlPredmetNP" runat="server" CssClass="txtWidth250">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Button ID="btnNP" runat="server" Text="Внеси" OnClick="btnNP_Click" />
            </td>
        </tr>
        <tr>
            <td class="leftLabel">
            </td>
            <td class="rightTxt">
                <asp:Label ID="lblNP" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                &nbsp
            </td>
        </tr>
        <tr>
            <td colspan="2" class="td960">
                <asp:GridView ID="gvNP" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvNP_RowDeleting"
                    CssClass="Grid" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="NasokaId" HeaderText="Насока" />
                        <asp:BoundField DataField="NasokaIme" HeaderText="Име на Насока" />
                        <asp:BoundField DataField="Id" HeaderText="Предмет" />
                        <asp:BoundField DataField="Ime" HeaderText="Име на Предмет" />
                        <asp:CommandField DeleteText="Избриши" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
