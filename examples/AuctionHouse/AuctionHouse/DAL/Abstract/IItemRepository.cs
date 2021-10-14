using System;
using System.Collections.Generic;
using AuctionHouse.Models;

namespace AuctionHouse.DAL.Abstract 
{
    public interface IItemRepository
    {
        List<Item> Items();

        Item FindById(int id);

        // Add and save changes.  Will throw exceptions...
        Item Add(Item newItem);

/*
        Item AddOrUpdate(Item item);

        void RemoveById(int id);
*/
    }
}