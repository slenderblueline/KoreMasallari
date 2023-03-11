<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Arsiv.aspx.cs" Inherits="KoreMasallari.Arsiv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="kapsayicidiv">
        <style>
            #ContentPlaceHolder1_arsivtable {
                border-collapse: collapse;
                width: 100%;
                margin-top:40px;
                margin-bottom:40px;
            }

            #ContentPlaceHolder1_arsivtable td, #arsivtable th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #ContentPlaceHolder1_arsivtable tr:nth-child(even) {
                background-color: grey;
            }

            #ContentPlaceHolder1_arsivtable tr:hover {
                background-color: dimgray;
            }

            #ContentPlaceHolder1_arsivtable th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: lightslategrey;
            }
        </style>
        <asp:Table ID="arsivtable" runat="server">
        </asp:Table>
    </div>
    <div class="cubuklar">
    <div class="footercubuk"><center>© 2022 Tüm hakları saklıdır. burakaytar.com</center>
    </div></div>
</asp:Content>
