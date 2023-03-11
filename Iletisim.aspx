<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="KoreMasallari.Iletisim" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="iletisimdivi">
        <table style="margin: auto; width:auto;">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Ad Soyad:&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label></td>
                <td colspan="2" style="float: left"><asp:TextBox ID="adsoyadtxt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adsoyadtxt" ForeColor="Red">*</asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="E-mail :&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label></td>
                <td colspan="2" style="float: left"><asp:TextBox ID="epostatxt" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="epostatxt" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="epostatxt" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Mesajınız :&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label></td>
                <td colspan="2" style="float: left">
                    <asp:TextBox ID="mesajtxt" runat="server" Height="150px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="mesajtxt" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="float: left">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gönder" />
                </td>
                <td style="float: left; text-align: left; width: 150px; height: 50px; white-space: nowrap; padding-left: 20px;">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
<br />
    </div>
    <div class="cubuklar">
    <div class="footercubuk"><center>© 2022 Tüm hakları saklıdır. burakaytar.com</center>
    </div></div>
</asp:Content>
