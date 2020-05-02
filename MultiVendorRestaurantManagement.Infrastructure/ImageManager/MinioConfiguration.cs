namespace MultiVendorRestaurantManagement.Infrastructure.ImageManager
{
    public class MinioConfiguration
    {
        public string Server { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
        public string LocalImageLocation { get; set; }
    }
}