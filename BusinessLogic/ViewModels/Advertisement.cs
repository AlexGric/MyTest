namespace BusinessLogic.ViewModels
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
        public AdType AdType { get; set; }
        public Category Category { get; set; }
        public int Cost { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}