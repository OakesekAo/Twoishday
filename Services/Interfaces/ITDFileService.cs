using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Twoishday.Services.Interfaces
{
    public interface ITDFileService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);

        public string ConvertByteArraytoFile(byte[] fileData, string extension);

        public string GetFileIcon(string file);

        public string FormatFileSize(long bytes);
    }
}
