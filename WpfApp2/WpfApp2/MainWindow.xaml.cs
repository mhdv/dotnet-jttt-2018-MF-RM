using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            WebClient site = new WebClient();
            Uri uriResult;
            bool result = Uri.TryCreate(urlBox.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
                label1.Content = "";
                if (checkForInternetConnection())
                {
                    string linkToImage = "";
                    string imageExtension = "";
                    string url = site.DownloadString(urlBox.Text);
                    bool isExtension = false;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(url);
                    bool imageExist = false;
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        if (link.InnerHtml.Contains(textBox.Text) && link.InnerHtml.Contains("http"))
                        {
                            imageExist = true;
                            int indexOfImage = link.InnerHtml.IndexOf("src=\"") + "src=\"".Length;
                            char tmp = '"';
                            while (link.InnerHtml[indexOfImage] != tmp)
                            {
                                linkToImage += link.InnerHtml[indexOfImage].ToString();
                                if (link.InnerHtml[indexOfImage].ToString() == ".") isExtension = true;
                                if (isExtension) imageExtension += link.InnerHtml[indexOfImage].ToString();
                                indexOfImage++;
                            }
                        }
                        if (!imageExist) label2.Content = "Takie słowo nie występuje na podanej stronie";
                        else
                        {
                            label2.Content = "";

                            string localFilename = @".\meme.png";
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(linkToImage, localFilename);
                            }

                            var fromAddress = new MailAddress("wysylaczmemow@gmail.com", "");
                            var toAddress = new MailAddress(mailBox.Text, "");
                            const string fromPassword = "haselkomaselko";
                            const string subject = "Memiczna wiadomość";
                            string body = "Wiadomość wygenerowana automatycznie, oto link do Twojego zdjęcia: " + linkToImage;

                            Attachment attachment;
                            attachment = new Attachment(localFilename);

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
                                label3.Content = "Poprawnie wysłano wiadomość";
                            }
                            return;
                        }
                    }
                }
            }
            else label1.Content = "Proszę wpisać poprawny adres strony";
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
                return false;
            }
        }
    }
}
