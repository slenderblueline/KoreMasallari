using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace KoreMasallari
{
    public partial class Hikaye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String gelenhikaye = Request.QueryString["hikaye"];
            String yol = Server.MapPath("");
            String[] klasorler = Directory.GetFiles(yol + "/Textfiles/tr/");
            if(gelenhikaye==null || Convert.ToInt32(gelenhikaye)>klasorler.Length)
            {
                Label bulunamadimesaj = new Label();
                bulunamadimesaj.ID = "errmsj";
                bulunamadimesaj.Text= "<center><h1>Hikaye Bulunamadı Anasaya Dönüp Diğerlerine Bakabilirsin ):</h1></center>";
                PlaceHolder1.Controls.Add(bulunamadimesaj);
            }
            else
            {
                if(CheckBox1.Checked & CheckBox2.Checked)
                {
                    Card turcehikaye = new Card().Trhikayegetir(yol, Convert.ToInt32(gelenhikaye));
                    Card korecehikaye = new Card().Krhikayegetir(yol, Convert.ToInt32(gelenhikaye));
                    Label ikihikaye = new Label();
                    ikihikaye.ID = "ikilbl";
                    ikihikaye.Text = "<div class=krhikaye><h1>"+korecehikaye.Cardbaslik+"</h1>"+korecehikaye.Cardmetin+ "</div><div class=trhikaye><h1>"+
                        turcehikaye.Cardbaslik+ "</h1>"+turcehikaye.Cardmetin+"</div>";
                    PlaceHolder1.Controls.Add(ikihikaye);

                }
                else if(!CheckBox1.Checked & CheckBox2.Checked)
                {
                    //kr
                    Card korecehikaye = new Card().Krhikayegetir(yol, Convert.ToInt32(gelenhikaye));
                    Label krhikaye = new Label();
                    krhikaye.ID = "krhik";
                    krhikaye.Text = "<h1>" + korecehikaye.Cardbaslik + "</h1>" + korecehikaye.Cardmetin;

                    PlaceHolder1.Controls.Add(krhikaye);
                }
                else if(CheckBox1.Checked & !CheckBox2.Checked)
                {
                    //tr
                    Card turcehikaye = new Card().Trhikayegetir(yol, Convert.ToInt32(gelenhikaye));
                    Label trhikaye = new Label();
                    trhikaye.ID = "trhik";
                    trhikaye.Text = "<h1>"+turcehikaye.Cardbaslik+ "</h1>"+turcehikaye.Cardmetin;

                    PlaceHolder1.Controls.Add(trhikaye);
                }
            }
        }//pload
    }
}