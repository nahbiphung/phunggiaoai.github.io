using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class LoaiDocGia
    {
        [Key]
        public int IDLoaiDocGia { get; set; }
        public string TenLoaiDocGia { get; set; }
        
        public virtual ICollection<TheDocGia> TheDocGia { get; set; }
    }
}