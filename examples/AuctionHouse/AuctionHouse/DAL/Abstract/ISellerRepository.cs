using System;
using System.Collections.Generic;
using AuctionHouse.Models;

namespace AuctionHouse.DAL.Abstract 
{
    public interface ISellerRepository
    {
        List<Seller> Sellers();
    }
}