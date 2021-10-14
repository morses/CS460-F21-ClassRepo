using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHouse.Models
{
    [Table("Buyer")]
    public partial class Buyer
    {
        public Buyer()
        {
            Bids = new HashSet<Bid>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty(nameof(Bid.Buyer))]
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
