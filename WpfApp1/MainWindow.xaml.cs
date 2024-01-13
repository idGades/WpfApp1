//MainWindow.xaml.cs
using NHotkey;
using NHotkey.Wpf;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Entry> entries = [];

        public object? ConsoleKeys { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            entriesListBox.ItemsSource = entries;

            // Добавьте свой код инициализации
            HotkeyManager.Current.AddOrReplace("MyHotkey", new KeyGesture(Key.Q, ModifierKeys.Control), OnHotKeyHandler);
        }

        private void OnHotKeyHandler(object? sender, HotkeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnHotKeyHandler2(object sender, HotkeyEventArgs e)
        {
            // Обработка события при нажатии на горячую клавишу
            // Добавьте код для ввода текста или выполнения нужных действий
            string selectedKey = keyTextBox.Text;
            string textToType = textTextBox.Text;

            if (!string.IsNullOrEmpty(selectedKey) && !string.IsNullOrEmpty(textToType))
            {
                entries.Add(new Entry { Key = selectedKey, Text = textToType });
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please enter both key and text.");
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (entriesListBox.SelectedItem is Entry selectedEntry)
            {
                string newText = ShowEditDialog(currentText: selectedEntry.Text);

                if (!string.IsNullOrEmpty(newText))
                {
                    selectedEntry.Text = newText;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (entriesListBox.SelectedItem != null)
            {
                _ = entries.Remove(item: (Entry)entriesListBox.SelectedItem);
            }
        }

        private void EntriesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection changed event, if needed
        }

        private static string ShowEditDialog(string currentText)
        {
            EditEntryDialog editDialog = new(currentText);
            if (editDialog.ShowDialog() == true)
            {
                return editDialog.EditedText;
            }
            return currentText;
        }

        private void ClearInputFields()
        {
            keyTextBox.Clear();
            textTextBox.Clear();
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Преобразуйте нажатую клавишу в строковый формат и установите его в keyTextBox
            keyTextBox.Text = e.Key.ToString();
            // Установите флаг Handled, чтобы предотвратить дальнейшую обработку клавиши
            e.Handled = true;
        }
    }
}
