using CloudinaryDotNet.Actions;

namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file, string state, int height, int width);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
