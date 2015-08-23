using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace WCF_Hotel_Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class HotelService : IHotelService
    {
        //public string con_str = @"Data Source=.\SQLExpress;Initial Catalog=master;Integrated Security=True";
        public List<List<string>> GetAllRooms()
        {
            string con_str = ConfigurationManager.ConnectionStrings["str_con"].ConnectionString;
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM tbl_rooms";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string id;
            string name;
            string is_reserve;
            
            List<List<string>> list_of_list = new List<List<string>>();

            while ( reader.Read() )
            {
                List<string> s = new List<string>();
                id = reader[0].ToString();
                name = reader[1].ToString();
                is_reserve = reader[2].ToString();

                s.Add( id );
                s.Add( name );
                s.Add( is_reserve );

                list_of_list.Add(s);
            }

            con.Close();
            return list_of_list;
        }


        public void Reserve_Room( string i )
        {
            string con_str = ConfigurationManager.ConnectionStrings["str_con"].ConnectionString;
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            // Вибираєм кімнату в якої Id == index
            cmd.CommandText = String.Format("SELECT Is_reserve FROM tbl_rooms WHERE Id = {0}", i );
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // 1 - кімната заброньована
                // 0 - кімната вільна
                // якщо 0 то заброньовуємо кімнату
                if (reader[0].ToString() == "0")
                {
                    SqlConnection con2 = new SqlConnection(con_str);
                    SqlCommand cmd_reserve = new SqlCommand();
                    cmd_reserve.CommandText = String.Format("UPDATE tbl_rooms SET Is_reserve=1 WHERE Id={0}", i );
                    cmd_reserve.CommandType = CommandType.Text;
                    cmd_reserve.Connection = con2;
                    con2.Open();
                    SqlDataReader res = cmd_reserve.ExecuteReader();
                    con2.Close();
                    break;
                }
            }
            con.Close();
        }
    }
}
