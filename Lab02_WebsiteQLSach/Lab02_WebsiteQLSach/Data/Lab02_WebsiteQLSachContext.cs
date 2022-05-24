using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab02_WebsiteQLSach.Data
{
    public class Lab02_WebsiteQLSachContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Lab02_WebsiteQLSachContext() : base("name=Lab02_WebsiteQLSachContext")
        {
        }

        public System.Data.Entity.DbSet<Lab02_WebsiteQLSach.Models.Book> Books { get; set; }
    }
}
