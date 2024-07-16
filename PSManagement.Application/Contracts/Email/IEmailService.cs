using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Email
{
    public interface IEmailService
    {
        Task SendAsync(String  recipient, String subject, String body);

    }
}
