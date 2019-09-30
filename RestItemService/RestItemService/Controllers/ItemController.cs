using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace RestItemService.Controllers
{
    [Route("api/localItems")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static readonly List<Item> items = new List<Item>()
        {
        new Item(1,"Bread","Low",33),
        new Item(2,"Bread","Middle",21),
        new Item(3,"Beer","Low",70.5),
        new Item(4,"Soda","High",21.4),
        new Item(5,"Milk","Low",55.8)
        };

        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;        }

        // GET: api/Item/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }

        [HttpGet]
        [Route("Name/{name}")]

        public IEnumerable<Item> GetFromSubstring(string name)
        {
            return items.FindAll(i => i.Name.Contains(name));
        }
        [HttpGet]
        [Route("Quality/{quality}")]

        public IEnumerable<Item> GetbyQuality(string quality)
        {
            return items.FindAll(i => i.Quality == quality);
        }
        [HttpGet]
        [Route("Quantity/Between/{num1}asd{num2}")]

        public IEnumerable<Item> GetBetween(int num1,int num2)
        {
            return items.FindAll(i => (i.Quantity < num2 && i.Quantity > num1));
        }

        // POST: api/Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);

        }

        // PUT: api/Item/5
        [HttpPut]
        [Route("{id}")]

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
        [HttpDelete]
        [Route("{id}")]

        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }
    }
}
