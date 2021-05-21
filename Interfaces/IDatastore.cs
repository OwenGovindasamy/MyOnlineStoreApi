using MyOnlineStoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyOnlineStoreAPI.Interfaces
{
    public interface IDatastore
    {
        Task<List<StoreItems>> ItemList();
    }
}