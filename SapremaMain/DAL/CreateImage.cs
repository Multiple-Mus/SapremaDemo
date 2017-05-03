using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.DAL
{
    public class CreateImage
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateImage(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> CreateMeditationImage(Guid imageName, IFormFile imageFile)
        {
            string guidtoImgString = imageName.ToString();
            var filePath = _hostingEnvironment.WebRootPath + "\\images\\meditationimg\\" + guidtoImgString + ".jpg";
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return true;
        }
    }
}
