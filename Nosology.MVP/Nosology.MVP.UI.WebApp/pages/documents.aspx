<%@ Page Title="" Language="C#" MasterPageFile="~/pages/shared/_Main.Master" AutoEventWireup="true" CodeBehind="documents.aspx.cs" Inherits="Escyug.Nosology.MVP.UI.WebApp.pages.documents" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .demo-list-three {
            width: 650px;
        }
    </style>
</asp:Content>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <span class="mdl-layout-title">Документы</span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="mdl-grid nos-content nos-docs">

        <ul class="demo-list-three mdl-list">
            <asp:ListView ID="docsList" runat="server" EnableViewState="true">

                <ItemTemplate>

                    <li class="mdl-list__item mdl-list__item--three-line">
                        <span class="mdl-list__item-primary-content">
                            <i class="material-icons mdl-list__item-avatar">person</i>
                            <span><%# Eval("Title") %></span>
                            <span class="mdl-list__item-text-body"><%# Eval("Description") %></span>
                        </span>
                        <span class="mdl-list__item-secondary-content">
                            <a class="mdl-list__item-secondary-action" href="'<%# Eval("Link") %>'"><i class="material-icons fa fa-download"></i></a>
                        </span>
                    </li>

                    <%--<div class="mdl-cell mdl-cell--10-col demo-graphs">
                        <a href=>
                            <i class=" content-icon"></i>
                        </a>
                    </div>--%>

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
            <li class="mdl-list__item mdl-list__item--three-line">
                <span class="mdl-list__item-primary-content">
                    <i class="material-icons mdl-list__item-avatar ">person</i>
                    <span>WAT</span>
                    <span class="mdl-list__item-text-body">WAT</span>
                </span>
                <span class="mdl-list__item-secondary-content">
                    <a class="mdl-list__item-secondary-action" href="#"><i class="material-icons fa fa-download"></i></a>
                </span>
            </li>

        </ul>

    </div>
</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
</asp:Content>
