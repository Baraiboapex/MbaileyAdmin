using System;

namespace MbaileyAdmin.Models
{

    public class BlogPost 
    {
        public DateTime DateAdded { get; set; }
        public int Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public List<Category> BlogCategories {get; set;}
        public List<Comment> BlogComments {get; set;}
        public bool IsDeleted {get; set;}
    }

}