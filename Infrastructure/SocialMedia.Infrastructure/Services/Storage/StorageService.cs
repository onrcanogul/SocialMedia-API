using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Storage
{
    public class StorageService(IStorage storage) : IStorageService
    {
        public async Task DeleteAsync(string pathOrContainerName, string fileName) => await storage.DeleteAsync(pathOrContainerName, fileName);
        public List<string> GetFiles(string pathOrContainerName) => storage.GetFiles(pathOrContainerName);

        public async Task<bool> HasFile(string pathOrContainerName, string fileName) => await storage.HasFile(pathOrContainerName, fileName);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
             => storage.UploadAsync(pathOrContainerName, files);
    }
}
