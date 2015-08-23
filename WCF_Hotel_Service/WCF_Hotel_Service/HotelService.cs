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


        public string Reserve_Room( string i )
        {
            string str_err = null;
            string con_str = ConfigurationManager.ConnectionStrings["str_con"].ConnectionString;
            SqlConnection con = new SqlConnection(con_str);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = String.Format("EXECUTE reserve {0}", i);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            try
            {
                con.Open();

                SqlDataReader res = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                str_err = e.Message;
            }
            con.Close();
            return str_err;
        }
    }
}
