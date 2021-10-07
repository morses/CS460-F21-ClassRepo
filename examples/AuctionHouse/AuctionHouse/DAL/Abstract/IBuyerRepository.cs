using System;
using System.Collections.Generic;
using AuctionHouse.Models;

namespace AuctionHouse.DAL.Abstract 
{
    public interface IBuyerRepository
    {
        List<Buyer> Buyers();
    }

}