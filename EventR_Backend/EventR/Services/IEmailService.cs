using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventR.ViewModels;

namespace EventR.Services
{
    public interface IEmailService
    {
        void SendConfirmationEmail(string address);
        void SendResetPassword(string address);
    }
}
