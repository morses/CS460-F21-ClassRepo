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
            //return _context.Items.ToList();
            return _context.Items.Include(i => i.Seller)
                                 .Include(i => i.Bids).ToList();
        }

        public Item FindById(int id)
        {
            Item item = _context.Items.Find(id);
            return item;
        }
// Probably good reason not to do it this way, but rather to put the savechanges right in the add,update,delete, ...
// remember, otherwise those methods won't be able to return the updated object.
/*        public bool SaveToDb()
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
*/

        public Item Add(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }
/*
        Item AddOrUpdate(Item item);

        void RemoveById(int id);
*/
    }
}