
using Erasmus.Domain.Domain;
using Erasmus.Service.Interface;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using MimeKit.Utils;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Erasmus.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly IConfiguration _config;

        public EmailService(EmailSettings settings, IConfiguration configuration)
        {
            _settings = settings;
            _config = configuration;
        }

        public async Task SendMailAsync(Email email, string message, ICollection<UploadedFile> uploadedFiles)
        {
            var emailMessage = new MimeMessage
            {
                Sender = new MailboxAddress(_settings.SendersName, _settings.SmtpUserName),
                Subject = email.Subject
            };

            emailMessage.From.Add(new MailboxAddress(_settings.EmailDisplayName, _settings.SmtpUserName));

            var b = new BodyBuilder();
            if (uploadedFiles != null)
            {
                foreach (var file in uploadedFiles)
                {
                    var readStream = new FileStream(file.PathOnDisk, FileMode.Open, FileAccess.ReadWrite);
                    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(readStream);
                    var ms = new MemoryStream();
                    loadedDocument.Save(ms);
                    b.Attachments.Add(file.FileName, ms.ToArray());
                }
            }
            b.TextBody = @"Hi 👋," + email.Content;
            string path2 = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\logo.png";
            var image = b.LinkedResources.Add(@path2);

            image.ContentId = MimeUtils.GenerateMessageId();
            b.HtmlBody = string.Format(@"<body><p>Hi 👋,</p>
                    <p>""{1}""</p><br>
                    <p>{2}, <br/>
                    Erasmus team</p>
                    <img width='150px' height='150x' src=""cid:{0}""/></body>",image.ContentId, email.Content, message);
            emailMessage.Body = b.ToMessageBody();
            emailMessage.To.Add(new MailboxAddress(email.MailTo, _settings.SmtpUserName));
            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOption = _settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                    await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpServerPort, socketOption);

                    if(!string.IsNullOrEmpty(_settings.SmtpUserName))
                    {
                        await smtp.AuthenticateAsync(_settings.SmtpUserName, "diqfeibjinzockmq");
                    }

                    await smtp.SendAsync(emailMessage);


                }
            }
            catch(Exception ex)
            {

            }
        }

        public Task SendUnsentMailsAsync(List<Email> emails)
        {
            throw new NotImplementedException();
        }
    }
}
