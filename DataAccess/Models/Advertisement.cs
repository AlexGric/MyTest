using System;
using System.Collections.Generic;
using System.Text;

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
        public Category Category { get; set; }
        public int Cost { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public Advertisement(AdType adType, Category category, int cost, string content, string image)
        {
            AdType = adType;
            Category = category;
            Cost = cost;
            Content = content;
            Image = image;
        }

    }
}
