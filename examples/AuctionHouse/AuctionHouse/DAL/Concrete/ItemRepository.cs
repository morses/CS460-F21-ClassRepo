using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;
using AuctionHouse.DAL.Abstract;

namespace AuctionHouse.DAL.Concrete 
{
    public class ItemRepository : IItemRepository
    {
        private AuctionHouseDbContext _context;

        public ItemRepository(AuctionHouseDbContext ctx)
        {
            _context = ctx;
        }
        public List<Item> Items()
        {
            return _context.Items.ToList();
        }

        public Item FindById(int id)
        {
            Item item = _context.Items.Find(id);
            return item;
        }

        public bool SaveToDb()
        {
            bool success = true;
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                success = false;
            }
            catch(DbUpdateException e)
            {
                success = false;
            }
            return success;
        }

        void Add(Item newItem)
        {
            _context.Items.Add(newItem);
        }
/*
        Item AddOrUpdate(Item item);

        void RemoveById(int id);
*/
    }
}