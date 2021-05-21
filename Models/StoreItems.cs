using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Models
{
    public class StoreItems
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
