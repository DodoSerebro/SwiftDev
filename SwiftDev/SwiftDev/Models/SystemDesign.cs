using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
namespace SwiftDev.Models
{
    // System Design Instance
    public class SystemDesign
    {
        public string FileName { get; set; }
        public string URL { get; set; }
        public long Size { get; set; }

        public static SystemDesign CreateImageFromIListBlob(IListBlobItem item)
        {
            if (item is CloudBlockBlob)
            {
                var blob = (CloudBlockBlob)item;
                return new SystemDesign
                {
                    FileName = blob.Name,
                    URL = blob.Uri.ToString(),
                    Size = blob.Properties.Length

                };
            }
            return null;
        }

    }
}