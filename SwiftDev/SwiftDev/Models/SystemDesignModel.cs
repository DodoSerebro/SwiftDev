using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;


namespace SwiftDev.Models
{
    

    // System Design Model 
    public class SystemDesignModel
    {
        public SystemDesignModel() : this(null)
        {
            Files = new List<SystemDesign>();
        }

        public SystemDesignModel(IEnumerable<IListBlobItem> list)
        {
            Files = new List<SystemDesign>();

            if (list != null && list.Count<IListBlobItem>() > 0)
            {
                foreach (var item in list)
                {
                    SystemDesign info = SystemDesign.CreateImageFromIListBlob(item);
                    if (info != null)
                    {
                        Files.Add(info);
                    }
                }
            }
            else
            {
                
            }
        }
        public List<SystemDesign> Files { get; set; }
    }
   
}