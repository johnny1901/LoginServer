using System;
using System.Text;
using System.Threading;
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
                    Console.Clear();
                    new NetworkManager(host, port, select);
                    break;
                case "2":
                    Console.WriteLine("TODO");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("TODO");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("잠시 후 종료 됩니다.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
