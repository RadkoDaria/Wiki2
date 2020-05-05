using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
    }
}