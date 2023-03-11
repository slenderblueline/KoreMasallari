using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace KoreMasallari
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String yol = Server.MapPath("");

            ArrayList cardliste = new Card().Cardgetir(yol);

            System.Web.UI.HtmlControls.HtmlGenericControl sagmenu = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            sagmenu.Attributes.Add("class", "sag");
            sagmenu.InnerHtml = "<ul><li>Son Hikayeler</li>";
            int i = 0;
            foreach (Card alinan in cardliste)
            {
                sagmenu.InnerHtml += "<li><a href=Hikaye.aspx?hikaye="+i.ToString()+">"+alinan.Cardbaslik+"</a></li>";
                i++;
            }
            sagmenu.InnerHtml += "</ul>";
            PlaceHolder2.Controls.Add(sagmenu);
            addmainDiv(cardliste);
        }

        protected void addmainDiv(ArrayList cardlist)
        {
            int i = 0;
            foreach(Card alinancard in cardlist)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                newdivs.Attributes.Add("class", "card");
                newdivs.InnerHtml = "<a href=Hikaye.aspx?hikaye=" + i.ToString() +"><div class=cardbaslik>" + alinancard.Cardbaslik +
                    "</div><div class=cardozet>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;" + alinancard.Cardmetin.Substring(0,650)+"..."+
                    "</div></a>";
                PlaceHolder1.Controls.Add(newdivs);
                i++;
            }
        }
    }
}