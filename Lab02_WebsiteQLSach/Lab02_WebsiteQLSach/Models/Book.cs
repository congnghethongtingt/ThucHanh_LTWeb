using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02_WebsiteQLSach.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string imagecover;

        public Book() { }

        public Book(int id, string title, string author, string imagecover)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Imagecover = imagecover;
        }

        [Required(ErrorMessage ="Mã sách không được để trống!!")]
        [Display(Name ="Id")]
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage ="Tiêu đề sách không được để trống!!")]
        [StringLength(250,ErrorMessage ="Tiêu đề sách không được vượt quá 250 từ!!")]
        [Display(Name ="Title")]
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Imagecover { get => imagecover; set => imagecover = value; }
    }
}