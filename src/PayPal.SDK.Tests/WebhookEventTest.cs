using System;
using System.Collections.Specialized;

using PayPal.Api;
using Xunit;


namespace PayPal.Testing
{
    
    public class WebhookEventTest
    {
        public static readonly string WebhookEventJson = 
            "{\"id\":\"8PT597110X687430LKGECATA\"," +
	        "\"create_time\":\"2013-06-25T21:41:28Z\"," +
	        "\"resource_type\":\"authorization\"," +
            "\"event_type\":\"PAYMENT.AUTHORIZATION.CREATED\"," +
	        "\"summary\":\"A payment authorization was created\"," +
	        "\"resource\":" + AuthorizationTest.AuthorizationJson + "," +
	        "\"links\":[{" +
		        "\"href\":\"https://api.sandbox.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA\"," +
		        "\"rel\":\"self\"," +
		        "\"method\":\"GET\"" +
	        "},{" +
		        "\"href\":\"https://api.sandbox.paypal.com/v1/notfications/webhooks-events/8PT597110X687430LKGECATA/resend\"," +
		        "\"rel\":\"resend\"," +
		        "\"method\":\"POST\"}]}";

        public static WebhookEvent GetWebhookEvent()
        {
            return JsonFormatter.ConvertFromJson<WebhookEvent>(WebhookEventJson);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventObjectTest()
        {
            var testObject = GetWebhookEvent();
            Assert.Equal("8PT597110X687430LKGECATA", testObject.id);
            Assert.Equal("2013-06-25T21:41:28Z", testObject.create_time);
            Assert.Equal("authorization", testObject.resource_type);
            Assert.Equal("PAYMENT.AUTHORIZATION.CREATED", testObject.event_type);
            Assert.Equal("A payment authorization was created", testObject.summary);
            Assert.NotNull(testObject.resource);
            Assert.NotNull(testObject.links);
            Assert.True(testObject.links.Count == 2);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventConvertToJsonTest()
        {
            Assert.False(GetWebhookEvent().ConvertToJson().Length == 0);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventToStringTest()
        {
            Assert.False(GetWebhookEvent().ToString().Length == 0);
        }

        [Fact(Skip="Ignore")]
        public void WebhookEventGetTest()
        {
            var webhookEventId = "8PT597110X687430LKGECATA";
            var webhookEvent = WebhookEvent.Get(TestingUtil.GetApiContext(), webhookEventId);
            Assert.NotNull(webhookEvent);
            Assert.Equal(webhookEventId, webhookEvent.id);
        }

        [Fact(Skip="Ignore")]
        public void WebhookEventGetAllTest()
        {
            var webhookEventList = WebhookEvent.List(TestingUtil.GetApiContext());
            Assert.NotNull(webhookEventList);
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventValidateSupportedAuthAlgorithm()
        {
            Assert.Equal("SHA1", WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA1withRSA"));
            Assert.Equal("SHA256", WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA256withRSA"));
            Assert.Equal("SHA512", WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA512withRSA"));
            Assert.Equal("MD5", WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("MD5withRSA"));
        }

        [Fact, Trait("Category", "Unit")]
        public void WebhookEventValidateNotSupportedAuthAlgorithm()
        {
            TestingUtil.AssertThrownException<AlgorithmNotSupportedException>(() => WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA1withDSA"));
            TestingUtil.AssertThrownException<AlgorithmNotSupportedException>(() => WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA256withDSA"));
            TestingUtil.AssertThrownException<AlgorithmNotSupportedException>(() => WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("SHA512withDSA"));
            TestingUtil.AssertThrownException<AlgorithmNotSupportedException>(() => WebhookEvent.ConvertAuthAlgorithmHeaderToHashAlgorithmName("MD5withDSA"));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidBodyTest()
        {
            var requestBody = "{\"id\":\"XX-XXX266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            Assert.False(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidSignatureTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "GsFK/0+kl1nrj4N0x36rzx6uRNOKrlCTLSfxcPdwP+zoBlo/8w+0F9fmoSJgnDDOiJ7jK6Y3xIAt4kxxH+RLbWv0v4G1+w3Cp2UIRQ61s7KVdW6tWhZtNkxZfgQXHeL5/0XrJ43091GM1VHOuagGB5ta9FPL/MYtamTP01vNBRO6H3O0tuYNDXDPTyzDtfS3vi638/Trvtr051CFxCCcdRQjDWL1eJyCVTPDEbzAqnKjEHCkasVvxVFIDBaIy28Ee4FXd9ynwVfqwG6sRSofCgVe7VhmyVb2WSlUyHHaoh0dgjijoqDZmwvl14KMAU80kt7eRUo6jvNKzIolJLByvg=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            Assert.False(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidTransmissionIdTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "XXX84410-f8d2-11e4-8bf3-77339302725b"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            Assert.False(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidAlgorithmTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA1withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            Assert.False(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventValidTest()
        {
            var requestBody = "{\"id\":\"WH-46G14697L5518741H-68W05709P43610212\",\"event_version\":\"1.0\",\"create_time\":\"2019-08-18T03:01:48.370Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for BRL 224.9 BRL\",\"resource\":{\"id\":\"3JR19021JJ481122E\",\"state\":\"completed\",\"amount\":{\"total\":\"224.90\",\"currency\":\"BRL\",\"details\":{\"subtotal\":\"224.90\"}},\"payment_mode\":\"INSTANT_TRANSFER\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"transaction_fee\":{\"value\":\"8.05\",\"currency\":\"BRL\"},\"invoice_number\":\"\",\"parent_payment\":\"PAY-9WY779141F709190ALVML7GA\",\"create_time\":\"2019-08-18T03:01:44Z\",\"update_time\":\"2019-08-18T03:01:44Z\",\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/3JR19021JJ481122E\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/3JR19021JJ481122E/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-9WY779141F709190ALVML7GA\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-46G14697L5518741H-68W05709P43610212\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-46G14697L5518741H-68W05709P43610212/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            Assert.True(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidTrustedCertificatePathTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var webhookId = "3RN13029J36659323";
            var apiContext = TestingUtil.GetApiContext();
            apiContext.Config[BaseConstants.TrustedCertificateLocation] = @"C:\invalid\path\to\trusted\certificate.cer";
            TestingUtil.AssertThrownException<PayPalException>(() => WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody, webhookId));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventUsingConfigWebhookIdTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var apiContext = TestingUtil.GetApiContext();
            apiContext.Config[BaseConstants.WebhookIdConfig] = "3RN13029J36659323";
            Assert.True(WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventMissingWebhookIdTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            var apiContext = TestingUtil.GetApiContext();
            TestingUtil.AssertThrownException<PayPalException>(() => WebhookEvent.ValidateReceivedEvent(apiContext, requestHeaders, requestBody));
        }

        [Fact, Trait("Category", "Functional")]
        public void WebhookEventValidateReceivedEventInvalidApiContextTest()
        {
            var requestBody = "{\"id\":\"WH-2W7266712B616591M-36507203HX6402335\",\"create_time\":\"2019-05-28T01:28:46Z\",\"resource_type\":\"sale\",\"event_type\":\"PAYMENT.SALE.COMPLETED\",\"summary\":\"Payment completed for $ 20.0 USD\",\"resource\":{\"id\":\"7DW85331GX749735N\",\"create_time\":\"2015-05-12T18:13:18Z\",\"update_time\":\"2015-05-12T18:13:36Z\",\"amount\":{\"total\":\"20.00\",\"currency\":\"USD\"},\"payment_mode\":\"INSTANT_TRANSFER\",\"state\":\"completed\",\"protection_eligibility\":\"ELIGIBLE\",\"protection_eligibility_type\":\"ITEM_NOT_RECEIVED_ELIGIBLE,UNAUTHORIZED_PAYMENT_ELIGIBLE\",\"parent_payment\":\"PAY-1A142943SV880364LKVJEFPQ\",\"transaction_fee\":{\"value\":\"0.88\",\"currency\":\"USD\"},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/sale/7DW85331GX749735N/refund\",\"rel\":\"refund\",\"method\":\"POST\"},{\"href\":\"https://api.sandbox.paypal.com/v1/payments/payment/PAY-1A142943SV880364LKVJEFPQ\",\"rel\":\"parent_payment\",\"method\":\"GET\"}]},\"links\":[{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335\",\"rel\":\"self\",\"method\":\"GET\"},{\"href\":\"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2W7266712B616591M-36507203HX6402335/resend\",\"rel\":\"resend\",\"method\":\"POST\"}]}";
            var requestHeaders = new NameValueCollection
            {
                {"Paypal-Cert-Url", "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-1d93a270"},
                {"Paypal-Auth-Version", "v2"},
                {"Paypal-Transmission-Sig", "vSOIQFIZQHv8G2vpbOpD/4fSC4/MYhdHyv+AmgJyeJQq6q5avWyHIe/zL6qO5hle192HSqKbYveLoFXGJun2od2zXN3Q45VBXwdX3woXYGaNq532flAtiYin+tQ/0pNwRDsVIufCxa3a8HskaXy+YEfXNnwCSL287esD3HgOHmuAs0mYKQdbR4e8Evk8XOOQaZzGeV7GNXXz19gzzvyHbsbHmDz5VoRl9so5OoHqvnc5RtgjZfG8KA9lXh2MTPSbtdTLQb9ikKYnOGM+FasFMxk5stJisgmxaefpO9Q1qm3rCjaJ29aAOyDNr3Q7WkeN3w4bSXtFMwyRBOF28pJg9g=="},
                {"Paypal-Transmission-Id", "f0192050-80e7-11e9-a416-b554c1da3649"},
                {"Paypal-Auth-Algo", "SHA256withRSA"},
                {"Paypal-Transmission-Time", "2019-05-28T01:28:46Z"}
            };
            TestingUtil.AssertThrownException<ArgumentNullException>(() => WebhookEvent.ValidateReceivedEvent(null, requestHeaders, requestBody));
        }
    }
}
