AzureServiceManagementRestApi
=============================

Sample demonstrating the use of Azure Service Management REST Api's from C#.

To run the unit tests, open BaseApiTests.cs in the ServiceManagement.Tests project and add your own Azure subscription Id and management certificate.

        [TestInitialize]
        public virtual void Initialize()
        {
            string subscriptionId = "[YOUR SUBSCRIPTION ID]";
            string certThumbprint = "[YOUR MANAGEMENT CERT THUMBPRINT]";
            ...


See my blog post for more information.

http://rickrainey.com/2013/10/17/calling-azure-service-management-rest-apis-from-c/

-Rick
