<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="RESTAPISample.Response" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="assets/style.css" rel="stylesheet" type="text/css" />
    <title>Response Page</title>
    
</head>
<body>
    <center>
        <div class="banner"><a href="https://developer.paypal.com/webapps/developer/docs/api/"><img alt="PayPal" src="Assets/logo_paypal_106x29.png" /></a>  REST API SDK for .NET Samples</div>
    </center>
    <form id="form1" runat="server">
         <table style="border-collapse: collapse" align="center" cellspacing="5" width="85%">
		<tr>
		    <td valign="top"><a href="../">Back</a><br/>
		  <%if (RedirectURL != null) {%><a href= '<%=RedirectURL%>'><%if (RedirectURLText != null){%><%=RedirectURLText%><%}else{%>Redirect to PayPal to approve the payment<%}%></a><br /><%}%></td>
		</tr>
		<tr class="header">
			<td valign="top">Request</td>
		</tr>
		<tr>
			<td valign="top">
			    <pre id="request"><%if (RequestMessage != null){%><%=RequestMessage%><%}else{%>
No payload for this request
<%}%></pre>
            </td>
		</tr>
		<tr class="header">
			<td valign="top"><%if (ResponseTitle != null){%><%=ResponseTitle%><%} else {%>Response<%}%></td>
		</tr>
		<tr>
			<td valign="top">
			    <pre id="response">
<%if (ResponseMessage != null){%><%=ResponseMessage%><%} else if (ErrorMessage != null){%><%=ErrorMessage%><%}%>
</pre>
			</td>
		</tr>
		<tr>
			<td valign="top">
                <br />
                <a href="../">Back</a>
            </td>
		</tr>
	</table>        
        <br />
        <br />
    </form>
</body>
</html>
