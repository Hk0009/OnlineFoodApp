namespace OnlineFoodOrder.Models
{
    public class ProductUpload
    {
        public IFormFile image { get; set; }
        public string? imageUploadStatus { get; set; }

        public string imageFileName { get; set; }
    }
}
