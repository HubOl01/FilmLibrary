using FilmLibrary.Database;
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


            ValidateFields(null, null);
        }

        private void ImageText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (Uri.TryCreate(textBox?.Text, UriKind.Absolute, out var uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                image.Source = new BitmapImage(uri);
            }
            else
            {
                image.Source = null;
            }
            ValidateFields(sender, e);
        }

        // Проверяем, что все обязательные поля заполнены
        private void ValidateFields(object sender, EventArgs e)
        {
            bool allFieldsFilled =
                !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(descTextBox.Text) &&
                !string.IsNullOrWhiteSpace(imageTextBox.Text) &&
                !string.IsNullOrWhiteSpace(yearReleaseTextBox.Text) &&
                !string.IsNullOrWhiteSpace(rateTextBox.Text);

            button1.IsEnabled = allFieldsFilled;
        }

        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
                FilmsDBContext context = new FilmsDBContext();
            using (var db = new FilmsDBContext())
                {
                    db.Films.Add(new Models.Film()
                    {
                        Name = nameTextBox.Text,
                        Image = imageTextBox.Text,
                        Description = descTextBox.Text,
                        Category = CategoryComboBox.Text,
                        YearRelease = int.Parse(yearReleaseTextBox.Text),
                        Rate = double.Parse(rateTextBox.Text.Replace(".", ",")),
                        YearCreated = DateTime.Now.ToString(),
                    });
                db.SaveChanges();
                }
                    
            var lastFilm = context.Films
                      .OrderByDescending(f => f.Id)
                      .FirstOrDefault();

            if (lastFilm != null)
                Trace.WriteLine($"Последний фильм: {lastFilm.Name}");
            else
                Trace.WriteLine("Нет такого фильма в базе.");
            if(lastFilm != null && lastFilm.Name == nameTextBox.Text)
            {
                nameTextBox.Clear();
                descTextBox.Clear();
                imageTextBox.Clear();
                yearReleaseTextBox.Clear();
                rateTextBox.Clear();
                CategoryComboBox.SelectedItem = null;
                image.Source = null;
                ValidateFields(null, null);
            }
        }
    }
}
