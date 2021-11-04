using System;
using System.Collections.Generic;
using System.Linq;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;

namespace AuctionHouse.DAL.Concrete 
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(AuctionHouseDbContext ctx) : base(ctx)
        { }

        public List<string> GetEmailList()
        {
            return GetAll().Select(b => b.Email).ToList();
        }
    }

}