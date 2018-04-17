using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class NhaXuatBan
    {
        [Key]
        public int IDNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}