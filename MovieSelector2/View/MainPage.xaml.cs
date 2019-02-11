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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieSelector2.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {        
        public MainPage(MainWindow window)
        {
            InitializeComponent();
            this.DataContext = window.DataContext;
            Switcher.mainPageSwitcher = this;
            Switcher.Switch(new ListaFilmowPage(window));
        }

        internal void Navigate(Page newPage)
        {
            mainFrame.Content = newPage;
        }
    }
}
