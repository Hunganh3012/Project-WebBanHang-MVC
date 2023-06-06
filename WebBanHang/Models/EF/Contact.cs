using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models.EF
{
    [Table("tb_Contact")]
    public class Contact :CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required(ErrorMessage ="Tên không được để trống ")]
        [StringLength(150,ErrorMessage ="Không được vượt quá 150 ký tự")]
        public string Name { set; get; }
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Email { set; get; }

        public string Website { set; get; }
        [StringLength(4000)]
        public string Message { set; get; }
        
        public bool IsRead { set; get; }

    }
}