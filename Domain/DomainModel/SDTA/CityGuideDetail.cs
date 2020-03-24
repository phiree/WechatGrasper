using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.DomainModel.SDTA
{
    public class Pivot
    {
        public int post_id { get; set; }
        public int tag_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int user_id { get; set; }
        public string description { get; set; }
        public object image { get; set; }
        public int parent_id { get; set; }
        public int status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Pivot pivot { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int parent_id { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int user_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public object icon { get; set; }
        public int featured { get; set; }
        public int order { get; set; }
        public int is_default { get; set; }
    }

    public class Image
    {
        public string img { get; set; }
        public string description { get; set; }
    }

    public class Pics
    {
        public int id { get; set; }
        public int content_id { get; set; }
        public List<Image> images { get; set; }
        public string reference { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public object deleted_at { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public int status { get; set; }
        public int user_id { get; set; }
        public object cms_user_id { get; set; }
        public int featured { get; set; }
        public int rank { get; set; }
        public int primary_category { get; set; }
        public string image { get; set; }
        public int views { get; set; }
        public object author { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string commentscore { get; set; }
        public int commentcount { get; set; }
        public int likescount { get; set; }
        public int collectscount { get; set; }
        public List<Tag> tags { get; set; }
        public Category category { get; set; }
        public Pics pics { get; set; }
        public List<object> comments { get; set; }
        public List<object> likes { get; set; }
        public List<object> collects { get; set; }
    }

    public class CityGuideDetail
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
