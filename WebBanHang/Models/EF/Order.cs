using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Order")]
    public class Order :CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        public string Code { set; get; }

        [Required]
        public string CustomName { set; get; }


        [Required]
        public string Phone { set; get; }

        [Required]
        public string Address { set; get; }

        public decimal TotalAmount { set; get; }

        public int Quantity { set; get; }

        public bool? isDelete { set; get; }

        public ICollection<OrderDetail> OrderDetails { set; get; }


    }
}