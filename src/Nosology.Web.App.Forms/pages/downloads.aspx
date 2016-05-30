<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="Escyug.Nosology.Web.App.Forms.pages.downloads" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Загрузки</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid nos-content">

        <asp:ListView ID="filesListView" runat="server" EnableViewState="true">

            <ItemTemplate>

                <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--6-col">
                    <a href="#" data-link='<%# Eval("Link") %>' onclick="getFile(this.dataset.link, 'files')">

                        <i class="material-icons content-icon"><%# Eval("IconStyle") %></i>

                        <span style="position: absolute; margin-top: 5px;"><%# Eval("Title") %></span>

                    </a>
                </div>

            </ItemTemplate>

            <EmptyDataTemplate>
                <div class="mdl-cell mdl-cell--12-col mdl-cell--middle mdl-cell-text--center">
                    <h2>NO DATA</h2>
                </div>
            </EmptyDataTemplate>

            <LayoutTemplate>
                <div id="itemPlaceholder" runat="server" />
            </LayoutTemplate>

        </asp:ListView>

    </div>
</asp:Content>

<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
   <script type="text/javascript" src="../Scripts/downloads.js"></script>
</asp:Content>
