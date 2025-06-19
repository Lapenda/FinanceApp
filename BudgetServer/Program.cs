using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FinanceApp.Models;
using FinanceApp.Managers;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        TcpListener server = null;
        try
        {
            int port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, port);

            server.Start();
            Console.WriteLine("Poslužitelj pokrenut na portu " + port);

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] parts = data.Split(',');
                int userId = int.Parse(parts[0]);
                float limit = float.Parse(parts[1]);
                float spent = float.Parse(parts[2]);
                int categoryId = int.Parse(parts[3]);

                bool exceeded = spent > limit;

                byte response = exceeded ? (byte)1 : (byte)0;
                stream.WriteByte(response);

                if (exceeded)
                {
                    var transactions = GetTransactionsForUser(userId, categoryId);
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        formatter.Serialize(ms, transactions);
                        byte[] transactionData = ms.ToArray();
                        stream.Write(BitConverter.GetBytes(transactionData.Length), 0, 4);
                        stream.Write(transactionData, 0, transactionData.Length);
                    }
                }

                stream.Close();
                client.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Greška: " + ex.Message);
        }
        finally
        {
            server?.Stop();
        }
    }

    static List<Transaction> GetTransactionsForUser(int userId, int categoryId)
    {
        var transactionManager = new TransactionManager(userId);

        var transactions = transactionManager.GetAllTransactions().Where(t => t.Category.Id == categoryId).ToList();
        return transactions;
    }
}