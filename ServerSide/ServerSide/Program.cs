using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            Console.WriteLine("Listening...");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            NetworkStream stream = client.GetStream();
            byte[] data = new byte[2048];
            stream.Read(data, 0, data.Length);

            string dataInString = Encoding.ASCII.GetString(data);

            PersonMan pm = new PersonMan();
            var field = JsonConvert.DeserializeObject<PersonMan>(dataInString);
            Console.WriteLine(field.ToString());
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int datas = stream.Read(buffer, 0, client.ReceiveBufferSize);
            string ch = Encoding.Unicode.GetString(buffer, 0, datas);
            Console.WriteLine("mESSAGE RECIEVED " + ch);
            client.Close();
            Console.ReadKey();

        }
    }
}
