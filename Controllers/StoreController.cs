using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOnlineStoreAPI.Interfaces;
using MyOnlineStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly JwtConfig _jwtConfig;
        private readonly ApplicationDbContext _context;
        private readonly IDatastore _datastore;

        public StoreController(ApplicationDbContext context, IDatastore datastore, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _context = context;
            _datastore = datastore;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreItems>>> GetStoreItems()
        {
            return (await _datastore.ItemList());
        }
    }
}
