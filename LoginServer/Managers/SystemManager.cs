using System;
using System.Text;
using LoginServer.Protocols;
using LoginServer.Utility;


namespace LoginServer.Managers
{
    
    class SystemManager
    {        
        public SystemManager()
        {            
            new ProgramVersion();
            
            Console.Write("HOST > ");            
            string host = Console.ReadLine();            
            Console.Write("PORT > ");
            int port = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nSelect Protocol");
            Console.WriteLine("[ 1 ] HTTP");
            Console.WriteLine("[ 2 ] TCP/IP");
            Console.WriteLine("[ 3 ] UCP/IP");
            Console.WriteLine("[ 4 ] EXIT\n");

            Console.Write("Select > ");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    HttpProtocol httpProtocol = new HttpProtocol();
                    break;
                case "2":
                    Console.WriteLine("2");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("3");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("4");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
