using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService
{
    public class CustomerLogonService : CustomerLogon.CustomerLogonBase
    {
        private static long contactCounter = 0; 
        private readonly ILogger<CustomerLogonService> _logger;
        public CustomerLogonService(ILogger<CustomerLogonService> logger)
        {
            _logger = logger;
        }

        public override Task<LogonResponse> Logon(LogonRequest request, ServerCallContext context)
        {
            var contracts = new List<CustomerContract>()
            {
                new CustomerContract() {Contract = "Contrac"+ (++contactCounter), Created = Timestamp.FromDateTime(DateTime.UtcNow)},
                new CustomerContract() {Contract = "Contract"+ (++contactCounter), Created = Timestamp.FromDateTime(DateTime.UtcNow)},
            };
            var response = new LogonResponse()
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                CustomerInfo = new CustomerInfo()
                {
                    Detail = "Detail Text",
                    LastUpdateDate = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };
            response.CustomerInfo.Contacts.AddRange(contracts.ToArray());
            return Task.FromResult(response);
        }
    }
}