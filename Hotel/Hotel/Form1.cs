﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Form1 : Form
    {
        public string con_str = @"Data Source=.\SQLExpress;Initial Catalog=master;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        public void Update_()
        {
            foreach (ListViewItem item in listV_rooms.Items)
                listV_rooms.Items.Remove(item);

            Hotel_Service.Service1Client client = new Hotel_Service.Service1Client();
            List<List<string>> list_of_rooms = client.GetAllRooms();

            foreach (List<string> s in list_of_rooms)
            {
                ListViewItem list1 = new ListViewItem(s[0]);
                list1.SubItems.Add(s[1]);
                list1.SubItems.Add(s[2]);
                listV_rooms.Items.Add(list1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update_();
        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {
            var index = listV_rooms.SelectedItems[0].Text;
            Hotel_Service.Service1Client client = new Hotel_Service.Service1Client();
            string i = index.ToString();
            client.Reserve_Room( i );
            Update_();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Update_();
        }

    }
}
