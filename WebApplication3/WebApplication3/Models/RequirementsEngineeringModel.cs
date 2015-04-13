using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace IdentitySample.Models
{
        public partial class RequirementsEngineering
        {
        public string URL { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }

        public RequirementsEngineering() { }

        public RequirementsEngineering(string url, string name, string content)
        {
            this.URL = url;
            this.Name = name;
            this.ContentType = content;
        }


        public static RequirementsEngineering returnDocumentURL(IListBlobItem item)
        {
            if (item is CloudBlockBlob)
            {
                var blob = (CloudBlockBlob)item;
                return new RequirementsEngineering
                {
                    URL = blob.Uri.ToString(),
                    Name = blob.Name.Substring(blob.Name.LastIndexOf('/') + 1),
                    ContentType = blob.Properties.ContentType,
                };
            }
            return null;
        }



    }

    public partial class RequirementsEngineeringModel
    {
        public RequirementsEngineeringModel()
            : this(null)
        {
            Files = new List<RequirementsEngineering>();
        }

        public RequirementsEngineeringModel(IEnumerable<IListBlobItem> list)
        {
            Files = new List<RequirementsEngineering>();

            foreach (var item in list)
            {
                RequirementsEngineering document = RequirementsEngineering.returnDocumentURL(item);
                Files.Add(document);
            }
        }



        public List<RequirementsEngineering> Files { get; set; }
    }
}


