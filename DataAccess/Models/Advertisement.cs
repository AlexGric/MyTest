namespace DataAccess.Models
{
    public enum AdType
    {
        TextAd,
        HtmlAd,
        BannerAd,
        VideoAd
    }

    public class Advertisement
    {
        public int Id { get; set; }
        public AdType AdType { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Cost { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}