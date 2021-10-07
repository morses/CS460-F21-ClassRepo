using System;
using System.Collections.Generic;
using System.Linq;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;

namespace AuctionHouse.DAL.Concrete 
{
    public class BuyerRepository : IBuyerRepository
    {
        private AuctionHouseDbContext _context;

        public BuyerRepository(AuctionHouseDbContext context)
        {
            _context = context;
        }
        public List<Buyer> Buyers()
        {
            return _context.Buyers.ToList();
        }
    }

}