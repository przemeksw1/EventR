using MailKit.Net.Smtp;
using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using EventR.Helpers;

namespace EventR.Services.Implementations
{
    public class EmailService
    {
        private const string Host = "localhost:3000";
        private readonly IOptions<EmailSettings> _options;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
       // private readonly IProductService _productService;

        public void SendConfirmationEmail(string address)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_options.Value.Email));
            message.To.Add(new MailboxAddress(address));
            message.Subject = "Potwierdzenie rejestracji";

            var token = _tokenService.GenerateConfirmationToken(address);
            var url = @"http://" + Host + "/Account/ConfirmEmail/" + token;
            var builder = new BodyBuilder
            {
                TextBody = $@"Kliknij w poniższy link lub skopiuj go do przeglądarki aby dokończyć rejestrację: {url}",
                HtmlBody = $@"<p>Kliknij w poniższy link lub skopiuj go do przeglądarki aby dokończyć rejestrację:<br></p><a href={url}>Link</a>"
            };
            message.Body = builder.ToMessageBody();

            Send(message);
        }

        private void Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_options.Value.Host, _options.Value.Port, true);
                client.Authenticate(_options.Value.Email, _options.Value.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
