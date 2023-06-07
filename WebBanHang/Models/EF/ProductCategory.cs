using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_ProductCategory")]
    public class ProductCategory :CommonAbstract
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [StringLength(150) ]
        public string Title { set; get; }

        public string Description { get; set; }

        public string SeoTitle { set; get; }


        public string SeoDescription { set; get; }

        public string SeoKeywords { get; set; }

        public bool? isDelete { set; get; }

        public ICollection<Product> Products { set; get; }
    }
}