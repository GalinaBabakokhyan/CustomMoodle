using System.IO;
using Microsoft.AspNetCore.Http;

namespace CustomMoodle.HelperFunctions
{
    public static class FileHelpers
    {
        public  static string SaveToPhysicalLocation(IFormFile formFile, string filePath) {  
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            return string.Empty;  
        }  
    }
}