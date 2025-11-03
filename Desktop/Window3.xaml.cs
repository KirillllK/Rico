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
            taskTitle.Text = "Go fishing with Stephen";
            taskDate.Text = "Дата: 15.01.2024";
            taskDescription.Text = "Встретиться со Стивеном у озера в 10:00. Взять рыболовные снасти.";
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            taskTitle.Text = "Go fishing with Stephen";
            taskDate.Text = "Дата: 15.01.2024";
            taskDescription.Text = "УУУУ";
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
