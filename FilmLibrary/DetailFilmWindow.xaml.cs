using FilmLibrary.Database;
using FilmLibrary.Models;
using Microsoft.EntityFrameworkCore;
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

namespace FilmLibrary
{
    /// <summary>
    /// Логика взаимодействия для DetailFilmWindow.xaml
    /// </summary>
    
    public partial class DetailFilmWindow : Window
    {
        private Film _film;
        public DetailFilmWindow(Film film)
        {
            InitializeComponent();
            _film = film;
            DataContext = _film;
        }

        private void DeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                $"Удалить фильм \"{_film.Name}\"?",
                "Подтвердите удаление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No) return;

            using (var db = new FilmsDBContext())
            {
                db.Films
                  .Where(f => f.Id == _film.Id)
                  .ExecuteDelete();
            }

            MessageBox.Show("Фильм удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }
    }
}
