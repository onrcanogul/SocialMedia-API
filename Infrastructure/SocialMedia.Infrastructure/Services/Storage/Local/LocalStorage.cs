using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Storage.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Storage.Local
{
    public class LocalStorage(IWebHostEnvironment webHostEnvironment) :Storage, ILocalStorage
    {
        public async Task DeleteAsync(string path, string fileName) =>  File.Delete($"{path}\\{fileName}");
        

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(x => x.Name).ToList();
        }

        public bool HasFile(string path, string fileName) => File.Exists($"{path}\\{fileName}");
        


        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath)) 
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string pathOrContainerName)> datas = new();
            foreach (IFormFile file in files) 
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);
                await CopyFileAsync($"{uploadPath}\\{fileNewName}",file);
                datas.Add((file.Name, $"{path}\\{fileNewName}"));
            }
            return datas;


            
        }
    }
}
