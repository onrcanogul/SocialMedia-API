using ETicaretAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services
{
    public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
    {
        public async Task<bool> CopyFileAsync(string path, IFormFile file)
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

        public async Task<string> FileRenameAsync(string path, string fileName, int num = 0)
        {
            string newFileName = await Task.Run<string>(async () =>
            {

                string newFileName = string.Empty;
                string extension = Path.GetExtension(fileName);
                if(num == 0)
                {
                    string oldName = Path.GetFileNameWithoutExtension(fileName);
                    newFileName = NameOperation.CharacterRegulatory(oldName) + extension;
                }
                else
                {
                    newFileName = fileName;
                }
                if (File.Exists($"{path}/{newFileName}"))
                {
                    await FileRenameAsync(path, $"{newFileName}{extension}-{num}", ++num);
                }
                return newFileName;
            });
            return newFileName;
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath)) 
                Directory.CreateDirectory(uploadPath);

            List < (string fileName, string path) > uploadedFiles = new();
            List<bool> results = new();
            foreach (IFormFile file in files) 
            {
                string fileNewName = await FileRenameAsync(path,file.FileName);
                bool result = await CopyFileAsync(Path.Combine(uploadPath,fileNewName),file);
                results.Add(result);
                uploadedFiles.Add((fileNewName,path));
            }

            if(results.TrueForAll(x => x.Equals(true)))
            {
                return uploadedFiles;
            }
            throw new Exception();
        }
    }
}
