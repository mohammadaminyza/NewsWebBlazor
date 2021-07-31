using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlazorNews.Core.Security
{
    public static class FileFormatChecker
    {

        public static bool IsImage(this IFormFile file)
        {
            if (file != null)
            {
                var imageFormat = file.FileName.Split(".").Last();


                if (imageFormat == "jpg" || imageFormat == "png" || imageFormat == "gif")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return false;
        }

        public static bool IsVideo(this IFormFile file)
        {
            if (file != null)
            {
                var VideoFromat = file.FileName.Split(".").Last();

                if (VideoFromat == "avi" || VideoFromat == "mkv" || VideoFromat == "mp4" || VideoFromat == "m4v")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
