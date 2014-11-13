<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayPal.Sample.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style type="text/css">
        body {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            -webkit-font-smoothing: antialiased;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
<div class="container-fluid">
    <div class="container">
        <%foreach(PayPal.Sample.Utilities.SampleCategory category in this.Categories) { %>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title"><%if (!string.IsNullOrEmpty(category.Href)) { %><a href="<%= category.Href %>" target="_blank"><%= category.Title %></a><%} else {%><%= category.Title %><%} %></h3>
            </div>

            <!-- List group -->
            <ul class="list-group">
                <%foreach(PayPal.Sample.Utilities.SampleItem item in category.Items) { %>
                <li class="list-group-item">
                    <div class="row">
                        <div class="col-md-9 "><h5><%= item.Title %><% if (!string.IsNullOrEmpty(item.Note)) { %> <small>(<%= item.Note %>)</small><%} %></h5></div>
                        <div class="col-md-3">
                            <a href="<%= item.ExecutePage %>" class="btn btn-primary pull-left" >Execute <i class="fa fa-play-circle-o"></i></a>
                            <%if (!string.IsNullOrEmpty(item.SourcePage)) { %>
                            <a href="<%= item.SourcePage %>" class="btn btn-default pull-right" >Source <i class="fa fa-file-code-o"></i></a>
                            <%} %>
                        </div>
                    </div>
                </li>
                <%} %>
            </ul>
        </div>
        <%} %>
    </div>
</div> <!-- /container -->
</asp:Content>