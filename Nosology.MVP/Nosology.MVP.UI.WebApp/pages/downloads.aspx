<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.downloads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Загрузки</span>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid nos-content">

        <asp:ListView ID="docsList" runat="server" EnableViewState="true">

            <ItemTemplate>

                <div download class="nos-graphs mdl-shadow--2dp mdl-color--white mdl-cell mdl-cell--8-col">
                    <a href='<%# Eval("Link") %>'>
                        <i class="<%# Eval("Icon") %> content-icon"></i>
                        <%# Eval("Title") %>
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

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
