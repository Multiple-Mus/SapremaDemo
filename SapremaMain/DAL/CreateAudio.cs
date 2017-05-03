using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.DAL
{
    public class CreateAudio
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateAudio(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> CreateMeditationAudio(Guid audioName, IFormFile audioFile)
        {
            string guidtoImgString = audioName.ToString();
            var filePath = _hostingEnvironment.WebRootPath + "\\audio\\" + guidtoImgString + ".mp3";
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                audioFile.CopyTo(stream);
            }
            return true;
        }
    }
}
