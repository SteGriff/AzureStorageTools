# AzureStorageTools

A small (slightly opinionated) NuGet package to help with some of the dumb stuff when it comes to working with Azure storage. It depends on `WindowsAzure.Storage`. If you're installing into a Function App project, you may need to manually add `Newtonsoft.Json` to your project, because the version referenced by `WindowsAzure.Storage` differs from that held by `Microsoft.NET.Sdk.Functions`.

	Install-Package SteGriff.AzureStorageTools
	
Remember to add `using SteGriff.AzureStorageTools` to the top of your code files where you use it.

## Contents

### `AzureStorageProvider`

Construct an instance of this class using a ConnectionString, and it will provide you with lazy-loaded `CloudStorageAccount`. It's used by all the other classes here as a connection container. For usage, see the other entries below.

### `AzureTableProvider`

An easier way to Get and Drop Azure Tables. It hides the `CloudTableClient` class and the `table.CreateIfNotExistsAsync();` step, so you receive a guaranteed-to-exist table without thinking too much :)

**Usage:**
		
	var storageProvider = new AzureStorageProvider("ConnectionString...");
	var tableProvider = new AzureTableProvider(storageProvider);
	CloudTable myTable = await tableProvider.GetTableAsync("people");
	//Do stuff with the CloudTable...
	
	//You can also drop it
	await tableProvider.DropTableAsync("people");
	
### `AzureBlobProvider`

An easier way to Get Block Blobs. Maybe later it will do other stuff too. It hides the `CloudBlobClient` and `CloubBlobContainer` classes, and the `container.CreateIfNotExistsAsync()` step.

**Usage:**
		
	var storageProvider = new AzureStorageProvider("ConnectionString...");
	var blobProvider = new AzureBlobProvider(storageProvider);
	ICloudBlob myBlob = blobProvider.GetBlockBlob("container","filename.txt");
	//Do stuff with the CloudBlob...

	
## Contributing

Discussion is welcome in the issues. Open an issue to discuss before opening Pull Requests.

## License

LICENSE is MIT (C) 2018 Stephen Griffiths



