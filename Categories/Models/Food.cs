using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
namespace Categories.Models
{
    public class Food
    {
        private int _id;
        private string _name;
        private int _categoryId;
 

        public Food(int id, int categoryId, string name)
        {
            _id = id;
            _categoryId = categoryId;
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetCategoryId()
        {
            return _categoryId;
        }

        public string GetName()
        {
            return _name;
        }

        public static List<Food> GetAll()
        {
            List<Food> allFoods = new List<Food> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM foods;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                int CategoryId = rdr.GetInt32(1);
                string Name = rdr.GetString(2);
                Food newFood = new Food(Id, CategoryId, Name);
                allFoods.Add(newFood);
            }    
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allFoods;   
        }

        public override bool Equals(System.Object otherFood)
        {

            if (!(otherFood is Food))
            {
                return false;
            }
            else
            {
                Food newFood = (Food)otherFood;
                bool idEquality = (this.GetId() == newFood.GetId());
                bool nameEquality = (this.GetName() == newFood.GetName());
                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `foods` (`id`, `category_id`, `name`) VALUES (@thisId, @thisCategory_Id, @thisName);";

            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@thisId";
            id.Value = this._id;

            MySqlParameter category_id = new MySqlParameter();
            category_id.ParameterName = "@thisCategory_Id";
            category_id.Value = this._categoryId;

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@thisName";
            name.Value = this._name;

            cmd.Parameters.Add(id);
            cmd.Parameters.Add(category_id);
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM foods;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Food Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `foods` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int Id = 0;
            int CategoryId = 0;
            string Name = "";

            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                int CategoryId = rdr.GetInt32(1);
                string Name = rdr.GetString(2);
            }

            Food foundItem = new Food(id, CategoryId, Name);  // This line is new!

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundItem;  // This line is new!


    }
}
