using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteGriff.AzureStorageTools
{
    public class AzureBlobProvider
    {
        private AzureStorageProvider _storageProvider;

        public AzureBlobProvider(AzureStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public ICloudBlob GetBlockBlob(string containerName, string filename)
        {
            CloudBlobClient blobClient = _storageProvider.StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync();
            ICloudBlob blob = container.GetBlockBlobReference(filename);
            return blob;
        }
    }
}
