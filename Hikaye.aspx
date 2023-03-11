<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Hikaye.aspx.cs" Inherits="KoreMasallari.Hikaye" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="hikayekapsayici">

        <div class="metinsecici"><center>
            Türkçe Metin&nbsp;
            <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" AutoPostBack="True" />
            &nbsp;Korece Metin&nbsp;
            <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" AutoPostBack="True" />

              </center>
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"> </asp:PlaceHolder>
        </div>
    
 <div class="cubuklar">
    <div class="footercubuk"><center>© 2022 Tüm hakları saklıdır. burakaytar.com</center>
    </div></div>
</asp:Content>
