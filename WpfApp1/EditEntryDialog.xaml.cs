// EditEntryDialog.xaml.cs
using System.Windows;

namespace WpfApp
{
    public partial class EditEntryDialog : Window
    {
        public EditEntryDialog(string currentValue)
        {
            InitializeComponent();
            editTextBox.Text = currentValue;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string EditedText => editTextBox.Text;
    }
}
