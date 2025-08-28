using FilmLibrary.Database;
using FilmLibrary.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmLibrary
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : UserControl
    {
        public ListPage()
        {
            InitializeComponent();
            //FilmsDBContext context = new FilmsDBContext();
            //dataFilmsGrid.ItemsSource = context.Films.ToList();
            //dataFilmsGrid.IsReadOnly = true;
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new FilmsDBContext())
            {
                dataFilmsGrid.ItemsSource = context.Films.ToList();
            }
        }

        private void dataFilmsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedFilm = dataFilmsGrid.SelectedItem as Film;
            if (selectedFilm != null)
            {
                var editWindow = new DetailFilmWindow(selectedFilm);
                editWindow.Owner = Window.GetWindow(this);
                editWindow.ShowDialog();


                LoadData();
            }
        }
    }
     
    }
