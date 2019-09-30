using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace RestItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static readonly List<Item> items = new List<Item>()
 {
 new Item(1,"Bread","Low",33),
 new Item(2,"Bread","Middle",21),
 new Item(3,"Beer","low",70.5),
 new Item(4,"Soda","High",21.4),
 new Item(5,"Milk","Low",55.8)
 };

        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }

        // POST: api/Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);

        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }
    }
}
