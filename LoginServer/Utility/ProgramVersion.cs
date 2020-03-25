using System;
using System.Collections.Generic;
using System.Text;

namespace LoginServer.Utility
{
    class ProgramVersion
    {
        
        public ProgramVersion()
        {
            string programInfo = $"Project LoginServer [{DateTime.Now:yyMMddHHmm}]";
            Console.Title = programInfo;
            Console.WriteLine(programInfo);         
        }
    }
}
