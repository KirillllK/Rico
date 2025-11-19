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
using static Desktop.Window3;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void text1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string title = text.Text;
            string category = text1.Text;
            string description = text2.Text;
            DateTime selectedDate = data.SelectedDate ?? DateTime.Now;
            DateTime currentTime = DateTime.Now;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Введите категорию задачи!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Window3 window3 = new Window3();
                window3.AddTaskToList(title, category, description, selectedDate, currentTime);
                window3.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании задачи: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                MessageBox.Show("Название задачи не может быть пустым!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                text.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(text1.Text))
            {
                MessageBox.Show("Категория не может быть пустой!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                text1.Focus();
                return false;
            }

            return true;
        }
        
    }
}
