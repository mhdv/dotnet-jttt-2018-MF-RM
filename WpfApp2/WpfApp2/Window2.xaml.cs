using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Image image;

        public Image Image { get; set; }


        public Window2()
        {
            InitializeComponent();
        }

        public Window2(string imgsrc):this()

        {
            
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(imgsrc, UriKind.Absolute));
          

        }
    }
}
