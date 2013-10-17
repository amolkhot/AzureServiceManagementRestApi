using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceManagement.Tests;
using ServiceManagement.Locations.Models;

namespace ServiceManagement.CloudServices.Tests
{
    [TestClass]
    public class CloudServicesApiTests : BaseApiTests
    {
        private CloudServicesApi cloudServicesApi = null;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            cloudServicesApi = new CloudServicesApi(this.subscription);
        }

        [TestMethod]
        public override void VerifyServiceManagementUri()
        {
            base.VerifyServiceManagementUri();
            Console.WriteLine(this.cloudServicesApi.ServiceManagementUri);

            Assert.AreEqual(
                this.cloudServicesApi.ServiceManagementUri.ToString(),
                string.Format("{0}/services/hostedservices",
                    this.baseApi.ServiceManagementUri.ToString()));
        }

        [TestMethod]
        public void CreateAndDelete()
        {
            // Set name of new cloud service.
            var name = Guid.NewGuid().ToString();
            
            // Set location of new cloud service to first US location 
            // found available in the current subscription.
            var locationsApi = new Locations.LocationsApi(this.subscription);
            var locations = locationsApi.List();
            string location = null;
            foreach (DataCenterLocation dcLocation in locations)
            {
                if (dcLocation.Name.EndsWith(" US"))
                {
                    location = dcLocation.Name;
                    break;
                }
            }
            Assert.IsFalse(string.IsNullOrEmpty(location));

            // Create a cloud service.
            Console.WriteLine("Creating cloud service '{0}' in data center '{1}'.", 
                name, location);
            var cloudServiceUri = this.cloudServicesApi.Create(name, location);

            Console.WriteLine("Cloud service created.");
            Console.WriteLine(cloudServiceUri);

            // Delete the same cloud service.
            this.cloudServicesApi.Delete(name);

            Console.WriteLine("Cloud service deleted.");
        }
    }
}
