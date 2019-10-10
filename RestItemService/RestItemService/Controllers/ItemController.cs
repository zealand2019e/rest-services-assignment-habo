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
            //////////////////////////////////////////////
        new Item(1,"Bread","Low",33),
        new Item(2,"Bread","Middle",21),
        new Item(3,"Beer","Low",70.5),
        new Item(4,"Soda","High",21.4),
        new Item(5,"Milk","Low",55.8)
        };

        // GET: api/localItems
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;        }

        // GET: api/localItems/5
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

        // POST: api/localItems
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);

        }

        // PUT: api/localItems/5
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
        [HttpGet]
        [Route("filter/")]
        public IEnumerable<Item> GetWithFilter([FromQuery] FilterItem filter)
        {
            if (filter.HighQuantity!=0&&filter.LowQuantity!=0)
            {
                return items.FindAll(i => (i.Quantity < filter.HighQuantity && i.Quantity > filter.LowQuantity));
            }
            if (filter.HighQuantity != 0)
            {
                return items.FindAll(i => (i.Quantity < filter.HighQuantity));

            }
            if (filter.LowQuantity!=0)
            {
                return items.FindAll(i => (i.Quantity > filter.LowQuantity));

            }
            return items;
        }


        // DELETE: api/localItems/5
        [HttpDelete]
        [Route("{id}")]

        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }
    }
}
