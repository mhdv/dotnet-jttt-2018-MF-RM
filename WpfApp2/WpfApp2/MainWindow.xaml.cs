﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<JTTT> tasksList = new BindingList<JTTT>();

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
            outputBox.Text = "Dodano do listy";
            outputBox.Background = Brushes.Green;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            tasksListBox.ItemsSource = tasksList;
            tasksListBox.UpdateLayout();
            StartWork();
        }

        public void work()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                JTTT newTask = new JTTT();
                newTask.url = urlBox.Text;
                newTask.text = textBox.Text;
                newTask.mail = mailBox.Text;
                if (newTask.url == "" || newTask.text == "" || newTask.mail == "" || newTask.url == "Wprowadź URL strony" || newTask.text == "Podaj tekst do wyszukania" || newTask.mail == "Podaj mail na który wysłać obrazek")
                {
                    outputBox.Background = Brushes.Red;
                    outputBox.Text = "Wypełnij wszystkie pola";
                }
                else
                {
                    tasksList.Add(newTask);
                }
            }));
        }

        public void work_all()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF283655");
            SolidColorBrush brush = new SolidColorBrush(color);
            outputBox.Background = Brushes.OrangeRed;
            outputBox.Text = "Pracuję, czekaj...";
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                int errors = 0;
            for (int i = 0; i < tasksList.Count; ++i)
            {
                tasksList[i].work();
                switch (tasksList[i].errorStr)
                {
                    case "image":
                        errors++;
                        break;
                    case "internet":
                        errors++;
                        break;
                    case "mail":
                        errors++;
                        break;
                    case "address":
                        errors++;
                        break;
                    case "complete":
                        break;
                    default:
                        outputBox.Background = brush;
                        outputBox.Text = "Oczekiwanie na użytkownika";
                        break;
                }
            }
            if (errors == 0)
            {
                outputBox.Background = Brushes.Green;
                outputBox.Text = "Wykonano pomyślnie";
            }
            else
            {
                outputBox.Background = Brushes.Red;
                outputBox.Text = "Ilość błędów: " + errors.ToString();
            }
            tasksListBox.Items.Refresh();
            }));
        }
    


        private void urlBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if(urlBox.Text == "Wprowadź URL strony")
                urlBox.Text = "";
        }
        private void textBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "Podaj tekst do wyszukania")
                textBox.Text = "";
        }
        private void mailBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text == "Podaj mail do wysłania obrazka")
                mailBox.Text = "";
        }

        private void workBtn_Click(object sender, RoutedEventArgs e)
        {
            work_all();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            tasksList.Clear();
        }

        private void deserBtn_Click(object sender, RoutedEventArgs e)
        {
            tasksList.Clear();
            using (var stream = new FileStream("serial.xml", FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(BindingList<JTTT>));
                tasksList = (BindingList<JTTT>)XML.Deserialize(stream);
            }
            tasksListBox.ItemsSource = tasksList;
        }

        private void serBtn_click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tasksList.Count; ++i)
            {
                using (var stream = new FileStream("serial.xml", FileMode.Create))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(BindingList<JTTT>));
                    XML.Serialize(stream, tasksList);
                }
            }
        }
    }
}
