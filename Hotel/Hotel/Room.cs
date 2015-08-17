using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Room
    {
        private string id { get; set; }
        private string name { get; set; }
        private string is_reserve { get; set; }

        public Room(string _id, string _name, string _is_reserve)
        {
            id = _id;
            name = _name;
            is_reserve = _is_reserve;
        }
    }
}
