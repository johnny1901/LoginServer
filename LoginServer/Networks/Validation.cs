using System;
using System.Collections.Generic;
using System.Text;

namespace LoginServer.Networks
{
    class Validation
    {
        public void RequestData(String url, String method, String reqData, String userIP)
        {
            Random rand = new Random();
            Console.WriteLine("***************************************");
            Console.WriteLine("URL: > {0} [{1}] ", url, method);
            Console.WriteLine("USER: > {0}", userIP);
            Console.WriteLine("DATA: > {0}", reqData);
            Console.WriteLine("SALT: > {0}", rand.Next());
            Console.WriteLine("***************************************\n");

            if (reqData.Equals(string.Empty))
            {
                
            }

        }
    }
}
