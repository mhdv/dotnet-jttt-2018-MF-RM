using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Xml.Serialization;

namespace WpfApp2
{
    public class JTTT
    {
        public string url = "";
        public string text = "";
        public string mail = "";
        public string filename = "";
        public string errorStr = "";

        public override string ToString()
        {
            if(errorStr == "")
                return "NA STRONIE: " + url + ", ZNAJDŹ: " + text + ", ORAZ WYŚLIJ NA: " + mail;
            else if(errorStr == "complete")
                return "SUKCES! NA STRONIE: " + url + ", ZNAJDŹ: " + text + ", ORAZ WYŚLIJ NA: " + mail;
            else
                return "BŁĄD! NA STRONIE: "+ url + ", ZNAJDŹ: " + text + ", ORAZ WYŚLIJ NA: " + mail;
        }
        public string FindImage(WebClient site)
        {
            string linkToImage = "";
            bool imageExist = false;
            if (checkSite(this.url) == true)
            {
                string url = site.DownloadString(this.url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(url);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    if (link.InnerHtml.Contains(this.text) && link.InnerHtml.Contains("http"))
                    {
                        imageExist = true;
                        int indexOfImage = link.InnerHtml.IndexOf("src=\"") + "src=\"".Length;
                        char tmp = '"';
                        while (link.InnerHtml[indexOfImage] != tmp)
                        {
                            linkToImage += link.InnerHtml[indexOfImage].ToString();
                            indexOfImage++;
                        }
                    }
                    if (imageExist) return linkToImage;
                    else errorStr = "image";
                }
                return linkToImage;
            }
            else
            {
                errorStr = "address";
                return linkToImage;
            }
        }

        public bool checkSite(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        public bool checkEmail()
        {
            try
            {
                if (this.mail != "")
                {
                    MailAddress m = new MailAddress(this.mail);


                    return true;
                }
                return false;
            }
            catch (FormatException)
            {
                errorStr = "mail";
                return false;
            }
        }

        public bool SendMail(string linkToImage)
        {
            var fromAddress = new MailAddress("wysylaczmemow@gmail.com", "");
            if (this.checkEmail() == true)
            {
                var toAddress = new MailAddress(this.mail, "");
                const string fromPassword = "haselkomaselko";
                const string subject = "Wiadomość z programu JTTT";
                string body = "Wiadomość wygenerowana automatycznie, oto link do Twojego zdjęcia: " + linkToImage;

                Attachment attachment;
                attachment = new Attachment(this.filename);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                })
                {
                    message.Attachments.Add(attachment);
                    smtp.Send(message);    
                    System.IO.File.AppendAllText("./jttt.log", "Tekst: " + this.text + " URL: " + this.url + " EMAIL: " + this.mail + "\r\n");
                }
                errorStr = "complete";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                errorStr = "internet";
                return false;
            }
        }

        public void work()
        {
            WebClient site = new WebClient();
            Uri uriResult;
            bool result = Uri.TryCreate(this.url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
                if (checkForInternetConnection())
                {
                    string linkToImage = FindImage(site);
                    if (linkToImage == "") { }
                    else
                    {
                        this.filename = @".\meme.png";
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(linkToImage, this.filename);
                        }
                        SendMail(linkToImage);

                    }
                }
            }
            else errorStr = "address";
        }
    }
}
