<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="PayPal.Sample.Response" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style type="text/css">
        body {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            -webkit-font-smoothing: antialiased;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <table style="border-collapse: collapse">
        <tr>
            <td><a href="../">Back</a><br/>
            <%if (RedirectURL != null) {%><a href= '<%=RedirectURL%>'><%if (RedirectURLText != null){%><%=RedirectURLText%><%}else{%>Redirect to PayPal to approve the payment<%}%></a><br /><%}%></td>
		</tr>
		<tr class="header">
			<td>Request</td>
		</tr>
		<tr>
			<td>
			    <pre id="request"><%if (RequestMessage != null){%><%=RequestMessage%><%}else{%>
No payload for this request
<%}%></pre>
            </td>
		</tr>
		<tr class="header">
			<td><%if (ResponseTitle != null){%><%=ResponseTitle%><%} else {%>Response<%}%></td>
		</tr>
		<tr>
			<td>
			    <pre id="response">
<%if (ResponseMessage != null){%><%=ResponseMessage%><%} else if (ErrorMessage != null){%><%=ErrorMessage%><%}%>
</pre>
			</td>
		</tr>
		<tr>
			<td>
                <br />
                <a href="../">Back</a>
            </td>
		</tr>
	</table>        
    <br />
    <br />
</asp:Content>