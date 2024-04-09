using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Storage;
using BusinessLogic.Interfaces.Services.Utilites;
using System.IO;

namespace BusinessLogic.Services.Utilities.FileStorage
{
    public class FileStorageService:IFileStorageService
    {
      // Store the Supabase client for reuse

      
        public async Task<string> UploadImageToBucket(IFormFile form)
        {
            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxicXBvaWZjY2dtcWxzeWRodmtlIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI2MDE4NDYsImV4cCI6MjAyODE3Nzg0Nn0.EkMkG3X1inJUPs0Y0_GFCnVBCidQ2VMtTlINCw3Xu8A";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();
            string uniqueIdentifier = Guid.NewGuid().ToString().Substring(0, 8); // Use a portion of the GUID
            string fileName = $"{uniqueIdentifier}.png";

            try
            {
                // Read the form data into a memory stream
                using (var imageStream = new MemoryStream())
                {
                    form.CopyTo(imageStream);
                    imageStream.Position = 0;
                    byte[] fileBytes = imageStream.ToArray();
                    var uploadTask = supabase.Storage
                .From("ProductImg") // Replace with your actual bucket name
                .Upload(imageStream.ToArray(), fileName);
                    var urlhead = "https://lbqpoifccgmqlsydhvke.supabase.co/storage/v1/";
                    // Wait for upload completion
                    var uploadedFile = await uploadTask;


                    // Return the public URL of the uploaded image
                    return urlhead + uploadedFile;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                return null; // Or throw a more specific exception
            }
        }
    }

}
