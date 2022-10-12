using SendGrid;
using SendGrid.Helpers.Mail;

var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
var message = new SendGridMessage
{
    //TODO: replace 
    From = new EmailAddress("[FROM_EMAIL_ADDRESS]"),
    Subject = "Email with image",
    HtmlContent = /* lang=html */ @"<html>
    <body>
        <img src=""cid:IMAGE01""/>
    </body>
</html>"
};

//TODO: replace 
message.AddTo("[TO_EMAIL_ADDRESS]");

message.AddAttachment(new Attachment
{
    ContentId = "IMAGE01",
    Content = Convert.ToBase64String(File.ReadAllBytes("image.png")),
    Type = "image/png",
    Filename = "image.png",
    Disposition = "inline" // important!
});

await client.SendEmailAsync(message);