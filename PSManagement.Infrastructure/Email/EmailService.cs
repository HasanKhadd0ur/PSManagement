using PSManagement.Application.Contracts.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string recipient, string subject, string body)
        {
            Console.WriteLine("a message sended to "+recipient+"|| body is "+body+"|| subject is"+subject);
            return Task.CompletedTask;

        }
    }
}
