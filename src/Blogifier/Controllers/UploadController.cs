using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogifier.Core.Providers;
using System.Threading.Tasks;
using Blogifier.Shared;
using System.Linq;
using System.IO;

namespace Blogifier.Controllers
{
    [Route("api/Upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadProvider _uploadProvider;

        public UploadController(IUploadProvider uploadProvider)
        {
            _uploadProvider = uploadProvider;
        }

        [HttpPost("banner")]
        public async Task Banner([FromForm] IFormFile file)
        {
            var model = new BannerModel
            {
                Name = "banner-Image." + file.FileName.Split('.').Last(),
                Data = await FormFileToByteArrayAsync(file)
            };
            _uploadProvider.Add(model);
        }

        private async Task<byte[]> FormFileToByteArrayAsync(IFormFile file)
        {
            byte[] fileStream;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileStream = memoryStream.ToArray();
                await memoryStream.FlushAsync();
            }

            return fileStream;
        }
    }
}
