using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket serverskiSocket;
        private bool isRunning = false;
        private ServerFrm serverFrm;
        private readonly object lockObj = new object();

        private List<Socket> aktivniSocketi = new List<Socket>();
        private readonly object socketLock = new object();

        private readonly object userLock = new object();
        private Dictionary<int, Socket> prijavljeniKorisnik = new Dictionary<int, Socket>();

        public void Start(ServerFrm serverFrm = null)
        {
            this.serverFrm = serverFrm;
            serverskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverskiSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            serverskiSocket.Listen();
            isRunning = true;
            Thread thread = new Thread(AcceptClients);
            thread.IsBackground = true;
            thread.Start();
        }
        public void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    Socket klijentskiSocket = serverskiSocket.Accept();
                    lock (lockObj)
                    {
                        lock (socketLock)
                        {
                            aktivniSocketi.Add(klijentskiSocket);
                        }
                        ClientHandler clientHandler = new ClientHandler(klijentskiSocket, serverFrm, this);
                        Task.Run(() => clientHandler.Handle());
                    }
                }
                catch (SocketException)
                {
                    if (isRunning)
                    {
                        serverFrm?.DodajLog("Greska prilikom prihvatanja stanodavca");
                    }
                }
            }
        }
        public void UkloniSocket(Socket socket)
        {
            lock (socketLock)
            {
                aktivniSocketi.Remove(socket);
            }
        }
        public void Stop()
        {
            if (serverskiSocket != null)
            {
                isRunning = false;
                try
                {
                    serverskiSocket.Close();
                }
                catch { }
                lock (socketLock)
                {
                    if (aktivniSocketi.Count > 0)
                    {
                        serverFrm?.DodajLog($"Zatvaram {aktivniSocketi.Count} aktivnih konekcija...");
                    }
                    foreach (var socket in aktivniSocketi.ToArray())
                    {
                        try
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Close();
                        }
                        catch { }
                    }
                    aktivniSocketi.Clear();
                }
                serverskiSocket = null;
                lock (userLock)
                {
                    prijavljeniKorisnik.Clear();
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////
        ///Prijavljeni korisnici
        public bool DaliJeKorisnikPrijavljen(int idStanodavac)
        {
            lock (userLock)
            {
                return prijavljeniKorisnik.ContainsKey(idStanodavac);
            }
        }
        public void DodajPrijavljenogKorisnika(int idStanodavac, Socket socket)
        {
            lock (userLock)
            {
                prijavljeniKorisnik[idStanodavac] = socket;
            }
        }
        public void UkloniPrijavljenogKorisnika(Socket socket)
        {
            lock (userLock)
            {
                var korisnik = prijavljeniKorisnik.FirstOrDefault(k => k.Value == socket);
                if (korisnik.Key!=0)
                {
                    prijavljeniKorisnik.Remove(korisnik.Key);
                }
            }
        }
    }
}
