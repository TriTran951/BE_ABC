using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;

namespace BE_ABC.Services.StorageService
{
    public class GoogleDriveService
    {
        private readonly DriveService _driveService;

        public GoogleDriveService(DriveService driveService)
        {
            _driveService = driveService;
        }

        public async Task<(string Id, string WebViewLink, string WebContentLink)> UploadFileAsync(IFormFile file)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file.FileName
            };

            FilesResource.CreateMediaUpload request;

            using (var stream = file.OpenReadStream())
            {
                request = _driveService.Files.Create(fileMetadata, stream, file.ContentType);
                request.Fields = "id, name, mimeType, parents, webViewLink, webContentLink";
                await request.UploadAsync();
            }

            var fileResponse = request.ResponseBody;

            if (fileResponse != null)
            {
                var permission = new Permission
                {
                    Type = "anyone",
                    Role = "reader"
                };
                await _driveService.Permissions.Create(permission, fileResponse.Id).ExecuteAsync();
            }

            return (fileResponse?.Id, fileResponse?.WebViewLink, fileResponse?.WebContentLink);
        }
    }
}
