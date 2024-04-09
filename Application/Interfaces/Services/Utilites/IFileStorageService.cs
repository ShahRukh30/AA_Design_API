using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Utilites
{
    public interface IFileStorageService
    {
        Task<string> UploadImageToBucket(IFormFile form);
    }
}
