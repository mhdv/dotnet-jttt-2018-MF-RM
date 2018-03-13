using HtmlAgilityPack;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BackgroundWorker m_oBackgroundWorker = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            work();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            outputBox.Text = "Pracuje, czekaj...";
            outputBox.Background = Brushes.OrangeRed;
        }

       public void StartWork()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWork();
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

        public void work()
        {
            
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF283655"));
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => 
            {
            WebClient site = new WebClient();
            Uri uriResult;
            bool result = Uri.TryCreate(urlBox.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
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
                        if (!imageExist) { outputBox.Text = "Nie znaleziono słowa na stronie"; outputBox.Background = Brushes.Red; }
                        else
                        {
                            string localFilename = @".\meme.png";
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(linkToImage, localFilename);
                            }



                            var fromAddress = new MailAddress("wysylaczmemow@gmail.com", "");
                            if (checkEmail() == true)
                            {
                                var toAddress = new MailAddress(mailBox.Text, "");
                                const string fromPassword = "haselkomaselko";
                                const string subject = "Wiadomość z programu JTTT";
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
                                    outputBox.Text = "Poprawnie wysłano wiadomość";
                                    System.IO.File.AppendAllText("./log.log", "Tekst: " + textBox.Text + " URL: " + urlBox.Text + " EMAIL: " + mailBox.Text+"\r\n");
                                    outputBox.Background = Brushes.Green;
                                }
                                return;
                            }
                            else
                            {
                                outputBox.Background = Brushes.Red;
                                outputBox.Text = "Podano nieprawidłowy adres email";
                            }
                        }
                    }
                }
            }
            else outputBox.Text = "Proszę wpisać poprawny adres strony";
            outputBox.Background = Brushes.Red;
            }));
        }

        public bool checkEmail()
        {
            try
            {
                MailAddress m = new MailAddress(mailBox.Text);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        private void urlBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            urlBox.Text = "";
        }
        private void textBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
        private void mailBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            mailBox.Text = "";
        }

    }
}
