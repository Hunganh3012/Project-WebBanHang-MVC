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
        [Required(ErrorMessage ="Tên danh mục không được bỏ trống")]
        [StringLength(150)]
        public string Title { set; get; }

        public string Description { get; set; }

        public string Alias { set; get; }
        [StringLength(150)]
        public string SeoTitle { set; get; }
        [StringLength(150)]
        public string SeoDescription { set; get; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }

        public int Position { set; get; }

        public bool? isDelete { set; get; }

        public ICollection<News> News { set; get; }
        
        public ICollection<Post> Posts { set; get; }

    }
}