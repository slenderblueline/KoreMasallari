using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;

namespace KoreMasallari
{
    public partial class Arsiv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request["file"]))
            {
                String filename = Request["file"].ToString();

                if (filename.Substring(0, 2).Equals("tr"))
                {
                    String hikayenumarasi = filename.Substring(2);
                    int hikayenum = Convert.ToInt32(hikayenumarasi);
                    if (hikayenum < 10)
                    {
                        hikayenumarasi = "hikaye00" + hikayenum.ToString();
                    }else if(hikayenum < 100)
                    {
                        hikayenumarasi = "hikaye0" + hikayenum.ToString();
                    }else if(hikayenum < 1000)
                    {
                        hikayenumarasi = "hikaye" + hikayenum.ToString();
                    }
                    else { Response.End(); }

                    fileDownload(hikayenumarasi + "tr.txt", Server.MapPath("~/Textfiles/tr/" + hikayenumarasi+"tr.txt"));

                }
                else if(filename.Substring(0, 2).Equals("kr"))
                {
                    String hikayenumarasi = filename.Substring(2);
                    int hikayenum = Convert.ToInt32(hikayenumarasi);
                    if (hikayenum < 10)
                    {
                        hikayenumarasi = "hikaye00" + hikayenum.ToString();
                    }
                    else if (hikayenum < 100)
                    {
                        hikayenumarasi = "hikaye0" + hikayenum.ToString();
                    }
                    else if (hikayenum < 1000)
                    {
                        hikayenumarasi = "hikaye" + hikayenum.ToString();
                    }
                    else { Response.End(); }

                    fileDownload(hikayenumarasi + "kr.txt", Server.MapPath("~/Textfiles/kr/" + hikayenumarasi+"kr.txt"));
                }
            }

            String yol = Server.MapPath("");
            String[] krklasorler = Directory.GetFiles(yol + "/Textfiles/kr/");
            String[] trklasorler = Directory.GetFiles(yol + "/Textfiles/tr/");

            TableRow satır = new TableRow();
            TableHeaderCell hucre1 = new TableHeaderCell();
            hucre1.Text = "Hikayeler";
            satır.Cells.Add(hucre1);
            TableHeaderCell hucre2 = new TableHeaderCell();
            hucre2.Text = "Korece Dosya";
            satır.Cells.Add(hucre2);
            TableHeaderCell hucre3 = new TableHeaderCell();
            hucre3.Text = "Türkçe Dosya";
            satır.Cells.Add(hucre3);
            arsivtable.Rows.Add(satır);

            int i = 0;
            foreach (String alinan in trklasorler)
            {
                String[] hikayetr = File.ReadAllLines(alinan);
                TableRow yenisatir = new TableRow();

                //hikaye başlığını ilk satıra yazdık
                TableCell yenihucre1 = new TableCell();
                yenihucre1.Text = hikayetr[0];
                yenisatir.Cells.Add(yenihucre1);

                //türkçe  metin download linkleri oluşturduk
                TableCell yenihucre2 = new TableCell();
                HyperLink turkcedosyalink = new HyperLink();
                turkcedosyalink.Text = "Türkçe İndir";
                //int pathindextr = alinan.IndexOf("/Textfiles/");
                turkcedosyalink.NavigateUrl = "Arsiv.aspx?file=tr"+(i+1).ToString();
                //turkcedosyalink.
                yenihucre2.Controls.Add(turkcedosyalink);
                yenisatir.Cells.Add(yenihucre2);

                //korece metin download linklerini oluşturduk
                TableCell yenihucre3 = new TableCell();
                HyperLink korecedosyalink = new HyperLink();
                korecedosyalink.Text = "Korece İndir";
                //korecedosyalink.
                //int pathindexkr = krklasorler[i].IndexOf("/Textfiles/");
                //korecedosyalink.NavigateUrl = krklasorler[i].Substring(pathindexkr);
                korecedosyalink.NavigateUrl = "Arsiv.aspx?file=kr" + (i+1).ToString();
                yenihucre3.Controls.Add(korecedosyalink);
                yenisatir.Cells.Add(yenihucre3);

                arsivtable.Rows.Add(yenisatir);
                i++;
            }


        }//pload

        private void fileDownload(string fileName, string fileUrl)
        {
            Page.Response.Clear();
            bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
            if (!success)
                Response.Write("Downloading Error!");
            Page.Response.End();

        }

        public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
        {
            try
            {
                FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(myFile);
                try
                {
                    _Response.AddHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long fileLength = myFile.Length;
                    long startBytes = 0;

                    int pack = 10240; //10K bytes
                    int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = 206;
                        string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                        startBytes = Convert.ToInt64(range[1]);
                    }
                    _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                    if (startBytes != 0)
                    {
                        _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                    }
                    _Response.AddHeader("Connection", "Keep-Alive");
                    _Response.ContentType = "application/octet-stream";
                    _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                    for (int i = 0; i < maxCount; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(br.ReadBytes(pack));
                            Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    br.Close();
                    myFile.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}