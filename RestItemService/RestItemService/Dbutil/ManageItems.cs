using ModelLib.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestItemService.Dbutil
{
    public class ManageItems
    {
         static string connectionString = "Server=tcp:habo.database.windows.net,1433;Initial Catalog=ItemLibrary;Persist Security Info=False;User ID=Habo;Password={Password123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        static protected Item ReadNextElement(SqlDataReader reader)
        {
            Item item = new Item();
            item.Id = reader.GetInt32(0);
            item.Name = reader.GetString(1);
            item.Quality = reader.GetString(2);
            item.Quantity = reader.GetDouble(3);
            return item;
        }




        static public Item Get(int id) {
            String sql = "select * from Items WHERE id = @ID";
            
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Item result = ReadNextElement(reader);
            reader.Close();
            conn.Close();
            return result;
        }
            public void Post(Item value) { }
            public void Put(int id, Item value) { }
            public void Delete(int id) { }         static public IEnumerable<Item> Get() {
                String sql = "select* from Items";
                 List<Item> liste = new List<Item>();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Item item = ReadNextElement(reader);
                liste.Add(item);
            }
            reader.Close();
            conn.Close();
            return liste;
        }
    }
}
