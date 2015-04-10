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
using Microsoft.WindowsAzure.Storage.Table;
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

            var count = 0;

            var issueLog = Request.Files["issueLog"];
            var testPlan = Request.Files["testplan"];
            var performanceReport = Request.Files["performancereport"];
            var projectstatus = Request.Files["projectstatus"];
            var proposalTemplate = Request.Files["proposaltemplate"];
            var qualitychecklist = Request.Files["qualitychecklist"];
            var riskmanagement = Request.Files["riskmanagement"];
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
                string uniqueBlobName = string.Format("issueLog/Issue Log Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(issueLog.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = issueLog.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(issueLog.InputStream); }
               
                
            }
            else if (testPlan != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("testplan/Test Plan Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(testPlan.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = testPlan.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(testPlan.InputStream); }

            }
            else if (performanceReport != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("performancereport/Performance Report Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(performanceReport.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = performanceReport.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(performanceReport.InputStream); }

            }
            else if (projectstatus != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("projectstatus/Project Status Report Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(projectstatus.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = projectstatus.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(projectstatus.InputStream); }

            }
            else if (proposalTemplate != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("proposalTemplate/Proposal Template Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(proposalTemplate.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = proposalTemplate.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(proposalTemplate.InputStream); }

            }
            else if (qualitychecklist != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("qualitychecklist/Quality Checklist Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(qualitychecklist.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = qualitychecklist.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(qualitychecklist.InputStream); }
            }
            else if (riskmanagement != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("riskmanagement/Risk Management Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(riskmanagement.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = riskmanagement.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(riskmanagement.InputStream); }
            }
            else if (systemdesign != null)
            {
                count = container.ListBlobs().Count();
                string uniqueBlobName = string.Format("systemdesign/System Design Version_{0}{1}", Guid.NewGuid().ToString(), Path.GetExtension(systemdesign.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = systemdesign.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(systemdesign.InputStream); }
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