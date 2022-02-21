using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DotnetCd.Models
{
    public class Users
    {
        public static string[] Columns = new string[]{
            "Id",
            "Handle",
            "Name",
            "Avatar",
        };

        public static async Task<List<User>> list()
        {
            var items = new List<User>();

            await Database.Query(async (conn) =>
            {
                SqlCommand command = new SqlCommand(@"select * from Users", conn);

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var item = new User
                            {
                                Id = long.Parse(reader["Id"].ToString()),
                                Handle = reader["Handle"].ToString(),
                                Name = reader["Name"].ToString(),
                                Avatar = reader["Avatar"].ToString(),
                            };

                            if ( item.Id > 0 )
                                items.Add(item);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Users.list error: {0}, {1}", e.ToString(), e.Message);
                }
            });

            return items;
        }
    }
}
