using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 背单词对战.connection;

namespace 背单词对战.view
{
    public partial class setLimit : PhoneApplicationPage
    {
        private string conn = null;
        public setLimit()
        {
            InitializeComponent();
            connector con = new connector();
            AdressIp add = new AdressIp();
            conn = con.Connect("http://wuuchao.cloudapp.net/wpServer/", 80);
            con.Send("111");
            conn = con.Receive();
            t.Text = conn;
        }

    }
}