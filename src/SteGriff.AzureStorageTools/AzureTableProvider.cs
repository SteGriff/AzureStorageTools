using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SteGriff.AzureStorageTools
{
    public class AzureTableProvider
    {
        private AzureStorageProvider _storageProvider;

        public AzureTableProvider(AzureStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public async Task<CloudTable> GetTableAsync(string tablename)
        {
            CloudTableClient tableClient = _storageProvider.StorageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tablename);
            await table.CreateIfNotExistsAsync();

            return table;
        }

        public async Task DropTableAsync(string tablename)
        {
            CloudTableClient tableClient = _storageProvider.StorageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tablename);
            await table.DeleteIfExistsAsync();
        }
    }
}
