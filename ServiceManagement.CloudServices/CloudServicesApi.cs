using ServiceManagement.CloudServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManagement.CloudServices
{
    public class CloudServicesApi : BaseApi
    {
        public CloudServicesApi(AzureSubscription Subscription)
            : base(Subscription)
        { }

        public override Uri ServiceManagementUri
        {
            get
            {
                return new Uri(string.Format("{0}/services/hostedservices",
                    base.ServiceManagementUri));
            }
        }

        public Uri Create(string ServiceName, string Location)
        {
            // Create the request body
            byte[] serviceNameBytes = System.Text.Encoding.UTF8.GetBytes(ServiceName);
            CreateHostedService requestBody = new CreateHostedService()
            {
                ServiceName = ServiceName,
                Label = Convert.ToBase64String(serviceNameBytes),
                Location = Location
            };

            // Invoke REST API call
            HttpResponseMessage response = 
                this.HttpClientInstance.PostAsXmlAsync<CreateHostedService>("", requestBody).Result;
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public void Delete(string ServiceName)
        {
            // Invoke REST API call
            HttpResponseMessage response = this.HttpClientInstance.DeleteAsync(
                string.Format("{0}/{1}", this.ServiceManagementUri, ServiceName)).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
