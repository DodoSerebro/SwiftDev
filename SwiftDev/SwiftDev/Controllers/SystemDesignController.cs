using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Configuration;
using System.IO;


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure;
using SwiftDev.Models;


namespace SwiftDev.Controllers
{
    public class SystemDesignController : Controller
    {
       
        // GET: SystemDesign
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageUpload()
        {


            var dfd = Request.Files["dfd"];
            var classdiagram = Request.Files["classdiagram"];
            var objectdiagram = Request.Files["objectdiagram"];
            var componentdiagram = Request.Files["componentdiagram"];
            var deploymentdiagram = Request.Files["deploymentdiagram"];
            var usecasediagram = Request.Files["usecasediagram"];
            var sequencediagram = Request.Files["sequencediagram"];
            var collaborationdiagram = Request.Files["collaborationdiagram"];
            var statediagram = Request.Files["statediagram"];
            var activitydiagram = Request.Files["activitydiagram"];
            

            
            // --- SETTING UP THE CONTAINER --- //

            // Create the CloudStorageAccount

            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);


            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            
            // Retrieve Reference to container
            CloudBlobContainer container = blobClient.GetContainerReference("systemdesign");
            
            // Create if Non-existant
            container.CreateIfNotExists();

            // Change Default Private Permission to Public
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });


            // Depending on the Design type (e.g. Flowchart, dfd..) the blob will be uploaded to a different sub folder

            if (dfd != null)
            {
                string uniqueBlobName = string.Format("dfd/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(dfd.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                
                blob.Properties.ContentType = dfd.ContentType;
                blob.UploadFromStream(dfd.InputStream);
            }
            else if (classdiagram != null)
            {
                string uniqueBlobName = string.Format("classdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(classdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                

                blob.Properties.ContentType = classdiagram.ContentType;
                blob.UploadFromStream(classdiagram.InputStream);
            }
            else if (objectdiagram != null)
            {
                string uniqueBlobName = string.Format("objectdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(objectdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = objectdiagram.ContentType;
                blob.UploadFromStream(objectdiagram.InputStream);
            }
            else
            {

            }

            return RedirectToAction("Index");    
                
        
        }

        [ChildActionOnly]
        public ViewResult _showBlobs(string containerName)
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = blobClient.GetContainerReference("systemdesign");

            Models.SystemDesignModel blobsList = new Models.SystemDesignModel(storageContainer.ListBlobs(containerName, useFlatBlobListing: true));
     
           

            return View(blobsList);
    
        }


    }
}