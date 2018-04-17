using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLTV.Models
{
    public class TacGia
    {
        [Key]
        public int IDTacGia { get; set; }
        public string TenTacGia { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}