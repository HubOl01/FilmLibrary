using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            gridPages.Children.Add(new AddPage());
        }
        private void List_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            gridPages.Children.Add(new ListPage());
        }
        private void Actors_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid();
            gridPages.Children.Add(new ActorsPage());
        }
       
        private void ClearGrid()
        {
            gridPages.Children.Clear();
        }

        private void AddPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

