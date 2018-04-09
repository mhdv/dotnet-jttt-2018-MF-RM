﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.Linq;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public BindingList<JTTT> tasksList = new BindingList<JTTT>();
        
        SQLdb myDB = new SQLdb();
        public bool firstRun = true;

   

        public MainWindow()
        {
            InitializeComponent();
            tasksListBox.ItemsSource = tasksList;
            updateList();
        }

     

        public void updateList()
        {
            tasksList_update();
            tasksListBox.UpdateLayout();
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
            StartWork();
            updateList();
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
                    using(var ctx = new JTTTdbcontext())
                    {
                        JTTTdb tmpTask = new JTTTdb { URL = newTask.url, mail = newTask.mail, text = newTask.text };
                        ctx.task.Add(tmpTask);
                        ctx.SaveChanges();
                    }
                    updateList();
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

        private void templateBtn_Click(object sender, RoutedEventArgs e)
        {
            urlBox.Text = "http://demotywatory.pl";
            textBox.Text = "Polska";
            mailBox.Text = "mehowpol@gmail.com";
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("This will delete all data. Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (var ctx = new JTTTdbcontext())
                {
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE [JTTTdbs]");
                    ctx.SaveChanges();
                }
                updateList();
            }

        }

        public void tasksList_update()
        {
            tasksList.Clear();

            using (var ctx = new JTTTdbcontext())
            {
                //myDB.addToDb(ctx);
                //foreach (var t in ctx.task)
                //{

                //}

                var query = from b in ctx.task orderby b.ID select b;

                foreach (var item in query)
                {
                    JTTT tmp = new JTTT();
                    tmp.url = item.URL;
                    tmp.text = item.text;
                    tmp.mail = item.mail;
                    tmp.ID = item.ID;
                    tasksList.Add(tmp);//(item.ID + "." + " " + item.URL + " " + item.text + " " + item.mail);
                }

            }

        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(tasksListBox.SelectedIndex==-1)
            {
                outputBox.Background = Brushes.Red;
                outputBox.Text = "Nie zaznaczono elementu";
            }
            else
            {
                int tmpID = tasksList[tasksListBox.SelectedIndex].ID;
                outputBox.Background = Brushes.Green;
                outputBox.Text = "Usunięto";
                using (var ctx = new JTTTdbcontext())
                {
                    JTTTdb tmp = new JTTTdb() { ID = tmpID };
                    ctx.task.Attach(tmp);
                    ctx.task.Remove(tmp);
                    ctx.SaveChanges();
                    //Console.WriteLine(tmpID);
                    //Console.WriteLine(tasksList[tasksListBox.SelectedIndex].ID);

                    //Console.WriteLine(tasksList[tasksListBox.SelectedIndex].ID);
                }
                updateList();
            }
        }
    }
}
