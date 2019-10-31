using ModelLib.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestItemService.Dbutil
{
    public class ManageItems
    {
        
        

        protected Item ReadNextElement(SqlDataReader reader)
        {
            Item item = new Item();
            item.Id = reader.GetInt32(0);
            item.Name = reader.GetString(1);
            item.Quality = reader.GetString(2);
            item.Quantity = reader.GetDouble(3);
            return item;
        }

        public Item Get(int id) { }
        public void Post(Item value) { }
        public void Put(int id, Item value) { }
        public void Delete(int id) { }
    }
}
