﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public int ProductId { set; get; }

        public string Image { set; get; }

        public bool IsDefault { set; get; }

    }
}