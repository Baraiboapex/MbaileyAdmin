using System;

namespace MbaileyAdmin.Models{

    public class About
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string OwnerImage { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}