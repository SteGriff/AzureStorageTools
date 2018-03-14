using Microsoft.WindowsAzure.Storage;

namespace SteGriff.AzureStorageTools
{
    public class AzureStorageProvider
    {
        public string _connectionString;

        public AzureStorageProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        private CloudStorageAccount _storageAccount;
        public CloudStorageAccount StorageAccount
        {
            get
            {
                if (_storageAccount == null)
                {
                    _storageAccount = CloudStorageAccount.Parse(_connectionString);
                }
                return _storageAccount;
            }
        }
    }
}
