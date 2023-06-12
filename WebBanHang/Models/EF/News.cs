using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Models.EF
{
    [Table("tb_News")]
    public class News :CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required(ErrorMessage ="Không được bỏ trống tiêu đề tin tức")]
        [StringLength(150)]
        public string Title { set; get; }

        public string Description { get; set; }

        [AllowHtml]
        public string Detail { set; get; }

        public string Alias { set; get; }

        public string Image { set; get; }

        public int? CategoryId { get; set; }

        public string SeoTitle { set; get; }

        public string SeoDescription { set; get; }

        public string SeoKeywords { get; set; }

        public virtual ICollection<Category> Categories { set; get; }

        public string SelectedCategoryIds { get; set; }
        public string CategoryString { get; set; }

        public bool IsActive { set; get; }

        public bool? IsDelete { set; get; }
    }
}