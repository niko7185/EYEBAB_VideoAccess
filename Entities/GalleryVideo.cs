using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class GalleryVideo
    {

        private int videoId;
        private string videoLink;
        private string title;
        private string description;
        private DateTime date;
        private List<string> categories;

        public int VideoId => videoId;
        public string VideoLink => videoLink;
        public string Title => title;
        public string Description => description;
        public DateTime Date => date;
        public List<string> Categories => categories;

        public GalleryVideo(int videoId, string link, string title, string desc, DateTime date)
        {
            this.videoId = videoId;
            this.videoLink = link;
            this.title = title;
            this.description = desc;
            this.date = date;

            categories = new List<string>();

        }

        public void AddCategory(string category)
        {
            categories.Add(category);
        }

    }
}
