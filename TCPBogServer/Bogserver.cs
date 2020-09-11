using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPBogServer
{
    internal class Bogserver
    {
        internal void Start()
        {
           TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
           server.Start();
           while (true)
           {
               TcpClient socket = server.AcceptTcpClient();
               Task.Run(() =>
               {
                   TcpClient tempSocket = socket;
                   DoClient(tempSocket);
               });
           }
        }

        private void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            while (true)
            {
                String str = sr.ReadLine();
                String[] vs = str.Split(" ");

                String strRetur = ("Resultat = ");
                String test = vs[0];
                if (test == "HentAlle")
                {
                    sw.WriteLine(strRetur + "virker ikke lige pt");
                }
            }
        }
    }
}