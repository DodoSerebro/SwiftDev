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
            
            else if (componentdiagram != null)
            {
                string uniqueBlobName = string.Format("componentdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(componentdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = componentdiagram.ContentType;
                blob.UploadFromStream(componentdiagram.InputStream);
            }
            else if (deploymentdiagram !=null)
            {
                string uniqueBlobName = string.Format("deploymentdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(deploymentdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = deploymentdiagram.ContentType;
                blob.UploadFromStream(deploymentdiagram.InputStream);
            }
            else if (usecasediagram != null)
            {
                string uniqueBlobName = string.Format("usecasediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(usecasediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = usecasediagram.ContentType;
                blob.UploadFromStream(usecasediagram.InputStream);
            }
            else if (sequencediagram != null)
            {
                string uniqueBlobName = string.Format("sequencediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(sequencediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = sequencediagram.ContentType;
                blob.UploadFromStream(sequencediagram.InputStream);
            }
            else if (collaborationdiagram != null)
            {
                string uniqueBlobName = string.Format("collaborationdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(collaborationdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = collaborationdiagram.ContentType;
                blob.UploadFromStream(collaborationdiagram.InputStream);
            }
            else if (statediagram != null)
            {
                string uniqueBlobName = string.Format("statediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(statediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = statediagram.ContentType;
                blob.UploadFromStream(statediagram.InputStream);
            }
            else if (activitydiagram != null)
            {
                string uniqueBlobName = string.Format("activitydiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(activitydiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = activitydiagram.ContentType;
                blob.UploadFromStream(activitydiagram.InputStream);
            }
            else
            {

            }
            return RedirectToAction("Index");    
                
        
        }

        [ChildActionOnly]
        public PartialViewResult _showBlobs(string containerName)
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = blobClient.GetContainerReference("systemdesign");

            Models.SystemDesignModel blobsList = new Models.SystemDesignModel(storageContainer.ListBlobs(containerName, useFlatBlobListing: true));
     
           

            return PartialView(blobsList);
    
        }


    }
}