using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Product")]
    public class Product :CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get;}

        public string Title { set; get; }

        public string ProductCode { set; get; }

        public string Description { get; set; }

        public string Detail { set; get; }

        public string Image { set; get; }

        public decimal Price { set; get; }

        public decimal PriceSale { set; get; }

        public int Quantity { set; get; }
        //Sản phẩm đang hiển thị
        public bool IsHome { set; get; }

        //Sản phẩm đang sale
        public bool IsSale { set; get; }

        //Sản phẩm nổi bậc
        public bool IsFeature { set; get; }

        //Sản phẩm đang hot(bestSeller)
        public bool ISHot { set; get; }

        public int ProductCategoryId { get; set; }

        public string SeoTitle { set; get; }

        public string SeoDescription { set; get; }

        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { set; get; }
    }
}