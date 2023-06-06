    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { get; set; }

        public string SeoTitle { set; get; }

        public string SeoDescription { set; get; }

        public string SeoKeywords { get; set; }

        public int Position { set; get; }

        public ICollection<News> News { set; get; }
        
        public ICollection<Post> Posts { set; get; }

    }
}