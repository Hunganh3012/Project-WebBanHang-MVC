using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Post")]
    public class Post :CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { get; set; }

        public string Detail { set; get; }

        public string Alias { set; get; }

        public string Image { set; get; }

        public int CategoryId { get; set; }

        public string SeoTitle { set; get; }

        public string SeoDescription { set; get; }

        public string SeoKeywords { get; set; }

        public virtual Category Category { set; get; }
    }
}