using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASM4.Models
{
    public class Book
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string testGit { get; set; }
        public string testGit2 { get; set; }
        public Book()
        {

        }
        public string giaodien { get; set; }
         public string phong { get; set; }
        public Book(int id, string title, string description, string author, string image, int price)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Image = image;
            Price = price;
        }
    }
}
