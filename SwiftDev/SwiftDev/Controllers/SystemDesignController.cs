using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure;



namespace SwiftDev.Controllers
{
    public class SystemDesignController : Controller
    {
       
        // GET: SystemDesign
        public ActionResult Index()
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = blobClient.GetContainerReference("systemdesign");

            Models.SystemDesignModel blobsList = new Models.SystemDesignModel(storageContainer.ListBlobs(useFlatBlobListing: true));
            

            return View(blobsList);
        }

        [HttpPost]
        public ActionResult ImageUpload(string getFileName)
        {
                
            var image = Request.Files["image"];
            if (image == null)
            {
                
                ViewBag.UploadMessage = "Failed to Upload Image";
            }
            else
            {
                ViewBag.UploadMessage = String.Format("Image {0} has been Uploaded", image.FileName);
            }

            // --- SETTING UP THE CONTAINER --- //

            // Create the CloudStorageAccount

            StorageCredentials credentials = new StorageCredentials ("swiftdevelopmentstorage","HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==" );
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
          
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            // Retrieve Reference to container
            CloudBlobContainer container = blobClient.GetContainerReference("systemdesign");
            // Create if Non-existant
            container.CreateIfNotExists();

            // Change Default Private Permission to Public
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            // --- UPLOAD BLOB TO CONTAINER --- // 

            // Saving the image to a BLOB
            string uniqueBlobName = string.Format("systemdesign/image_{0}{1}",
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
            CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);

            blob.Properties.ContentType = image.ContentType;
            blob.UploadFromStream(image.InputStream);


            // checking the URI  [Test Purposes]
            Console.Write(blob.Uri.ToString());

            return RedirectToAction("Index");    
                
        
        }

        public ActionResult showBlobs()
        {
            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("swiftdevelopmentstorage");

            // Loop to retrive items inside the container
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    Console.WriteLine("Block Blob of length {0} : {1}", blob.Properties.Length, blob.Uri);
                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;
                    Console.WriteLine("Page Blob of length {0} : {1}", pageBlob.Properties.Length, pageBlob.Uri);
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }

            }

            return View("Index");

        }
      


       



    }
}