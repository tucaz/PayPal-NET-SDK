<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="PayPal.Sample.Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="row header">
        <div class="col-md-3 pull-left">
            <br />
            <a href="Default.aspx"><h3>&lArr; Back to Samples</h3></a>
            <br />
            <br />
        </div>
        <br />
        <div class="col-md-2 pull-right">
            <img  src="../images/pp_v_rgb.png" height="70" />
        </div>
    </div>
    <div class="clearfix visible-xs-block"></div>
    <br />
    <!--
    <div class="row">
        <div class="col-md-2 pull-left"><a href="Default.aspx"><h4>&lArr; Back to Samples</h4></a><br /><br /></div>
        <div class="col-md-1 pull-right"><img  src="images/pp_v_rgb.png" height="70" /></div>
    </div>
    <div class="clearfix visible-xs-block"></div>-->
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
        <% if (this.Flow != null)
           {
               for (int i = 0; i < this.Flow.Items.Count; i++)
               {%>
        <% var step = "step-" + (i + 1); %>
        <% var heading = "heading-" + (i + 1); %>
        <% var prettyRequest = "<pre class=\"prettyprint\">" + this.FormatPayloadText(this.Flow.Items[i].Request, true) + "</pre>"; %>
        <% var prettyResponse = "<pre class=\"prettyprint " + (this.Flow.Items[i].IsErrorResponse ? "error" : "") + "\">" + this.FormatPayloadText(this.Flow.Items[i].Response, false) + "</pre>"; %>
        <div class="panel panel-default">
            <div class="panel-heading <% if (this.Flow.Items[i].IsErrorResponse)
                                         { %>error<%}%>" role="tab">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#<%= step%>" aria-expanded="false" aria-controls="<%= step%>"><%= i + 1%>. <%= this.Flow.Items[i].Title%><% if (this.Flow.Items[i].IsErrorResponse)
                                                                                                                                                                                           { %> (Failed)<% } %></a>
                </h4>
            </div>
            <div id="<%= step%>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="<%= heading%>">
                <div class="panel-body">
                    <%if (!string.IsNullOrEmpty(this.Flow.Items[i].Description))
                      { %>
                    <div><%= this.Flow.Items[i].Description%></div>
                    <% } %>

                    <%if (!string.IsNullOrEmpty(this.Flow.Items[i].RedirectUrl))
                      { %>
                    <%if (this.Flow.Items[i].IsRedirectApproved)
                      {%>
                    <div class="success"><i class="fa fa-check-circle"></i> <%= this.Flow.Items[i].RedirectUrlText%></div>
                    <%}
                      else
                      {%>
                    <div><a href="<%= this.Flow.Items[i].RedirectUrl%>"><i class="fa fa-paypal"></i> <%= this.Flow.Items[i].RedirectUrlText%></a></div>
                    <%} %>
                    <% } %>

                    <!-- Large view -->
                    <div class="row hidden-xs hidden-sm hidden-md">
                        <div class="col-md-6">
                            <h4>Request</h4>
                            <%= prettyRequest%>
                        </div>
                        <div class="col-md-6">
                            <h4 class="<% if (this.Flow.Items[i].IsErrorResponse)
                                          { %>error<% } %>">Response</h4>
                            <% foreach (var message in this.Flow.Items[i].Messages)
                               { %>
                            <div class ="flow-message <%= this.GetMessageClass(message)%>"><%= this.GetMessageWithMarkup(message)%></div>
                            <%} %>
                            <%= prettyResponse%>
                            <% if (!string.IsNullOrEmpty(this.Flow.Items[i].ImagePath))
                               {
                                   this.SampleImage.ImageUrl = this.Flow.Items[i].ImagePath;
                                   %>
                            <div><asp:Image ID="SampleImage" runat="server"/></div>
                            <% }%>
                        </div>
                    </div>
                    <!-- Small view -->
                    <div class="hidden-lg">
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" ><a href="#<%= step%>-request" role="tab" data-toggle="tab">Request</a></li>
                            <li role="presentation" class="active"><a href="#<%= step%>-response" role="tab" data-toggle="tab">Response</a></li>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane" id="<%= step%>-request">
                                <%= prettyRequest%>
                            </div>
                            <div role="tabpanel" class="tab-pane active" id="<%= step%>-response">
                                <% foreach (var message in this.Flow.Items[i].Messages)
                                   { %>
                                <div class ="flow-message <%= this.GetMessageClass(message)%>"><%= this.GetMessageWithMarkup(message)%></div>
                                <%} %>
                                <%= prettyResponse%>
                                <% if (!string.IsNullOrEmpty(this.Flow.Items[i].ImagePath))
                                   {
                                       this.SampleImage.ImageUrl = this.Flow.Items[i].ImagePath;
                                       %>
                                <div><asp:Image ID="Image1" runat="server"/></div>
                                <% }%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%}} %>
    </div>
</asp:Content>