using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceManagement.Tests;
using ServiceManagement.Locations.Models;

namespace ServiceManagement.Locations.Tests
{
    [TestClass]
    public class LocationsApiTests : BaseApiTests
    {
        private LocationsApi locationsApi = null;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            locationsApi = new LocationsApi(this.subscription);
        }

        [TestMethod]
        public override void VerifyServiceManagementUri()
        {
            base.VerifyServiceManagementUri();

            Console.WriteLine(this.locationsApi.ServiceManagementUri);

            Assert.AreEqual(
                this.locationsApi.ServiceManagementUri.ToString(),
                string.Format("{0}/locations", this.baseApi.ServiceManagementUri.ToString()));
        }

        [TestMethod]
        public void GetLocations()
        {
            var locations = this.locationsApi.List();

            // Verify we got at least one location.
            Assert.IsTrue(locations.Count >= 1);

            // Print out the locations collection.
            foreach (DataCenterLocation loc in locations)
            {

                // Verify the name exists.
                Assert.IsFalse(string.IsNullOrEmpty(loc.Name));

                Console.WriteLine("Name: {0}", loc.Name);
                Console.WriteLine("Display Name: {0}", loc.DisplayName);
                Console.WriteLine("Services:");
                foreach (string service in loc.AvailableServices)
                {
                    // Verify the service exists.
                    Assert.IsFalse(string.IsNullOrEmpty(service));

                    Console.WriteLine("\t{0}", service);
                }
                Console.WriteLine();
            }

        }
    }
}
