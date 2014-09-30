using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayPal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayPal.Api.Payments;

namespace RestApiSDKUnitTest
{
    public class UnitTestUtil
    {
        public static readonly string ClientId = "EBWKjlELKMYqRNQ6sYvFo64FtaRLRR5BdHEESmha49TM";
        public static readonly string ClientSecret = "EO422dn3gQLgDbuwqTjzrFgFtaRLRR5BdHEESmha49TM";

        public static Dictionary<string, string> GetConfig()
        {
            var config = new Dictionary<string, string>();
            config["endpoint"] = "https://api.sandbox.paypal.com";
            config["connectionTimeout"] = "360000";
            config["requestRetries"] = "1";
            return config;
        }

        private static string GetAccessToken()
        {
            var oauth = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig());
            return oauth.GetAccessToken();
        }

        public static APIContext GetApiContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }

        /// <summary>
        /// Invokes the specified action and checks whether or not the specified exception type is thrown. This allows for unit tests that more accurately
        /// capture when specific exceptions should be thrown.
        /// </summary>
        /// <typeparam name="T">The type of exception that is expected to be thrown from the given action.</typeparam>
        /// <param name="action">The action to be invoked.</param>
        public static void AssertThrownException<T>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                if (typeof(T).Equals(ex.GetType()))
                {
                    return;
                }
                Assert.Fail("Expected " + typeof(T) + " to be thrown, but " + ex.GetType() + " was thrown instead.");
            }
            Assert.Fail("Expected " + typeof(T) + " to be thrown, but no exception was thrown.");
        }

        /// <summary>
        /// Gets a fake CreditCard object for use in unit tests.
        /// </summary>
        /// <returns></returns>
        public static CreditCard GetCreditCard()
        {
            CreditCard card = new CreditCard();
            card.cvv2 = 962;
            card.expire_month = 01;
            card.expire_year = 2015;
            card.first_name = "John";
            card.last_name = "Doe";
            card.number = "4825854086744369";
            card.type = "visa";
            card.billing_address = UnitTestUtil.GetAddress();
            return card;
        }

        public static CreditCardToken GetCreditCardToken()
        {
            CreditCardToken cardToken = new CreditCardToken();
            cardToken.credit_card_id = "CARD-8PV12506MG6587946KEBHH4A";
            cardToken.payer_id = "009";
            cardToken.expire_month = 10;
            cardToken.expire_year = 2015;
            return cardToken;
        }

        /// <summary>
        /// Gets an fake Address object for use in unit tests.
        /// </summary>
        /// <returns></returns>
        public static Address GetAddress()
        {
            Address add = new Address();
            add.line1 = "2211";
            add.line2 = "N 1st St";
            add.city = "San Jose";
            add.phone = "408-456-0392";
            add.postal_code = "95131";
            add.state = "California";
            add.country_code = "US";
            return add;
        }

        public static List<Links> GetLinksList()
        {
            Links lnk = new Links();
            lnk.href = "http://www.paypal.com";
            lnk.method = "POST";
            lnk.rel = "authorize";
            List<Links> lnks = new List<Links>();
            lnks.Add(lnk);
            return lnks;
        }

        public static Details GetDetails()
        {
            Details detail = new Details();
            detail.tax = "15";
            detail.fee = "2";
            detail.shipping = "10";
            detail.subtotal = "75";
            return detail;
        }

        public static Amount GetAmount()
        {
            Amount amt = new Amount();
            amt.currency = "USD";
            amt.details = GetDetails();
            amt.total = "100";
            return amt;
        }

        public static Authorization GetAuthorization()
        {
            Authorization authorize = new Authorization();
            authorize.amount = GetAmount();
            authorize.create_time = "2013-01-15T15:10:05.123Z";
            authorize.id = "007";
            authorize.parent_payment = "1000";
            authorize.state = "Authorized";
            authorize.links = GetLinksList();
            return authorize;
        }

        public static Capture GetCapture()
        {
            Capture cap = new Capture();
            cap.amount = GetAmount();
            cap.create_time = "2013-01-15T15:10:05.123Z";
            cap.state = "Authorized";
            cap.parent_payment = "1000";
            cap.links = GetLinksList();
            cap.id = "001";
            return cap;
        }

        public static PayerInfo GetPayerInfo()
        {
            PayerInfo info = new PayerInfo();
            info.first_name = "Joe";
            info.last_name = "Shopper";
            info.email = "Joe.Shopper@email.com";
            info.payer_id = "100";
            info.phone = "12345";
            info.shipping_address = GetShippingAddress();
            return info;
        }

        public static Payer GetPayer()
        {
            var fundingInstrumentList = new List<FundingInstrument>();
            fundingInstrumentList.Add(UnitTestUtil.GetFundingInstrument());
            var pay = new Payer();
            pay.funding_instruments = fundingInstrumentList;
            pay.payer_info = UnitTestUtil.GetPayerInfo();
            pay.payment_method = "credit_card";
            return pay;
        }

        public static ShippingAddress GetShippingAddress()
        {
            var shipping = new ShippingAddress();
            shipping.recipient_name = "PayPalUser";
            return shipping;
        }

        public static Item GetItem()
        {
            Item itm = new Item();
            itm.name = "Item Name";
            itm.currency = "USD";
            itm.price = "10.50";
            itm.quantity = "5";
            itm.sku = "Sku";
            return itm;
        }

        public static Phone GetPhone()
        {
            var phone = new Phone();
            phone.national_number = "7162981822";
            phone.country_code = "1";
            return phone;
        }

        public static Payee GetPayee()
        {
            Payee pay = new Payee();
            pay.merchant_id = "100";
            pay.email = "paypaluser@email.com";
            pay.phone = UnitTestUtil.GetPhone();
            return pay;
        }

        public static Links GetLinks()
        {
            Links link = new Links();
            link.href = "http://paypal.com/";
            link.method = "POST";
            link.rel = "authorize";
            return link;
        }

        public static RedirectUrls GetRedirectUrls()
        {
            RedirectUrls urls = new RedirectUrls();
            urls.cancel_url = "http://ebay.com/";
            urls.return_url = "http://paypal.com/";
            return urls;
        }

        public static Refund GetRefund()
        {
            var links = new List<Links>();
            links.Add(UnitTestUtil.GetLinks());
            var refund = new Refund();
            refund.capture_id = "101";
            refund.id = "102";
            refund.parent_payment = "103";
            refund.sale_id = "104";
            refund.state = "Approved";
            refund.amount = GetAmount();
            refund.create_time = "2013-01-17T18:12:02.347Z";
            refund.links = links;
            return refund;
        }

        public static Sale GetSale()
        {
            var links = new List<Links>();
            links.Add(UnitTestUtil.GetLinks());
            var sale = new Sale();
            sale.amount = GetAmount();
            sale.id = "102";
            sale.parent_payment = "103";
            sale.state = "Approved";
            sale.create_time = "2013-01-17T18:12:02.347Z";
            sale.links = links;
            return sale;
        }

        public static RelatedResources GetRelatedResources()
        {
            RelatedResources resources = new RelatedResources();
            resources.authorization = GetAuthorization();
            resources.capture = GetCapture();
            resources.refund = UnitTestUtil.GetRefund();
            resources.sale = UnitTestUtil.GetSale();
            return resources;
        }

        public static ItemList GetItemList()
        {
            List<Item> items = new List<Item>();
            items.Add(UnitTestUtil.GetItem());
            items.Add(UnitTestUtil.GetItem());
            ItemList itemList = new ItemList();
            itemList.items = items;
            itemList.shipping_address = UnitTestUtil.GetShippingAddress();
            return itemList;
        }

        public static FundingInstrument GetFundingInstrument()
        {
            FundingInstrument instrument = new FundingInstrument();
            instrument.credit_card = UnitTestUtil.CreateCreditCard();
            instrument.credit_card_token = UnitTestUtil.GetCreditCardToken();
            return instrument;
        }

        public static PaymentHistory GetPaymentHistory()
        {
            List<Payment> paymentList = new List<Payment>();
            paymentList.Add(UnitTestUtil.CreatePaymentForSale());
            PaymentHistory history = new PaymentHistory();
            history.count = 1;
            history.payments = paymentList;
            history.next_id = "1";
            return history;
        }

        public static Payment GetPaymentAuthorization()
        {
            return UnitTestUtil.GetPayment("authorize");
        }

        public static Payment GetPaymentForSale()
        {
            return UnitTestUtil.GetPayment("sale");
        }

        private static Payment GetPayment(string intent)
        {
            var payment = new Payment();
            payment.intent = intent;
            CreditCard card = UnitTestUtil.GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transactionList = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = UnitTestUtil.GetAmount();
            transactionList.Add(trans);
            payment.transactions = transactionList;
            payment.payer = payer;
            return payment;
        }

        public static Payment GetFuturePayment()
        {
            FuturePayment pay = new FuturePayment();
            pay.intent = "sale";
            CreditCard card = GetCreditCard();
            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = card;
            fundingInstruments.Add(fundingInstrument);
            Payer payer = new Payer();
            payer.payment_method = "credit_card";
            payer.funding_instruments = fundingInstruments;
            List<Transaction> transactionList = new List<Transaction>();
            Transaction trans = new Transaction();
            trans.amount = GetAmount();
            transactionList.Add(trans);
            pay.transactions = transactionList;
            pay.payer = payer;
            Payment paymnt = pay.Create(UnitTestUtil.GetApiContext());
            return paymnt;
        }

        public static PaymentExecution GetPaymentExecution()
        {
            List<Transactions> transactions = new List<Transactions>();
            transactions.Add(GetTransactions());
            PaymentExecution execution = new PaymentExecution();
            execution.payer_id = GetPayerInfo().payer_id;
            execution.transactions = transactions;
            return execution;
        }

        public static Transaction GetTransaction()
        {
            var items = UnitTestUtil.GetItemList();
            var relResources = new List<RelatedResources>();
            relResources.Add(UnitTestUtil.GetRelatedResources());
            var transaction = new Transaction();
            transaction.amount = UnitTestUtil.GetAmount();
            transaction.payee = UnitTestUtil.GetPayee();
            transaction.description = "Test Description";
            transaction.item_list = items;
            transaction.related_resources = relResources;
            return transaction;
        }

        public static Transactions GetTransactions()
        {
            Transactions transaction = new Transactions();
            transaction.amount = GetAmount();
            return transaction;
        }

        public static Payment CreatePaymentAuthorization()
        {
            return UnitTestUtil.GetPaymentAuthorization().Create(UnitTestUtil.GetApiContext());
        }

        public static Payment CreatePaymentForSale()
        {
            return UnitTestUtil.GetPaymentForSale().Create(UnitTestUtil.GetApiContext());
        }

        public static CreditCard CreateCreditCard()
        {
            return UnitTestUtil.GetCreditCard().Create(UnitTestUtil.GetApiContext());
        }
    }
}
