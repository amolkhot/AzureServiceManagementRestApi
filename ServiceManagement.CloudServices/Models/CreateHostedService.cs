using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManagement.CloudServices.Models
{
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateHostedService
    {
        [DataMember(Order = 1, IsRequired=true)]
        public string ServiceName { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public string Label { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        public string Location { get; set; }
    }
}



