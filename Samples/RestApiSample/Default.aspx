<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RESTAPISample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PayPal REST API SDK for .NET Samples</title>
    <style type="text/css">
        body
        {
        	font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            -webkit-font-smoothing: antialiased;
            background: #f2f2f2;
            font-size: 100%;
            color: #777;
        }
        .banner
        {
        	font-weight: bold;
        	vertical-align: middle;
        	font-size: 135%;
        	padding: 50px 0px 25px 10px;
        }
        .imagelink
        {
            padding: 5px 0px 5px 28px;
        }
        .execute
        {
            background: url(  'Images/play_button.png' ) no-repeat left top;
        }
        .source
        {
            background: url(  'Images/edt-format-source-button.png' ) no-repeat left top;
        }
        .header
        {
		    font-weight: bold;
		    color: #0079C1;
		    background-color: #fff;
		    font-size: 135%;
	    }
	    .header td
	     {
		    padding: 25px 0px 10px 10px;
	    }
	    td 
	    {
	    	padding: 5px 5px 5px 15px;
	    }
	    img
	    {
	    	vertical-align: middle;
	    	border-style: none;
	    }
    </style>
</head>
<body>
    <center>
        <div class="banner"><a href="https://developer.paypal.com/webapps/developer/docs/api/"><img alt="PayPal" src="Images/logo_paypal_106x29.png" /></a>  REST API SDK for .NET Samples</div>
    </center>
    
    <table cellspacing="5" width="85%" align="center">
        <tbody>
            <tr valign="top" class="header">
				<td colspan="3">Payments</td>
			</tr>
            <tr valign="top">
                <td>
                    Direct credit card payments
                </td>
                <td>
                    <a href="PaymentWithCreditCard.aspx" class="execute imagelink">Execute</a>
                </td>
                <td width="40%">
                    <a href="Source/PaymentWithCreditCard.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    PayPal account payments
                </td>
                <td>
                    <a href="PaymentWithPayPal.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/PaymentWithPayPal.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Stored credit card payments
                </td>
                <td>
                    <a href="PaymentWithSavedCard.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/PaymentWithSavedCard.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Get payment details
                </td>
                <td>
                    <a href="GetPayment.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetPayment.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Get payment history
                </td>
                <td>
                    <a href="GetPaymentHistory.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetPaymentHistory.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Run Order Sample</td>
                <td>
                    <a href="OrderSample.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top" class="header">
				<td colspan="3">Sale</td>
			</tr>
            <tr>
                <td>
                    Get sale payment details
                </td>
                <td>
                    <a href="GetSale.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetSale.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Refund a sale payment
                </td>
                <td>
                    <a href="SaleRefund.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/SaleRefund.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr valign="top" class="header">
				<td colspan="3">Refund</td>
			</tr>
            <tr>
                <td>
                    Get refund details
                </td>
                <td>
                    <a href="GetRefund.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetRefund.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr valign="top" class='header'>
				<td colspan="3">Vault</td>
			</tr>
            <tr>
                <td>
                    Save a credit card
                </td>
                <td>
                    <a href="CreateCreditCard.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/CreateCreditCard.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Get credit card details
                </td>
                <td>
                    <a href="GetCreditCard.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetCreditCard.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Delete a credit card 
                </td>
                <td>
                    <a href="DeleteCreditCard.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/DeleteCreditCard.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr valign="top" class='header'>
				<td colspan="3">Authorization</td>
			</tr>
            <tr>
                <td>
                    Get an authorized payment details
                </td>
                <td>
                    <a href="GetAuthorization.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetAuthorization.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Capture an authorized payment
                </td>
                <td>
                    <a href="AuthorizationCapture.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/AuthorizationCapture.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Void an authorized payment
                </td>
                <td>
                    <a href="AuthorizationVoid.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/AuthorizationVoid.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    Reauthorize an authorized payment
                </td>
                <td>
                    <a href="Reauthorization.aspx" class="execute imagelink">Execute</a>
                </td>
                <td width="30%">
                    <a href="Source/Reauthorization.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr valign="top" class="header">
				<td colspan="3">Capture</td>
			</tr>
            <tr>
                <td>
                    Get captured payment details
                </td>
                <td>
                    <a href="GetCapture.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/GetCapture.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr>
                <td>
                    Refund captured payment
                </td>
                <td>
                    <a href="RefundCapture.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    <a href="Source/RefundCapture.aspx.html" class="source imagelink">Source</a>
                </td>
            </tr>
            <tr class="header">
				<td colspan="3">Payment Experience</td>
			</tr>
            <tr>
                <td>
                    Create a new web experience profile</td>
                <td>
                    <a href="PaymentExperienceCreate.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Retrieve a web experience profile</td>
                <td>
                    <a href="PaymentExperienceGet.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    List web experience profiles</td>
                <td>
                    <a href="PaymentExperienceGetList.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Update a web experience profile</td>
                <td>
                    <a href="PaymentExperienceUpdate.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Partially update a web experience profile</td>
                <td>
                    <a href="PaymentExperiencePartialUpdate.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Delete a web experience profile</td>
                <td>
                    <a href="PaymentExperienceDelete.aspx" class="execute imagelink">Execute</a>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
</body>
</html>
