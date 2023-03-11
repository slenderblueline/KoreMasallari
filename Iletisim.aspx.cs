using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace KoreMasallari
{
    public partial class Iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

                
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("burakaytar.tr@gmail.com");
                mail.To.Add(epostatxt.Text);
                mail.Subject = adsoyadtxt.Text+" Kore Masallarından Mail";
                mail.Body = mesajtxt.Text;


                SmtpClient message = new SmtpClient();
                message.Credentials = new NetworkCredential("burakaytar.tr@gmail.com", "wk8vS9a29B9Yqy5");
                message.Port = 587;
                message.Host = "smtp.gmail.com";
                message.EnableSsl = true;
                message.Send(mail);

                

                String geribildirim = "Mesajınız iletildi, Geri bildirim için teşekkürler!";
                Label4.Text = geribildirim;
            }
        }





    }
}