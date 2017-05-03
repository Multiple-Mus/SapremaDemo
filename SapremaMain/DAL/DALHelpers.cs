using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapremaMain.DAL
{
    public class DALHelpers
    {

        public string ConvertToImagePath(Guid? imgGuid, String path)
        {
            string path2 = "/images/meditationimg/";
            return  path2 + imgGuid.ToString() + ".jpg";
        }

        public string ConvertToAudioPath(Guid medGuid)
        {
            string path = "/audio/";
            return path + medGuid.ToString() + ".mp3";
        }
    }
}
