using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace IdentitySample.Models
{
    public partial class SystemDesign
    {
        public string URL { get; set; }



        public SystemDesign() { }

        public SystemDesign(string url)
        {
            this.URL = url;
        }

        public static SystemDesign returnImageURL(IListBlobItem item)
        {

            if (item is CloudBlockBlob)
            {
                var blob = (CloudBlockBlob)item;
                return new SystemDesign
                {
                    URL = blob.Uri.ToString(),
                };

            }
            return null;
        }

    }


    // System Design Model 
    public partial class SystemDesignModel
    {
        public SystemDesignModel()
            : this(null)
        {
            Files = new List<SystemDesign>();
        }

        public SystemDesignModel(IEnumerable<IListBlobItem> list)
        {
            Files = new List<SystemDesign>();

            foreach (var item in list)
            {
                SystemDesign image = SystemDesign.returnImageURL(item);
                Files.Add(image);
            }


        }
        public List<SystemDesign> Files { get; set; }
    }



}