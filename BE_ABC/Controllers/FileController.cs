using BE_ABC.Services.StorageService;
using Microsoft.AspNetCore.Mvc;

namespace BE_ABC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly GoogleDriveService _googleDriveService;

        public FileController(GoogleDriveService googleDriveService)
        {
            _googleDriveService = googleDriveService;
        }
       
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not selected");

            var (fileId, webViewLink, webContentLink) = await _googleDriveService.UploadFileAsync(file);

            if (string.IsNullOrEmpty(fileId))
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading file");

            return Ok(new
            {
                FileId = fileId,
                WebViewLink = webViewLink,
                WebContentLink = webContentLink
            });
        }
    }
}
