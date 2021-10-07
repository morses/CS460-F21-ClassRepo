using System;
using System.Collections.Generic;
using AuctionHouse.Models;

namespace AuctionHouse.DAL.Abstract 
{
    public interface IBuyerRepository
    {
        /// <summary>
        /// Retrieve all current Buyers
        /// </summary>
        /// <returns>List of Buyer objects</returns>
        List<Buyer> Buyers();

        /// <summary>
        /// Hypothetical example of something we might put here.
        /// </summary>
        /// <returns>A list of emails of all Buyers</returns>
        List<string> GetEmailList();
    }

}