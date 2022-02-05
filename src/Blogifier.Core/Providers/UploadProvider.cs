using Microsoft.AspNetCore.Hosting;
using Blogifier.Shared;
using System.IO;
using System.Threading.Tasks;

namespace Blogifier.Core.Providers
{
    public interface IUploadProvider
    {
       void Add(BannerModel model);
    }

    public class UploadProvider : IUploadProvider
    {
        private readonly IHostingEnvironment _env;
        private readonly IBlogProvider _blogProvider;

        public UploadProvider(IHostingEnvironment hostingEnvironment,
                              IBlogProvider blogProvider)
        {
            _env = hostingEnvironment;
            _blogProvider = blogProvider;
        }

        public void Add(BannerModel model)
        {
            var file = new FileStream(_env.WebRootPath + "\\img\\" +
                model.Name, FileMode.Create);
            file.Write(model.Data);
            file.Close();
        }
    }
}
