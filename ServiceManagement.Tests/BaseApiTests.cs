using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceManagement.Tests
{
    [TestClass]
    public class BaseApiTests
    {
        protected AzureSubscription subscription = null;
        protected BaseApi baseApi = null;

        [TestInitialize]
        public virtual void Initialize()
        {
            string subscriptionId = "[YOUR SUBSCRIPTION ID]";
            string certThumbprint = "[YOUR MANAGEMENT CERT THUMBPRINT]";

            // Instantiate the subscription
            subscription = new AzureSubscription(subscriptionId, certThumbprint);

            // Instantiate a base service management class
            baseApi = new BaseApi(subscription);
        }  
      
        [TestMethod]
        public virtual void VerifyServiceManagementUri()
        {
            Console.WriteLine(baseApi.ServiceManagementUri);

            Assert.IsTrue(baseApi.ServiceManagementUri.IsBaseOf(
                new Uri("https://management.core.windows.net")));
        }

        [TestMethod]
        public void GetRequestHandler()
        {
            // Verify the management certificate for this instance is
            // in the client certificates collection.
            Assert.IsTrue(baseApi.RequestHandler.ClientCertificates.Contains(
                this.subscription.ManagementCertificate));
        }

        [TestMethod]
        public void GetHttpClientInstance()
        {
            var httpClient = baseApi.HttpClientInstance;

            // Verify the base address is the same as the service management Uri
            // for this instance.
            Assert.IsTrue(httpClient.BaseAddress == baseApi.ServiceManagementUri);
        }
    }
}
