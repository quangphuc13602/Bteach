using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Application.SendMail
{
    public interface IMailService
    {
        Task SenEmailAsync(MailRequest mailRequest);
    }
}
