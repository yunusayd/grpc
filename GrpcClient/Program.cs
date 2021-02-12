using System;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CustomerLogon.CustomerLogonClient(channel);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            while (true)
            {
                try
                {
                    var reply = await client.LogonAsync(
                        new LogonRequest() { UserName = "crazyboy34", Pass = "1453" });
                    Console.WriteLine("Token: " + JsonSerializer.Serialize(reply, options));
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

        }
    }
}
