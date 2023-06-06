using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Adv")]
    public class Adv :CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [StringLength(150)]
        public string Title { set; get;}

        [StringLength(500)]
        public string Description { set; get; }

        [StringLength(500)]
        public string Link { set; get; }

        [StringLength(500)]
        public string Image { set; get; }

        public string Type { set; get; }


    }
}