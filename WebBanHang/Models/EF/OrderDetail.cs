using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public int OrderId { set; get; }

        public int ProductId { set; get; }

        public decimal Price { set; get; }

        public int Quantiy { set; get; }

        public virtual Order Order {set; get;}

        public virtual Product Product { set; get; }
    }
}