namespace BlogProject.API.Models.DTO
{
    public class AddPost
    {
        public string title { get; set; }
        public string content { get; set; }

        public string summary { get; set; }

        public string urlHandle { get; set; }

        public string featuredImageUrl { get; set; }

        public Boolean visible { get; set; }

        public string author { get; set; }

        public DateTime publishedDate { get; set; }

        public DateTime updatedDate { get; set; }
    }
}
