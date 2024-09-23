using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Shared.Functions
{
    public class AddPhoto
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddPhoto(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> AddPhotoToEntityAsync(IBrowserFile photo)
        {
            // Generate a unique file name
            string toReturn = "";
            string folder = "Images/"; // No need to use ~/, WebRootPath handles this.
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.Name); // Ensure correct file extension.
            string filePath = Path.Combine(folder, fileName);
            toReturn = filePath;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            try
            {
                // Create the file and write the photo's stream to it
                await using (var fileStream = new FileStream(serverFolder, FileMode.Create, FileAccess.Write))
                {
                    await using (var memoryStream = photo.OpenReadStream())
                    {
                        await memoryStream.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle file saving exceptions
                Console.WriteLine($"Error saving file: {ex.Message}");
                throw;
            }

            return toReturn;
        }

    }
}
