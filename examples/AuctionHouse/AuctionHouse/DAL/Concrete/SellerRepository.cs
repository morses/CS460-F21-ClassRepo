using System;
using System.Collections.Generic;
using System.Linq;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;

namespace AuctionHouse.DAL.Concrete 
{
    public class SellerRepository : ISellerRepository
    {
        private AuctionHouseDbContext _context;

        public SellerRepository(AuctionHouseDbContext context)
        {
            _context = context;
        }

        public List<Seller> Sellers()
        {
            return _context.Sellers.ToList();
        }
    }

}