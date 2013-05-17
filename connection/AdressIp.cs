using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 背单词对战.connection
{
    class AdressIp
    {
        private string adressUri = "wuuchao.cloudapp.net";
        private string wpServerUri = "wuuchao.cloudapp.net/wpServer";

        public string getAdressUri()
        {
            return adressUri;
        }

        public string getWpServerUri()
        {
            return wpServerUri;
        }
    }
}
