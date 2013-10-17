using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManagement.Locations
{
    public class LocationsApi : BaseApi
    {
        public LocationsApi(AzureSubscription Subscription) 
            : base(Subscription)
        { }

        public override Uri ServiceManagementUri
        {
            get
            {
                return new Uri(string.Format("{0}/locations",
                    base.ServiceManagementUri));
            }
        }

        public Locations.Models.Locations List()
        {
            // Invoke REST API
            HttpResponseMessage response = this.HttpClientInstance.GetAsync("").Result;
            response.EnsureSuccessStatusCode();
            
            List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>(){
                new XmlMediaTypeFormatter()
            };

            return response.Content.ReadAsAsync<Locations.Models.Locations>(formatters).Result;
        }
    }
}
