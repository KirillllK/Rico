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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }

        }

        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }

        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }
    }
}
