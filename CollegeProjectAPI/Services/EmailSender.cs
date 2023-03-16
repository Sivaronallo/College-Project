 using Microsoft.AspNetCore.Identity.UI.Services;
 using System.Net.Mail;
 using CollegeProject.Core.Entities.Message;
 using CollegeProject.Core.Interfaces;
 using CollegeProject.Infrastructure.Data;
 using Microsoft.Extensions.Options;

 namespace CollegeProject.Api.Services; 

 public class EmailSender : IEmailSender
 {
     private readonly IRepository<EmailLog> _emailLogRepository;
     //private readonly IReadRepository<SmsMaskPattern> _smsMaskPatternReadRepository;
     private readonly CollegeSetting _collegeSetting;
     public EmailSender(IOptions<CollegeSetting> collegeSettings, IRepository<EmailLog> emailLogRepository)
     {
         _emailLogRepository = emailLogRepository;
         _collegeSetting = collegeSettings.Value;
     }
     public async Task SendEmailAsync(string email, string subject, string message)
     {
         /* To do when save important OTP
          var mask = new ContentMask(_smsMaskPatternReadRepository);
         string maskedMessage = await mask.MaskTheMessage(message);*/

         var model = new EmailLog
         {
             EmailId = email,
             Body = message,
             Subject = subject,
             SentTimeStamp = DateTime.Now
         };
         await _emailLogRepository.AddAsync(model);
         await Execute(subject, message, email);

     }

     private async Task Execute(string subject, string message, string email)
     {
         SmtpClient client = new();
         var isLocalEmailEnabled = _collegeSetting.EnabledLocalEmail;
         if (isLocalEmailEnabled)
         {
             client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
             client.PickupDirectoryLocation = @"D:\Delete";
         }
         else
         {
             client.DeliveryMethod = SmtpDeliveryMethod.Network;
             client.Host = "relay.nic.in";
             client.Port = 25;
         }
         MailMessage mm = new()
         {
             Sender = new MailAddress(_collegeSetting.MailAddress, "UDH Py"),
             From = new MailAddress(_collegeSetting.MailAddress, "UDH Py")
         };
         mm.To.Add(new MailAddress(email));
         mm.Subject = subject;
         mm.Body = message;
         mm.IsBodyHtml = true;

         //mm.Priority = MailPriority.High;

         /*Attachment a = new Attachment("photo.jpg",
         System.Net.Mime.MediaTypeNames.Image.Jpeg);
         mm.Attachments.Add(a);*/

         await client.SendMailAsync(mm);
     }
}