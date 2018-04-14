using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace WpfApp2
{
    public class JTTT
    {
        public string tasktype = "";
        public string responsetype = "";
        public string url = "";
        public string text = "";
        public string mail = "";
        public string filename = "";
        public string errorStr = "";
        public int ID;
        public string name = "";
        public string city = "";
        public string desc = "";
        public double temp;
        public int press;
        public int humid;
        public string wetid;
        public int tempCase;


        public override string ToString()
        {
            if (errorStr == "" && responsetype == "mail" && tasktype == "find")
                return url + "    \\/\\    " + text + "    /\\/    " + mail;
            else if (errorStr == "" && responsetype == "mail" && tasktype == "weather")
                return "Wyślij pogodę w mieście \"" + city + "\" na \"" + mail + "\"";
            else if (errorStr == "" && responsetype == "saveas" && tasktype == "find")
                return "Zapisz na dysku" + "    \\/\\    " + url + "    \\/\\    " + text;
            else if (errorStr == "" && responsetype == "saveas" && tasktype == "weather")
                return "Zapisz pogodę z miasta " + city + " na dysku";
            else if (errorStr == "complete" && responsetype == "mail" && tasktype == "find")
                return "SUKCES! Wysłano obrazek z \"" + url + "\" na adres \"" + mail + "\"";
            else if (errorStr == "complete" && responsetype == "saveas" && tasktype == "find")
                return "SUKCES! Zaspisano obrazek z \"" + url + "\" pod nazwą \"" + this.filename + "\"";
            else if (errorStr == "complete" && responsetype == "mail" && tasktype == "weather")
                return "SUKCES! Pomyślnie wysłano pogodę z miasta " + city + " na " + mail;
            else if (errorStr == "complete" && responsetype == "saveas" && tasktype == "weather")
                return "SUKCES! Zapisano pogodę z miasta " + city + " pod nazwą \"" + this.filename + "\"";
            else if (errorStr == "" && responsetype == "display" && tasktype == "find")
                return "Wyświetl " + url + "    \\/\\    " + text;
            else if (errorStr == "" && responsetype == "display" && tasktype == "weather")
                return "Wyświetl pogodę w mieście " + city;
            else if (errorStr == "complete" && responsetype == "display" && tasktype == "find")
                return "SUKCES! Wyświetlono \"" + text + "\"z \"" + url + "\"";
            else if (errorStr == "complete" && responsetype == "display" && tasktype == "weather")
                return "SUKCES! Wyświetlono pogodę z miasta " + city;
            else if (errorStr == "image")
                return "BŁĄD! Strona \"" + url + "\" nie zawiera obrazka z tagiem \"" + text + "\"";
            else if (errorStr == "address")
                return "BŁĄD! Nie odnaleziono strony \"" + url + "\"";
            else if (errorStr == "internet")
                return "BŁĄD! Sprawdź połączenie z internetem";
            else if (errorStr == "mail")
                return "BŁĄD! Podano niepoprawny adres e-mail \"" + mail + "\"";
            else if (errorStr == "city")
                return "BŁĄD! Podana nazwa miasta jest niepoprawna";
            else if (errorStr == "temp")
                return "BŁĄD! Temperatura w " + city + " jest mniejsza niż " + tempCase;
            else
                return "BŁĄD! " + url + "    +    " + text + "    ->    " + mail;
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

        public bool SendWeather()
        {
            var fromAddress = new MailAddress("wysylaczmemow@gmail.com", "");
            if (this.checkEmail() == true)
            {
                var toAddress = new MailAddress(this.mail, "");
                const string fromPassword = "haselkomaselko";
                const string subject = "Wiadomość z programu JTTT";
                string body = "Wiadomość wygenerowana automatycznie, oto dzisiejsza pogoda w mieście: " + city + "\n" +
                    "Temperatura powietrza wynosi " + temp + " stopni.\n" +
                    "Ciśnienie wynosi " + press + " hektopaskali.\n" +
                    "Wilgotność powietrza na poziomie " + humid + ".\n" +
                    "Ogólnie pogodę można opisać słowami: " + desc + ".";



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
                    smtp.Send(message);
                    System.IO.File.AppendAllText("./jttt.log", " Miasto: " + this.name + " EMAIL: " + this.mail + "\r\n");
                }
                errorStr = "complete";
                return true;
            }
            else
            {
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
            if (checkForInternetConnection())
            {
                if (tasktype == "find")
                {
                    WebClient site = new WebClient();
                    Uri uriResult;
                    bool result = Uri.TryCreate(this.url, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (result)
                    {
                        string linkToImage = FindImage(site);
                        if (linkToImage == "")
                        {
                            errorStr = "image";
                            return;
                        }
                        if (responsetype == "saveas")
                        {
                            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                            dlg.FileName = this.text; // Default file name
                            dlg.DefaultExt = ".png"; // Default file extension
                            dlg.Filter = "Image (.png)|*.png"; // Filter files by extension

                            // Show save file dialog box
                            Nullable<bool> resultBool = dlg.ShowDialog();

                            // Process save file dialog box results
                            if (resultBool == true)
                            {
                                // Save document
                                this.filename = dlg.FileName;
                            }
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(linkToImage, this.filename);
                            }
                            errorStr = "complete";
                        }
                        this.filename = "meme.png";
                        if (responsetype == "mail")
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(linkToImage, this.filename);
                            }
                            if (!SendMail(linkToImage))
                                errorStr = "address";
                        }
                        this.filename = "meme.png";
                        if (responsetype == "display" /*&& tasktype=="meme"*/)
                        {


                            //var image = new Image();
                            //BitmapImage bitmap = new BitmapImage();
                            //bitmap.BeginInit();
                            //bitmap.UriSource = new Uri(linkToImage, UriKind.Absolute);
                            //bitmap.EndInit();
                            //image.Source = bitmap;
                            Window2 win2 = new Window2();
                            var image = new Image();
                            var fullFilePath = linkToImage;

                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                            bitmap.EndInit();

                            image.Source = bitmap;

                            win2.canvas.Children.Add(image);


                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(linkToImage, this.filename);
                            }

                            win2.ShowDialog();

                            errorStr = "complete";
                        }
                    }
                }
                else if (tasktype == "weather")
                {
                    using (WebClient client = new WebClient())
                    {
                        string fullcityname = city[0].ToString().ToUpper() + city.Substring(1).ToLower();

                        city = fullcityname;
                        string weatherJson = client.DownloadString(findweather(city));
                        var wth = JsonConvert.DeserializeObject<jsonClass.RootObject>(weatherJson);

                        this.name = wth.name;
                        this.temp = wth.main.temp;
                        this.press = wth.main.pressure;
                        this.humid = wth.main.humidity;
                        this.desc = wth.weather[0].description;
                        int tmpInd = weatherJson.IndexOf("\"icon\":\"");
                        this.wetid = weatherJson.Substring(tmpInd + "\"icon\":\"".Length, 3);
                    }
                    if(tempCase < this.temp)
                    {
                        if (responsetype == "mail")
                        {
                            if (!SendWeather())
                                errorStr = "address";
                        }

                        else if (responsetype == "saveas")
                        {
                            string content = "Oto dzisiejsza pogoda w mieście: " + name + "\n" +
                " Temperatura powietrza wynosi " + temp + " stopni.\n" +
                "Ciśnienie wynosi " + press + " hektopaskali.\n" +
                "Wilgotność powietrza na poziomie " + humid + ".\n" +
                "Ogólnie pogodę można opisać słowami: " + desc + ".";
                            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                            dlg.FileName = "pogoda"; // Default file name
                            dlg.DefaultExt = ".txt"; // Default file extension
                            dlg.Filter = "txt files (*.txt)|*.txt"; // Filter files by extension

                            // Show save file dialog box
                            Nullable<bool> resultBool = dlg.ShowDialog();

                            // Process save file dialog box results
                            if (resultBool == true)
                            {
                                // Save document
                                StreamWriter writer = new StreamWriter(dlg.OpenFile());
                                writer.Write(content);
                                writer.Dispose();
                                writer.Close();
                                this.filename = dlg.FileName;
                            }
                            errorStr = "complete";
                        }
                        else if (responsetype == "display")
                        {
                            string content = "Oto dzisiejsza pogoda w mieście: " + name + "\n" +
                "Temperatura powietrza wynosi " + temp + " stopni.\n" +
                "Ciśnienie wynosi " + press + " hektopaskali.\n" +
                "Wilgotność powietrza na poziomie " + humid + ".\n" +
                "Ogólnie pogodę można opisać słowami: " + desc + ".";
                            Window3 win3 = new Window3();
                            win3.label.Content = content;

                            var image = new Image();

                            var fullFilePath = @"http://openweathermap.org/img/w/" + this.wetid + ".png";
                            Console.WriteLine(this.wetid);

                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                            bitmap.EndInit();

                            image.Source = bitmap;

                            win3.weatherIcon.Children.Add(image);

                            win3.ShowDialog();
                        }

                    }
                    else
                    {
                        errorStr = "temp";
                    }


                }

            }
            else { errorStr = "internet"; return; }
            


            

        }

            public string findweather(string city)
            {
                string weatherLink = "";
                string appId = "014b5d4258bc8726f9bda9865f5a7a66";
                weatherLink = "http://api.openweathermap.org/data/2.5/weather?q=" + city + ",pl&units=metric&APPID=" + appId;

                return weatherLink;
            }
        
    }
}
