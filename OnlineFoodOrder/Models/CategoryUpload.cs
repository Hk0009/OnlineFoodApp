namespace OnlineFoodOrder.Models
{
    public class CategoryUpload
    {
        public IFormFile image { get; set; }
        public string? imageUploadStatus { get; set; }

        public string imageFileName { get; set; } 
    }
}
