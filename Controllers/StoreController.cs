using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOnlineStoreAPI.Configuration;
using MyOnlineStoreAPI.Interfaces;
using MyOnlineStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IDatastore _datastore;

        public StoreController(IDatastore datastore)
        {
            _datastore = datastore;
        }
        [HttpGet]
        public async Task<ActionResult<List<StoreItems>>> GetStoreItems()
        {
            return (await _datastore.ItemList());
        }
    }
}
