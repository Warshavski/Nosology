<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="documents.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.documents" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Документы</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid nos-content nos-docs">

        <asp:ListView ID="docsList" runat="server" EnableViewState="true">

            <ItemTemplate>
                
                <div class="mdl-cell mdl-cell--10-col demo-graphs">
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

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
