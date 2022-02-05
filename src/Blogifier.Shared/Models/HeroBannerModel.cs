using System;

namespace Blogifier.Shared
{
    public class HeroBannerModel
    {
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public HeroBannerModel()
        {
            Date = DateTime.Now.ToString();
        }
    }
}
