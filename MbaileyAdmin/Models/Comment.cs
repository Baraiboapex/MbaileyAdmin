using System;

namespace MbaileyAdmin.Models
{

    public class Comment
    {
        public int Id {get; set;}
        public DateTime DatePosted {get; set;}
        public string Commenter {get; set;}
        public string Content {get; set;}
        public bool IsDeleted { get; set; }
    }
    
}