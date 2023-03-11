using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;

namespace KoreMasallari
{
    public class Card
    {
        String cardbaslik;
        String cardmetin;

        public Card()
        {
        }

        public string Cardbaslik { get => cardbaslik; set => cardbaslik = value; }
        public string Cardmetin { get => cardmetin; set => cardmetin = value; }

        public Card(string cardbaslik, string cardmetin)
        {
            this.cardbaslik = cardbaslik;
            this.cardmetin = cardmetin;
        }

        public ArrayList Cardgetir(String yol)
        {
            ArrayList hikayeler = new ArrayList();
            String[] klasorler = Directory.GetFiles(yol + "/Textfiles/tr/");

            for (int i=1; i <= klasorler.Length; i++)
            {
                int a = i - 1;
                String[] hikayetr = File.ReadAllLines(klasorler[a]);
                String hikayemetin = String.Join("",hikayetr);
                Card yenicard = new Card(hikayetr[0], hikayemetin);
                hikayeler.Add(yenicard);
            }
            return hikayeler;
        }

        public Card Trhikayegetir(String yol, int hikayesayi)
        {
            String[] klasorler = Directory.GetFiles(yol + "/Textfiles/tr/");
            String[] hikayetr = File.ReadAllLines(klasorler[hikayesayi]);
            String hikayemetin = "";
            int i = 0;
            foreach(String alinan in hikayetr)
            {
                if (i > 0)
                {
                    hikayemetin += "<p>" + alinan + "</p>";
                }
                i++;
            }
            //String hikayemetin = String.Join("", hikayetr);

            Card yenicard = new Card(hikayetr[0], hikayemetin);
            return yenicard;
        }
        public Card Krhikayegetir(String yol, int hikayesayi)
        {
            String[] klasorler = Directory.GetFiles(yol + "/Textfiles/kr/");
            String[] hikayekr = File.ReadAllLines(klasorler[hikayesayi]);
            String hikayemetin = "";
            int i = 0;
            foreach (String alinan in hikayekr)
            {
                if (i > 0)
                {
                    hikayemetin += "<p>" + alinan + "</p>";
                }
                i++;
            }
            //String hikayemetin = String.Join("", hikayekr);
            Card yenicard = new Card(hikayekr[0], hikayemetin);
            return yenicard;
        }
    }
}