<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PayPal.Sample.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        li.list-group-item:hover {
            background-color: #EEE;
        }
        @media (max-width: 992px) {
            .jumbotron {
                background: white;
                color: #000;
            }
            .footer {
                    background: #428bca;
                    color: #000;
                }
            .footer-div a {
                color: #000;
            }
            .logo {
                position: relative;
            }
            #leftNavigation {
                visibility: hidden;
            }
        }
        @media (min-width: 992px) {
            .jumbotron {
                background: -webkit-linear-gradient(-9deg, white 30%, #428bca 25%);
                color: #EEE;
            }
            .footer-div a {
                color: #EEE;
                text-decoration: none;
            }
            .logo {
                position: fixed;
                top: 40px;
            }
        }
        html {
            position: relative;
            min-height: 100%;
        }
        body {
            /* Margin bottom by footer height */
            margin-bottom: 60px;
        }
        .footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            min-height: 60px;
            background: -webkit-linear-gradient(-9deg, #428bca 70%, white 25%);
        }
        .footer-links, .footer-links li {
            display: inline-block;
            font-size: 110%;
            padding-left: 0px;
            padding-right: 0px;
        }
        .footer-links li {
            padding-top: 5px;
            padding-left: 5px;
        }
        .fixed {
            position: fixed;
        }
        .nav a {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <!-- Main component for a primary marketing message or call to action -->
    <div class="jumbotron">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 pull-left">
                    <img src="images/pp_v_rgb.png" class="logo" height="200" />
                </div>
                <div class="col-md-8 pull-right">
                    <h1>PayPal .NET SDK Samples</h1>
                    <p>These examples have been provided to show developers how to leverage the PayPal SDK in a .NET application.</p>
                    <div class="footer-div">
                        <ul class="footer-links">
                            <li>
                                <a href="https://github.com/paypal/PayPal-NET-SDK" target="_blank"><i class="fa fa-github"></i> GitHub</a></li>
                            <li>
                                <a href="https://developer.paypal.com/webapps/developer/docs/api/" target="_blank"><i class="fa fa-book"></i> PayPal REST API Reference</a>
                            </li>
                            <li>
                                <a href="https://github.com/paypal/PayPal-NET-SDK/issues" target="_blank"><i class="fa fa-exclamation-triangle"></i> Report Issues </a>
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3 ">
                    <div class="row-fluid fixed col-md-3" id="leftNavigation" role="navigation">
                        <ul class="nav nav-stacked">
                            <%foreach(PayPal.Sample.Utilities.SampleCategory category in this.Categories) { %>
                            <li><a href="#<%= category.Id %>"><%= category.Title %></a></li>
                            <%} %>
                        </ul>
                    </div>
                </div>
                <div class="col-md-9">
                    <%foreach(PayPal.Sample.Utilities.SampleCategory category in this.Categories) { %>
                    <div class="panel panel-primary" id="<%= category.Id %>">
                        <div class="panel-heading">
                            <h3 class="panel-title"><%if (!string.IsNullOrEmpty(category.Href)) { %><a href="<%= category.Href %>" target="_blank"><%= category.Title %></a><%} else {%><%= category.Title %><%} %></h3>
                        </div>

                        <!-- List group -->
                        <ul class="list-group">
                            <%foreach(PayPal.Sample.Utilities.SampleItem item in category.Items) { %>
                            <li class="list-group-item">
                                <div class="row">
                                    <div class="col-md-8 "><h5><%= item.Title %><% if (!string.IsNullOrEmpty(item.Note)) { %> <small>(<%= item.Note %>)</small><%} %></h5></div>
                                    <div class="col-md-4">
                                        <a href="<%= item.ExecutePage %>" class="btn btn-primary pull-left" >Try It <i class="fa fa-play-circle-o"></i></a>
                                        <%if (item.HasSourcePage) { %>
                                        <a href="Source/<%= item.ExecutePage %>.html" class="btn btn-default pull-right" >View Source <i class="fa fa-file-code-o"></i></a>
                                        <%} %>
                                    </div>
                                </div>
                            </li>
                            <%} %>
                        </ul>
                    </div>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</asp:Content>