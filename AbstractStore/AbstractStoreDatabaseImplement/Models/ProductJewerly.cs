using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractStoreDatabaseImplement.Models
{
    public class ProductJewerly
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int JewerlyId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Jewerly Jewerly { get; set; }
        public virtual Product Product { get; set; }
    }
}
