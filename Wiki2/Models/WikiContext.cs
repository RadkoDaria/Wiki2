using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wiki2.Models
{
    public class WikiContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public WikiContext() : base("DefaultConnection")
        { }
    }
}
    