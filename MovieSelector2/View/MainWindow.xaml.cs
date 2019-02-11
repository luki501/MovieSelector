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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                MainPage page = new MainPage(this);
                Switcher.mainWindowSwitcher = this;
                Switcher.Switch(page);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal void Navigate(Page newPage)
        {
            mainFrame.Content = newPage;
        }
    }
}
