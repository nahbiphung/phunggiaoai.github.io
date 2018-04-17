using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class LoaiSach
    {
        [Key]
        public int IDLoaiSach { get; set; }
        public string TenLoaiSach { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}