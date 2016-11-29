using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  
    public void sendEmail()
    {
        if (String.IsNullOrEmpty(email.Text))
            return;
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("RECIVER@EMAIL");
            mail.From = new MailAddress("FAKE@EMAILSENDER");
            mail.Subject = "SUBJECT";

            mail.Body = "Email:  " + email.Text + "\n" + text.Value;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential
                 ("FAKE@EMAILSENDER", "FAKE@EMAILPASSWORD");
            smtp.Port = 587;


            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (Exception)
        {

        }
    }

    protected void buttonSubmit(object sender, EventArgs e)
    {

        try
        {
            sendEmail();
            name.Text = " ";
            surname.Text = " ";
            email.Text = " ";
            text.Value = " ";
        }

        catch (Exception) { }
    }
}
