using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BogLib;

namespace TCPBogServer
{
    internal class Bogserver
    {
        private static List<Bog> bogs = new List<Bog>()
        {
            new Bog("title", "fofatter", 500, "1234567890123")

        };
        

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
                String command = vs[0];
                String test = bogs.ToString();
                String mytest = Isbn13;
                if (command == "HentAlle")
                {
                    sw.WriteLine(strRetur + test);
                    sw.Flush();
                }
            }
        }
    }
}