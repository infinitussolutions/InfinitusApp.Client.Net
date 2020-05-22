using InfinitusApp.Core.Data.Commands;
using Microsoft.WindowsAzure.Storage.Blob;
using Naylah.Services.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Services.Storage
{
    public class StorageService : ServiceBase
    {
        public StorageService(InfinitusAppServiceClient _serviceClient) : base(_serviceClient)
        {
        }

        public async Task<Uri> GetSasUriForFile(string fileName)
        {
            var obj = new FileBlobRequestRepresenation
            {
                FileName = fileName
            };

            var result = await ServiceClient.MobileServiceClient
                .InvokeApiAsync<FileBlobRequestRepresenation, FileBlobRequestRepresenation>("Storage/Infinitus/GetBlobSASUri", obj);

            return new Uri(result.BlobUri);
        }

        public async Task<Uri> GetSasUriForStorageFile(string fileName, string container)
        {
            var obj = new FileBlobRequestRepresenation
            {
                FileName = fileName,
                ContainerName = container
            };

            var result = await ServiceClient.MobileServiceClient
                .InvokeApiAsync<FileBlobRequestRepresenation, FileBlobRequestRepresenation>("Storage/Infinitus/GetBlobStorageSASUri", obj);

            return new Uri(result.BlobUri);
        }

        public async Task<Uri> Create(BlobCommand cmd)
        {
            return await ServiceClient.InvokeApiAsync<BlobCommand, Uri>("Storage/Infinitus/UploadToBlob", cmd);
        }
    }

    public class FileBlobRequestRepresenation
    {
        public string FileName { get; set; }

        public string BlobUri { get; set; }

        public string ContainerName { get; set; }
    }

    // BUG INFINITUS CLIENT

    //public static class StorageExtensions
    //{
    //    public static async Task<CloudBlockBlob> UploadToBlob(this string path, Uri blobSasuri)
    //    {
    //        var blob = new CloudBlockBlob(blobSasuri);
    //        await blob.UploadFromFileAsync(path);

    //        return blob;
    //    }

    //    public static async Task<CloudBlockBlob> UploadToBlobHtml(this MemoryStream memoryStream, Uri blobSasuri)
    //    {
    //        var blob = new CloudBlockBlob(blobSasuri);
    //        blob.Properties.ContentType = "text/html";
    //        await blob.UploadFromStreamAsync(memoryStream);

    //        return blob;
    //    }
    //}
}
