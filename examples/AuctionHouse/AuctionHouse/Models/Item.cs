using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHouse.Models
{
    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            Bids = new HashSet<Bid>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        [Column("SellerID")]
        public int? SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        [InverseProperty("Items")]
        public virtual Seller Seller { get; set; }
        [InverseProperty(nameof(Bid.Item))]
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
