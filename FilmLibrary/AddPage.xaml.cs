using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmLibrary
{
    public partial class AddPage : UserControl
    {

        public AddPage()
        {
            InitializeComponent();
            nameTextBox.TextChanged += ValidateFields;
            descTextBox.TextChanged += ValidateFields;
            imageTextBox.TextChanged += ValidateFields;
            yearReleaseTextBox.TextChanged += ValidateFields;
            rateTextBox.TextChanged += ValidateFields;
            CategoryComboBox.SelectionChanged += ValidateFields;

            // Первоначальная проверка состояния полей
            ValidateFields(null, null);
        }

        private void ImageText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (Uri.TryCreate(textBox?.Text, UriKind.Absolute, out var uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                image.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
            }
            else
            {
                image.Source = null; 
            }
            ValidateFields(sender, e);
        }
        private void ValidateFields(object sender, EventArgs e)
        {
            // Проверяем, что все обязательные поля заполнены
            bool allFieldsFilled =
                !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(descTextBox.Text) &&
                !string.IsNullOrWhiteSpace(imageTextBox.Text) &&
                !string.IsNullOrWhiteSpace(yearReleaseTextBox.Text) &&
                !string.IsNullOrWhiteSpace(rateTextBox.Text) &&
                !string.IsNullOrWhiteSpace(CategoryComboBox.Text);

            // Обновляем состояние кнопки
            button1.IsEnabled = allFieldsFilled;
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Clicked!!!");
            if(string.IsNullOrEmpty(nameTextBox.Text) &&
                string.IsNullOrEmpty(descTextBox.Text) &&
                string.IsNullOrEmpty(imageTextBox.Text) &&
                string.IsNullOrEmpty(yearReleaseTextBox.Text) &&
                string.IsNullOrEmpty(rateTextBox.Text) &&
                string.IsNullOrEmpty(CategoryComboBox.Text)
                )
            {

                Trace.WriteLine($"{nameTextBox.Text} - {descTextBox.Text} - {imageTextBox.Text} - {CategoryComboBox.Text}");
            }
        }
    }
}
