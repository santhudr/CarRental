using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Api.Service
{
    public interface ISendEmailService
    {
        public Task<List<(string, DateTime, bool)>> SendAlert();
    }
}
