using System;
using System.ComponentModel;
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
            
        }

       public void StartWork()
        {
            outputBox.Text = "Pracuje, czekaj...";
            outputBox.Background = Brushes.OrangeRed;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            StartWork();
        }

        public void work()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF283655");
            SolidColorBrush brush = new SolidColorBrush(color);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                JTTT newTask = new JTTT();
                newTask.url = urlBox.Text;
                newTask.text = textBox.Text;
                newTask.mail = mailBox.Text;
                if (newTask.url == "" || newTask.text == "" || newTask.mail == "")
                {
                    outputBox.Background = Brushes.Red;
                    outputBox.Text = "Wypełnij wszystkie pola";
                }
                else
                {
                    newTask.work();
                    switch (newTask.errorStr)
                    {
                        case "image":
                            outputBox.Background = Brushes.Red;
                            outputBox.Text = "Nie znaleziono obrazka";
                            break;
                        case "internet":
                            outputBox.Background = Brushes.Red;
                            outputBox.Text = "Brak połączenia z internetem";
                            break;
                        case "mail":
                            outputBox.Background = Brushes.Red;
                            outputBox.Text = "Adres mail jest niepoprawny";
                            break;
                        case "address":
                            outputBox.Background = Brushes.Red;
                            outputBox.Text = "Adres URL jest niepoprawny";
                            break;
                        case "complete":
                            outputBox.Background = Brushes.Green;
                            outputBox.Text = "Pomyślnie wysłano wiadomość";
                            break;
                        default:
                            outputBox.Background = brush;
                            outputBox.Text = "Oczekiwanie na użytkownika";
                            break;
                    }
                }
            }));
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
