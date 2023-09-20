using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PriceApp_Application.Common;
using PriceApp_Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Implementation
{
    public class PhotoService : IPhotoService
    {
        public IConfiguration Configuration { get; } 
        private CloudinarySettings _cloudinarySettings { get; } 
        private Cloudinary _cloudinary; 

        public PhotoService(IConfiguration configuration)
        {
            Configuration = configuration;

            var cloudinarySettings = Configuration.GetSection("CloudinarySettings");
            _cloudinarySettings = new CloudinarySettings();
            _cloudinarySettings.CloudName = cloudinarySettings["CloudName"];
            _cloudinarySettings.ApiKey = cloudinarySettings["ApiKey"];
            _cloudinarySettings.ApiSecret = cloudinarySettings["ApiSecret"];

            Account account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret); 

            _cloudinary = new Cloudinary(account);
        }


        public string AddPhotoForUser(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);

                }
            }

            string url = uploadResult.Url.ToString();
            string publicId = uploadResult.PublicId;

            return url;
        }
    }
}
