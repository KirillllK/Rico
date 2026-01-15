using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


        private List<TaskItem> tasks = new List<TaskItem>();

        public Window3()
        {
            InitializeComponent();
        }

        public void AddTaskToList(string title, string category, string description, DateTime selectedDate, DateTime currentTime)
        {
            TaskItem newTask = new TaskItem
            {
                Title = title,
                Category = category,
                Description = description,
                DueDate = selectedDate,
                CreatedTime = currentTime,
                IsCompleted = false
            };

            tasks.Add(newTask);
            UpdateListBox(); // Обновляем отображение
        }
        private void UpdateListBox()
        {
            ListBox.Items.Clear();

            foreach (var task in tasks)
            {
                // Создаем контейнер для элемента ListBox
                ListBoxItem listBoxItem = new ListBoxItem();

                // Создаем StackPanel с CheckBox и TextBlock
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.Margin = new Thickness(5);

                // CheckBox
                CheckBox checkBox = new CheckBox();
                checkBox.IsChecked = task.IsCompleted;
                checkBox.VerticalAlignment = VerticalAlignment.Center;
                checkBox.Margin = new Thickness(0, 0, 10, 0);
                checkBox.Checked += (s, e) =>
                {
                    task.IsCompleted = true;
                    UpdateListBox(); // Обновляем отображение
                };
                checkBox.Unchecked += (s, e) =>
                {
                    task.IsCompleted = false;
                    UpdateListBox(); // Обновляем отображение
                };

                // Текстовый блок с информацией
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"{task.Title}\n{task.CreatedTime:hh:mmtt}\n\n{task.Description}";
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.VerticalAlignment = VerticalAlignment.Center;

                panel.Children.Add(checkBox);
                panel.Children.Add(textBlock);

                // Устанавливаем панель как содержимое ListBoxItem
                listBoxItem.Content = panel;

                // Добавляем в ListBox
                ListBox.Items.Add(listBoxItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cb)
            {
                tex1.Text = DateTime.Now.ToString("dd.MM.yyyy");
                tex.Text = "";
                tex.Text += cb.Content + "\n";

            }
        }

 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу для удаления!", "Информация",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                // Получаем выбранную задачу
                TaskItem selectedTask = tasks[ListBox.SelectedIndex];

                // Сохраняем индекс перед удалением
                int selectedIndex = ListBox.SelectedIndex;

                // Удаляем задачу из списка (БЕЗ ПОДТВЕРЖДЕНИЯ)
                tasks.RemoveAt(selectedIndex);

                // Обновляем ListBox
                UpdateListBox();

                // Очищаем поля деталей
                tex.Text = "";
                tex1.Text = "";

                // Если после удаления остались задачи, выбираем следующую
                if (tasks.Count > 0)
                {
                    int newIndex = Math.Min(selectedIndex, tasks.Count - 1);
                    ListBox.SelectedIndex = newIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении задачи: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу для завершения!", "Информация",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                // Получаем выбранную задачу
                int selectedIndex = ListBox.SelectedIndex;
                TaskItem selectedTask = tasks[selectedIndex];

                // 1. Меняем статус на "завершено"
                selectedTask.IsCompleted = true;

                // 2. Сохраняем в переменную (добавь поле в класс)
                completedTasks.Add(selectedTask);

                // 3. Обновляем элемент в ListBox - делаем зачеркнутым с галочкой
                UpdateTaskInListBox(selectedIndex);

                // 4. Обновляем детали
                tex.Text = $"[✓] {selectedTask.Title}";
                tex1.Text = $"Завершено: {DateTime.Now:dd.MM.yyyy HH:mm}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private List<TaskItem> completedTasks = new List<TaskItem>();

        private void UpdateTaskInListBox(int index)
        {
            TaskItem task = tasks[index];

            // Создаем новый элемент
            ListBoxItem listBoxItem = new ListBoxItem();

            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(5);

            // CheckBox с галочкой
            CheckBox checkBox = new CheckBox();
            checkBox.IsChecked = true;
            checkBox.VerticalAlignment = VerticalAlignment.Center;
            checkBox.Margin = new Thickness(0, 0, 10, 0);
            checkBox.IsEnabled = false;

            // Текст с зачеркиванием
            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"{task.Title}\n{task.CreatedTime:hh:mmtt}\n\n{task.Description}";
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.TextDecorations = TextDecorations.Strikethrough;
            textBlock.Foreground = Brushes.Gray;

            panel.Children.Add(checkBox);
            panel.Children.Add(textBlock);
            listBoxItem.Content = panel;

            // Заменяем элемент в ListBox
            ListBox.Items[index] = listBoxItem;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                TaskItem selectedTask = tasks[ListBox.SelectedIndex];

                tex.Text = selectedTask.Title;

                tex1.Text = selectedTask.Description;
            }
            else
            {
                tex.Text = "";
                tex1.Text = "";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window4 f2 = new Window4();
            f2.Show();
            Hide();
        }
    }
    }


