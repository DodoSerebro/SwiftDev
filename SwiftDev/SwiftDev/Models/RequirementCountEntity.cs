using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;

namespace SwiftDev.Models
{
    public class RequirementCountEntity : TableEntity
    {
        public RequirementCountEntity() { }

        public RequirementCountEntity(string subFolder, string count)
        {
            this.PartitionKey = subFolder;
            this.RowKey = count;
        }



    }
}