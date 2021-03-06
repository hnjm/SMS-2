﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="SMSServer.Web.Account.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/account.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="tools">
        <div class="cont_tools" style="width: 90%">

            <a href="#" id="add" class="button button-rounded button-tiny button-primary">添加</a>
            <a href="#" id="edit" class="button button-rounded button-tiny  button-primary">修改</a>
            <a href="#" id="delete" class="button button-rounded button-tiny  button-primary">删除</a>
            <%--  <a href="#" id="clear" class="button button-rounded button-tiny  button-primary">清空</a>
            --%>
            <a href="#" id="changepwd" class="button button-rounded button-tiny  button-action">修改密码</a>
            <a href="#" id="unuseful" class="button button-rounded button-tiny  button-action">设置禁用</a>
            <a href="#" id="useful" class="button button-rounded button-tiny  button-action">设置正常</a>

        </div>

    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>
</asp:Content>
