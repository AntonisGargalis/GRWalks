using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;
using GRWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadDto imageUploadDto)
        {
            ValidateFileUpload(imageUploadDto);

            if(ModelState.IsValid)
            {
                // Convert DTO to Domain model
                var imageDomain = new Image
                {
                    File = imageUploadDto.File,
                    FileExtension = Path.GetExtension(imageUploadDto.File.FileName),
                    FileSizeInBytes = imageUploadDto.File.Length,
                    FileName = imageUploadDto.FileName,
                    FileDescription = imageUploadDto.FileDescription
                };

                // Use repository to upload image
                await _imageRepository.Upload(imageDomain);

                return Ok(imageDomain);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadDto imageUploadDto)
        {
            var alloudExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if(!alloudExtensions.Contains(Path.GetExtension(imageUploadDto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extenxion");
            }

            if(imageUploadDto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be over 10MB");
            }
        }
    }
}
