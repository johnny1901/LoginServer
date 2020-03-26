using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LoginServer.Utility;
using static LoginServer.Networks.Request;

namespace LoginServer.Networks
{     
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
                HttpListenerContext context = await listener.GetContextAsync(); //대기 시작
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;                         

                string reqData = StreamData(request.InputStream);

                if (request.HttpMethod == "GET" && !request.Url.ToString().Contains("favicon.ico"))
                {                    
                    //Console.WriteLine("\n[ INFO ] : {0} \n {1} \n GET Connection!", request.RemoteEndPoint.Address, request.Url);
                    //byte[] responseError = Encoding.UTF8.GetBytes(String.Format("Access Denied!"));
                    //response.ContentType = "text/html; charset=utf-8";
                    //response.ContentLength64 = responseError.LongLength;
                    //await response.OutputStream.WriteAsync(responseError, 0, responseError.Length);
                    //response.Close();
                }

                if (!request.Url.ToString().Contains("favicon.ico") && request.HttpMethod == "POST")
                {
                    //Console.WriteLine("\nㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    //Console.WriteLine("\n[Connection Detect] : {0} \n Method Type :{1} \n {2}", request.Url, request.HttpMethod, reqData);
                    //Console.WriteLine("\nㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

                    // 데이터 전달
                    Request req = new Request();
                    req.RequestData(
                        request.Url.ToString(),
                        request.HttpMethod.ToString(),
                        reqData,
                        request.RemoteEndPoint.Address.ToString());                     
                }
                    
                

                if (request.HttpMethod == "POST")
                {
                    Random rand = new Random();
                    byte[] responseToken = Encoding.UTF8.GetBytes(String.Format("{0}", rand.Next()));
                    response.ContentType = "text/html; charset=utf-8";
                    response.ContentLength64 = responseToken.LongLength;
                    await response.OutputStream.WriteAsync(responseToken, 0, responseToken.Length);
                    response.Close();
                }      
            }
        }
        public static string StreamData(Stream stream)
        {
            string reqData = string.Empty;
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            reqData = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();            
            return reqData;
        }
    }
}
