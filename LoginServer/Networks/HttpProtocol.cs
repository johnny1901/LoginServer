using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginServer.Networks
{
    /*
     * HTTP 웹 서버
     *  - 호 : 인증서버
     */     
    class HttpProtocol
    {
        public static HttpListener listener = new HttpListener();

        public HttpProtocol(String url)
        {
            listener.Prefixes.Add(url);
            Console.WriteLine($"[INFO] > {url} >> Listener START");
            listener.Start();            
            Task listenTask = HttpConnection();
            listenTask.GetAwaiter().GetResult();
            listener.Close();
            Console.WriteLine($"[INFO] > {url} >> Listener CLOSE");

        }
        public static async Task HttpConnection()
        {
            bool runServer = true;     

            while (runServer)
            {                
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string reqData = StreamData(request.InputStream);
                Console.WriteLine("[Connection Detect] : {0} -> {1} ", request.RemoteEndPoint.Address, request.HttpMethod);
                Console.WriteLine(request.RawUrl);
                // response
                /*byte[] responseToken = Encoding.UTF8.GetBytes(String.Format("접속 불가"));
                response.ContentType = "text/html; charset=utf-8";
                response.ContentLength64 = responseToken.LongLength;
                await response.OutputStream.WriteAsync(responseToken, 0, responseToken.Length);
                response.Close();*/
            }
        }
        public static string StreamData(Stream stream)
        {
            string reqSData = string.Empty;
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            reqSData = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return reqSData;
        }
    }
}
