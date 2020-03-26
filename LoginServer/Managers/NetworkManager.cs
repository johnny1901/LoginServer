using System;
using System.Collections.Generic;
using System.Text;
using LoginServer.Networks;


namespace LoginServer.Managers
{
    
    class NetworkManager
    {       
        public NetworkManager(String host, int port, string select)
        {            
            string url = $"http://{host}:{port}/";
            if (select == "1") HttpInitialize(url);
        }

        private void HttpInitialize(String url)
        {
            HttpProtocol httpProtocol = new HttpProtocol(url);            
        }        
    }
}
