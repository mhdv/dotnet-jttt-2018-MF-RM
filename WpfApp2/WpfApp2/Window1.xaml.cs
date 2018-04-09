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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static bool agreed = false;

        public Window1()
        {
            InitializeComponent();
        }
        
        private void btnTAK_Click(object sender, RoutedEventArgs e)
        {
            agreed = true;
            this.Close();
        }

        private void btnNIE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
