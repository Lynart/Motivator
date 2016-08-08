class EmailClient
{
    string username;
    string password;
    string host;
    int port;
    int delay;
    bool emailConstructed;
    List<MailMessage> email;

    public EmailClient(string username, string password, string host, int port = 0, int delay = 0)
    {
        this.username = username;
        this.password = password;
        this.host = host;
        this.port = port;
        this.delay = delay;
        emailConstructed = false;
        email = new List<MailMessage>();
    }

    //Default constructor using predetermined server
    public EmailClient()
    {
        this.username = "invalid@email.com";
        this.password = "harros";
        this.host = "smtp.googlemail.com";
        this.port = 0;
        this.delay = 30000;
        emailConstructed = false;
        email = new List<MailMessage>();
    }


    //This method creates an email to be sent. Note you can construct more than one and batch send
    public bool ConstructEmail(string toEmail, string fromName, string subject, string body, string toAttach = null, List<string> toCCs = null, List<string> toBCCs = null)
    {
        try
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(toEmail));
            email.From = new MailAddress(username, fromName);
            email.Subject = subject;
            email.Body = body;
            email.IsBodyHtml = true;

            if (toCCs != null)
            {
                if (toCCs.Count > 0)
                {
                    foreach (string emailAddress in toCCs)
                    {
                        email.CC.Add(new MailAddress(emailAddress));
                    }
                }
            }

            if (toBCCs != null)
            {
                if (toBCCs.Count > 0)
                {
                    foreach (string emailAddress in toBCCs)
                    {
                        email.Bcc.Add(new MailAddress(emailAddress));
                    }
                }
            }

            if (toAttach != null)
            {
                if (File.Exists(toAttach))
                {
                    Attachment att = new Attachment(toAttach, MediaTypeNames.Application.Octet);
                    email.Attachments.Add(att);
                }
                else
                {
                    Console.WriteLine(toAttach + " NOT FOUND");
                    return false;
                }
            }
            this.email.Add(email);
            emailConstructed = true;
            return true;
        }

        catch (Exception e)
        {
            Console.WriteLine(toEmail + " is not a valid email address.");
            return false;
        }
    }

    //Send all messages
    public bool SendMessage()
    {
        try
        {
            if (emailConstructed)
            {
                SmtpClient mailClient = new SmtpClient();
                mailClient.Host = host;
                if (port != 0)
                {
                    mailClient.Port = port;
                }
                mailClient.Credentials = new System.Net.NetworkCredential(username, password);
                mailClient.EnableSsl = true;
                foreach (MailMessage mail in email)
                {
                    mailClient.Send(mail);
                    string sentTo = mail.To.ToString();
                    Console.WriteLine("Email sent to: " + sentTo + '.');
                    Thread.Sleep(delay);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Email failed validation");
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Enter something to continue:");
            Console.ReadLine();
            return false;
        }
    }
}