using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.Storage.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage :Storage, IAzureStorage
    {
        readonly BlobServiceClient blobServiceClient;
        BlobContainerClient blobContainerClient;


        public AzureStorage(IConfiguration configuration)
        {
            blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            blobContainerClient = blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            blobContainerClient = blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            return blobContainerClient.GetBlobs().Select(x => x.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            blobContainerClient = blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            return blobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            blobContainerClient = blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            await blobContainerClient.CreateIfNotExistsAsync();
            await blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);


            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(pathOrContainerName, file.Name,HasFile);

                BlobClient blobClient = blobContainerClient.GetBlobClient(fileNewName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((file.Name, $"{pathOrContainerName}/{fileNewName}"));
            }

            return datas;
        }
    }
}
