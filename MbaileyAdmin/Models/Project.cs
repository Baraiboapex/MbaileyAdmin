using System;

namespace MbaileyAdmin.Models
{

    public class Project 
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public DateTime DateAdded {get; set;}
        public string ProjectImage {get; set;}
        public string  AboutProject {get; set;}
        public List<Category> ProjectCategories { get; set; }
        public List<Comment> ProjectComments {get; set;}
        public bool IsDeleted { get; set; }
    }

}