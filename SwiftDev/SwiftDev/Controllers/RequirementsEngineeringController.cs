using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Configuration;
using System.IO;


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure;
using SwiftDev.Models;


namespace SwiftDev.Controllers
{
    public class RequirementsEngineeringController : Controller
    {
        
        // GET: Index which is seen by any ROLE
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _showTemplates()
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("systemrequirements");
           

            RequirementsEngineeringModel documentsListBlob = new RequirementsEngineeringModel(container.ListBlobs("templates", useFlatBlobListing : true));


            return PartialView(documentsListBlob);
        }

        /**
         * Currently Unused Method. Should download the Blobs.
         * Might be implemented and used when Security features and resitrcitions are added
         * 
         * 
        public PartialViewResult downloadDocument(string documentName)
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("systemrequirements");
            CloudBlockBlob blob = container.GetBlockBlobReference(documentName);

            // Save blob contents to a file.
            using (var fileStream = System.IO.File.OpenWrite(documentName))
            {
                blob.DownloadToStream(fileStream);
            } 
            return PartialView("_showTemplates");
        }
         */
   
        [HttpPost]
        public ActionResult DocumentUpload()
        {
            int count = 1;

            var issueLog = Request.Files["issueLog"];
            var testPlan = Request.Files["testplan"];
            var performanceReport = Request.Files["performancereport"];
            var projectstatus = Request.Files["projectstatus"];
            var proposalTemplate = Request.Files["proposalTemplate"];
            var qualitychecklist = Request.Files["qualitychecklist "];
            var riskmanagement = Request.Files["riskamanagement"];
            var systemdesign = Request.Files["systemdesign"];


            // --- SETTING UP CONTAINER --- //


            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve Reference
            CloudBlobContainer container = blobClient.GetContainerReference("systemrequirements");

            // Create if non-existant
            container.CreateIfNotExists();

            // Change Default Permissions to  PUBLIC [temp before adding security]
            // Will change when security features are introduced
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // Foreach document we shall keep the version number

            if (issueLog !=null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("issueLog/Issue Log Version {0}", count);
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = issueLog.ContentType;
                blob.UploadFromStream(issueLog.InputStream);
            }
            else
            {

            }


            return RedirectToAction("index");
        }

        [ChildActionOnly]
        public PartialViewResult _showDocuments(string containerName)
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = blobClient.GetContainerReference("systemrequirements");


            RequirementsEngineeringModel blobsList = new RequirementsEngineeringModel(storageContainer.ListBlobs(containerName, useFlatBlobListing: true));



            return PartialView(blobsList);
        }
    }
}