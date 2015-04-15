using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
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
using IdentitySample.Models;

namespace IdentitySample.Controllers
{

    public class SystemDesignController : Controller
    {



        public ActionResult returnCurrentProject(string username)
        {


            int value = 0;
            string stringValue = "";

            string connectionString = "Data Source=ifa510pyey.database.windows.net;Initial Catalog=swiftdevdb;Integrated Security=False;User ID=swiftdevlogin;Password=SwiftDevFYP2015";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                connection.Open();
                command.CommandText = "SELECT CurrentProject FROM AspNetUsers WHERE UserName = @username";
                command.Parameters.AddWithValue("@username", username);

                using (var rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        value = rdr.GetInt32(0);
                    }
                }
                
                connection.Close();
            }
            stringValue = value.ToString();

            return Content(stringValue);
        }

       // [Authorize]
        // GET: SystemDesign
        public ActionResult Index()
        {
           return View();
        }

       // [Authorize(Roles = "SuperUser, Admin, Designer")]
        [HttpPost]
        public ActionResult ImageUpload(int projectID)
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
                string uniqueBlobName = string.Format(projectID +"/dfd/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(dfd.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);

                blob.Properties.ContentType = dfd.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(dfd.InputStream); }
            }
            if (classdiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/classdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(classdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = classdiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(classdiagram.InputStream); }
            }
            if (objectdiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/objectdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(objectdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = objectdiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(objectdiagram.InputStream); }
            }

            else if (componentdiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/componentdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(componentdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = componentdiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(componentdiagram.InputStream); }
            }
            else if (deploymentdiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/deploymentdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(deploymentdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = deploymentdiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(deploymentdiagram.InputStream); }
            }
            else if (usecasediagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/usecasediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(usecasediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);

                blob.Properties.ContentType = usecasediagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(usecasediagram.InputStream); }
            }
            else if (sequencediagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/sequencediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(sequencediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = sequencediagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(sequencediagram.InputStream); }
            }
            else if (collaborationdiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/collaborationdiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(collaborationdiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = collaborationdiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(collaborationdiagram.InputStream); }
            }
            else if (statediagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/statediagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(statediagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = statediagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(statediagram.InputStream); }
            }
            else if (activitydiagram != null)
            {
                string uniqueBlobName = string.Format(projectID + "/activitydiagram/image_{0}{1}",
                    Guid.NewGuid().ToString(), Path.GetExtension(activitydiagram.FileName));
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);


                blob.Properties.ContentType = activitydiagram.ContentType;
                if (blob.Properties.ContentType == "application/octet-stream")
                {

                }
                else { blob.UploadFromStream(activitydiagram.InputStream); }
            }
            else
            {

            }
            return RedirectToAction("Index");


        }

      //  [Authorize]
        [ChildActionOnly]
        public PartialViewResult _showBlobs(string containerName, string projectId)
        {
            string url = projectId + "/" + containerName;

            StorageCredentials credentials = new StorageCredentials("swiftdevelopmentstorage", "HqaCkZjdQ8w/DX/fS3wDxU6HXbeqV5EZ1b+UQaKALxaJDrN9JoZZYn8Q0KT6QR4tCrdGQicxE+tKRKScjINW8w==");
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = blobClient.GetContainerReference("systemdesign");


            SystemDesignModel blobsList = new SystemDesignModel(storageContainer.ListBlobs(url, useFlatBlobListing: true));



            return PartialView(blobsList);

        }


    }
}