using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MovieSelector2.Model;
using Newtonsoft.Json.Linq;
using MovieSelector2.ViewModel;

namespace MovieSelector2.View
{
    /// <summary>
    /// Interaction logic for WindowMovieDB.xaml
    /// </summary>
    public partial class WindowMovieDB : Window
    {
        public WindowMovieDB()
        {
            InitializeComponent();
        }

        public WindowMovieDB(Film filmEdytowany, JObject elements)
        {
            WindowMovieDBVM context = new WindowMovieDBVM(filmEdytowany, elements);
            this.DataContext = context;
            InitializeComponent();
        }
    }
}
