using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;

namespace PetStore.Pages
{
    public partial class forgotpassword : System.Web.UI.Page
    {
          PetStore.DB.Data oDB;
         PetStore.Class.User oUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Style.Add("display", "none");
            result.Style.Add("display", "none");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                error.Style.Add("display", "");
                result.Style.Add("display", "none");

            }
            else
            {
                
                oUser = new Class.User();
                oDB = new PetStore.DB.Data();
                oUser.Email = txtEmail.Text;
                if (oDB.IsUserExist(oUser))
                {
                    oUser = oDB.Login(txtEmail.Text, "tempassword12345");
                    //Guid oGuid = Guid.NewGuid();
                    Random oRandom = new Random();
                    int tempPassword = oRandom.Next(100000);
                    oUser.Password = oUser.LastName + tempPassword.ToString();
                    oDB.UpdateUser(oUser); //update the password with new password

                    //send an email witht the Guid password


                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage oMessage1 = new MailMessage();
                    oMessage1.Subject = "New password for One stop pet shop";
                    oMessage1.Body = "Hi, here is the new password, '" + oUser.Password  + "'. <br/> Once you log in the site, please update your password again.";
                    oMessage1.IsBodyHtml = true;

                    oMessage1.To.Add(new MailAddress(txtEmail.Text));
                    oMessage1.From = new MailAddress("test@hotmail.com"); // https://www.google.com/settings/security/lesssecureapps
                    smtpClient.Send(oMessage1);

                   //// SmtpClient client1 = new SmtpClient();
                   //// client1.Host = "smtp.gmail.com";
                   //// client1.Port = 587;
                   //// client1.UseDefaultCredentials = false;
                   //// client1.DeliveryMethod = SmtpDeliveryMethod.Network;
                   //// client1.EnableSsl = true;
                   //// client1.Credentials = new NetworkCredential("dtechtest5@gmail.com", "sendingemail");
                   ////MailMessage oMessage = new MailMessage();
                   //// oMessage.Subject = "hello";
                   //// oMessage.Body = "body";
                   //// oMessage.To.Add(new MailAddress(txtEmail.Text));
                   //// oMessage.From = new MailAddress("test@hotmail.com");
                   //// client1.Send(oMessage); 

                    
                   //// MailMessage objeto_mail = new MailMessage();
                   //// SmtpClient client3 = new SmtpClient();
                   //// client3.Port = 587;
                   //// client3.Host = "smtp.gmail.com";
                   //// client3.Timeout = 10000;
                   //// client3.DeliveryMethod = SmtpDeliveryMethod.Network;
                   //// client3.UseDefaultCredentials = false;
                   //// client3.EnableSsl = true;
                   //// client3.Credentials = new System.Net.NetworkCredential("dtechtest5@gmail.com", "sendingemail");
                   //// objeto_mail.From = new MailAddress("from@server.com");
                   //// objeto_mail.To.Add(new MailAddress(txtEmail.Text));
                   //// objeto_mail.Subject = "Password Recover";
                   //// objeto_mail.Body = "Message";
                   //// client3.Send(objeto_mail);

                    result.Style.Add("display", "");
                }
                else
                {
                    error.Style.Add("display", "");
                }
            }
        }
               

    }
}