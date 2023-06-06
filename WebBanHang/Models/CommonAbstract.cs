using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CommonAbstract
    {

        public string CreateBy { set; get; }

        public DateTime CreateDate { set; get; }

        public DateTime ModifiedDate { set; get; }

        public string Modifiedby { set; get; }
    }
}