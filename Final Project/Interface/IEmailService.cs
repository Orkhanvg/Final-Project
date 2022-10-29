using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> email, string subject, string message);

    }
}
