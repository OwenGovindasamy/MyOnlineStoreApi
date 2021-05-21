using Microsoft.EntityFrameworkCore;
using MyOnlineStoreAPI.Interfaces;
using MyOnlineStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Logic.DatabaseLogic
{
    public class Datastore : IDatastore
    {
        private readonly ApplicationDbContext _context;

        public Datastore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StoreItems>> ItemList()
        {
            return await _context.StoreItems.ToListAsync();
        }
    }
}
