<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Escyug.Nosology.Web.App.pages.main" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Главная</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <!-- Static text -->
    <div class="nos-graphs" style="padding: 10px;">
                    
       <asp:Literal ID="contentLiteral" runat="server">

       </asp:Literal>
        
    </div>
</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">

</asp:Content>
