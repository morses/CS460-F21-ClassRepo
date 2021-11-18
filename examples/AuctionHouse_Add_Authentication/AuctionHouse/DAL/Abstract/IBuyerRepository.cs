using System;
using System.Collections.Generic;
using AuctionHouse.Models;

namespace AuctionHouse.DAL.Abstract 
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        /// <summary>
        /// Hypothetical example of something we might put here.
        /// </summary>
        /// <returns>A list of emails of all Buyers</returns>
        List<string> GetEmailList();
    }

}